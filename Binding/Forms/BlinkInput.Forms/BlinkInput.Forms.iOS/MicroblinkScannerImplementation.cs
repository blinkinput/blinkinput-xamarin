using Xamarin.Forms;
using Microblink.Forms.iOS;
using UIKit;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.iOS.Overlays;
using Microblink.Forms.Core.Recognizers;
using Microblink.Forms.Core;
using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Parsers;
using Microblink.Forms.iOS.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(MicroblinkScannerFactoryImplementation))]
namespace Microblink.Forms.iOS
{
    public sealed class MicroblinkScannerImplementation : IMicroblinkScanner, IOverlayVCDelegate
    {
        // ensure RecognizerRunnerVC does not get GC-ed while it is required for ObjC code
        IMBRecognizerRunnerViewController recognizerRunnerViewController;
        // ensure OverlaySettings don't get GC-ed while they are required for ObjC code
        IOverlaySettings overlaySettings;
            DocumentCaptureRecognizerWrapper documentCaptureRecognizerWrapper;
            MBImage highResImage;
            IFieldByFieldCollection fieldByFieldCollection;

        public MicroblinkScannerImplementation(string licenseKey, string licensee, bool showTimeLimitedLicenseWarning)
        {
            MBMicroblinkSDK.SharedInstance.ShowLicenseKeyTimeLimitedWarning = showTimeLimitedLicenseWarning;
            if (licensee == null) 
            {
                MBMicroblinkSDK.SharedInstance.SetLicenseKey(licenseKey);
            }
            else
            {
                MBMicroblinkSDK.SharedInstance.SetLicenseKey(licenseKey, licensee);
            }
        }

        public void Scan(IOverlaySettings overlaySettings)
        {
            this.overlaySettings = overlaySettings;
            var window = UIApplication.SharedApplication.KeyWindow;
            var vc = window.RootViewController;
            if (overlaySettings is DocumentCaptureOverlaySettings)
            {
                this.documentCaptureRecognizerWrapper = ((DocumentCaptureOverlaySettings)overlaySettings).DocumentCaptureRecognizerWrapper;
            }
            else 
            {
                this.documentCaptureRecognizerWrapper = null;
                this.highResImage = null;
            }
            if (overlaySettings is FieldByFieldOverlaySettings)
            {
                this.fieldByFieldCollection = ((FieldByFieldOverlaySettings)overlaySettings).FieldByFieldCollection;
            }
            else 
            {
                this.fieldByFieldCollection = null;
            }

            recognizerRunnerViewController = MBViewControllerFactory.RecognizerRunnerViewControllerWithOverlayViewController(((OverlaySettings)overlaySettings).CreateOverlayViewController(this));

            vc.PresentViewController(ObjCRuntime.Runtime.GetINativeObject<UIViewController>(recognizerRunnerViewController.Handle, false), true, null);
        }

        public void ScanningFinished(MBOverlayViewController overlayViewController, MBRecognizerResultState state)
        {
            overlayViewController.RecognizerRunnerViewController.PauseScanning();
            if (this.highResImage != null)
            {
                documentCaptureRecognizerWrapper.CapturedFullImage = Utils.ConvertUIImage(this.highResImage.Image);
            }

            UIApplication.SharedApplication.InvokeOnMainThread(delegate {
                MessagingCenter.Send(new Microblink.Forms.Core.Messages.ScanningDoneMessage { ScanningCancelled = false }, Microblink.Forms.Core.Messages.ScanningDoneMessageId);
                overlayViewController.DismissViewController(true, null);
            });
        }

        public void CloseButtonTapped(MBOverlayViewController overlayViewController)
        {
            MessagingCenter.Send(new Microblink.Forms.Core.Messages.ScanningDoneMessage { ScanningCancelled = true }, Microblink.Forms.Core.Messages.ScanningDoneMessageId);
            overlayViewController.DismissViewController(true, null);
        }

        public void ScanningFinishedWithHighResolutionImage(MBOverlayViewController overlayViewController, MBImage highResImage, MBRecognizerResultState state) 
        {
            this.highResImage = highResImage;
            
            if (state == MBRecognizerResultState.Uncertain) 
            {
                overlayViewController.RecognizerRunnerViewController.PauseScanning();

                documentCaptureRecognizerWrapper.CapturedFullImage = Utils.ConvertUIImage(this.highResImage.Image);

                UIApplication.SharedApplication.InvokeOnMainThread(delegate {
                MessagingCenter.Send(new Microblink.Forms.Core.Messages.ScanningDoneMessage { ScanningCancelled = false }, Microblink.Forms.Core.Messages.ScanningDoneMessageId);
                overlayViewController.DismissViewController(true, null);
                });
            }
        }

        public void ScanningFinishedWithFieldByFieldElements(MBOverlayViewController overlayViewController, MBScanElement[] scanElements)
        {
            overlayViewController.RecognizerRunnerViewController.PauseScanning();

            for (int i = 0; i < scanElements.Length; ++i)
            {
                fieldByFieldCollection.FieldByFieldElements[i].Value = scanElements[i].Value;   
            }

            UIApplication.SharedApplication.InvokeOnMainThread(delegate {
            MessagingCenter.Send(new Microblink.Forms.Core.Messages.ScanningDoneMessage { ScanningCancelled = false }, Microblink.Forms.Core.Messages.ScanningDoneMessageId);
            overlayViewController.DismissViewController(true, null);
            });
        }

    }

    public sealed class MicroblinkScannerFactoryImplementation : IMicroblinkScannerFactory
    {
        public IMicroblinkScanner CreateMicroblinkScanner(string licenseKey, bool showTimeLimitedLicenseWarning)
        {
            return new MicroblinkScannerImplementation(licenseKey, null, showTimeLimitedLicenseWarning);
        }

        public IMicroblinkScanner CreateMicroblinkScanner(string licenseKey, string licensee, bool showTimeLimitedLicenseWarning)
        {
            return new MicroblinkScannerImplementation(licenseKey, licensee, showTimeLimitedLicenseWarning);
        }
    }
}

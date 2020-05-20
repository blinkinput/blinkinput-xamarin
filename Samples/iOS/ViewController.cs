using System;

using UIKit;

using Microblink;

namespace iOS
{
	public partial class ViewController : UIViewController
	{
		// MBRawParser is used to parse raw text
		MBRawParser rawParser;

		MBDocumentCaptureRecognizer documentCaptureRecognizer;

        // there are plenty of recognizers available - see iOS documentation
        // for more information: https://github.com/BlinkInput/blinkinput-ios/blob/master/README.md

        CustomDelegate customDelegate;

		CustomDocumentCaptureDelegate customDocumentCaptureDelegate;

		public ViewController (IntPtr handle) : base (handle)
		{
		}

		public override void ViewDidLoad ()
		{
			base.ViewDidLoad ();
			// Perform any additional setup after loading the view, typically from a nib.

            customDelegate = new CustomDelegate(this);

			customDocumentCaptureDelegate = new CustomDocumentCaptureDelegate(this);

            // set license key for iOS with bundle ID com.microblink.xamarin.blinkinput
            MBMicroblinkSDK.SharedInstance.SetLicenseKey("sRwAAAEeY29tLm1pY3JvYmxpbmsueGFtYXJpbi5ibGlua2lks3unDF2B9jpa6O+DxWD585yr5k1Kiduix24cAYzmswoh+BfKxH8AOU4sg1PduXcg6+9u3izJKkxlYU61+BVboSq4pzlfnBb8OelIJbFJ5btcTvaG5u2X2lt88dsUH2PmBUPEwBR1AwIHAJdyUq1sqabbMHAadFscU9FnXxKkSXrBer6x7UsRMHA6ULcwaw==");
		}

		public override void DidReceiveMemoryWarning ()
		{
			base.DidReceiveMemoryWarning ();
			// Release any cached data, images, etc that aren't in use.
		}

		partial void StartScanningButton_TouchUpInside (UIButton sender)
		{
			rawParser = new MBRawParser();
			MBScanElement scanElement = new MBScanElement("Raw", rawParser);
			scanElement.LocalizedTitle = "Raw Text";
			scanElement.LocalizedTooltip = @"Scan text";

			// create a collection of MBScanElements that will be used for scanning
			var scanElements = new MBScanElement[1];
			scanElements[0] = scanElement;

			// create a feild by field settings that takes array of scan elements
			var fieldByFieldOverlaySettings = new MBFieldByFieldOverlaySettings(scanElements);

			var fieldByFieldOverlayVC = new MBFieldByFieldOverlayViewController(fieldByFieldOverlaySettings, customDelegate);
			
            // finally, create a recognizerRunnerViewController
            var recognizerRunnerViewController = MBViewControllerFactory.RecognizerRunnerViewControllerWithOverlayViewController(fieldByFieldOverlayVC);

            // in ObjC recognizerRunnerViewController would actually be of type UIViewController<MBRecognizerRunnerViewController>*, but this construct
            // is not supported in C#, so we need to use Runtime.GetINativeObject to cast obtained IMBReocognizerRunnerViewController into UIViewController
            // that can be presented
            this.PresentViewController(ObjCRuntime.Runtime.GetINativeObject<UIViewController>(recognizerRunnerViewController.Handle, false), true, null);
		}

        class CustomDelegate : MBFieldByFieldOverlayViewControllerDelegate
        {
            ViewController me;

            public CustomDelegate(ViewController me)
            {
                this.me = me;
            }

			public override void FieldByFieldOverlayViewController(MBFieldByFieldOverlayViewController fieldByFieldOverlayViewController, MBScanElement[] scanElements)
			{
				fieldByFieldOverlayViewController.RecognizerRunnerViewController.PauseScanning();

				var title = "Result";
				var message = "";

				if (scanElements.Length > 0)
				{
					var rawParserResult = scanElements[0];
					message = "Identifier: " + rawParserResult.Identifier + " " + "Value: " + rawParserResult.Value;
				}
				

				UIApplication.SharedApplication.InvokeOnMainThread(delegate
				{
					UIAlertView alert = new UIAlertView()
					{
						Title = title,
						Message = message
					};
					alert.AddButton("OK");
					alert.Show();
					// after alert dialog is dismissed, you can either resume scanning with 
					// documentOverlayViewController.RecognizerRunnerViewController.ResumeScanningAndResetState(true)
					// or you can simply dismiss the RecognizerRunnerViewController
					alert.Dismissed += (sender, e) => me.DismissViewController(true, null);
				});

			}

			public override void FieldByFieldOverlayViewControllerWillClose(MBFieldByFieldOverlayViewController fieldByFieldOverlayViewController)
			{
				me.DismissViewController(true, null);
			}
        }

		partial void StartDocumentCaptureButton_TouchUpInside(UIButton sender)
		{
			documentCaptureRecognizer = new MBDocumentCaptureRecognizer();
			documentCaptureRecognizer.ReturnFullDocumentImage = true;

			// create a settings object for overlay that will be used. For ID it's best to use DocumentOverlayViewController
			// there are also other overlays available - check iOS documentation
			var documentCaptureOverlaySettings = new MBDocumentCaptureOverlaySettings();
			var documentCaptureOverlay = new MBDocumentCaptureOverlayViewController(documentCaptureOverlaySettings, documentCaptureRecognizer, customDocumentCaptureDelegate);

			// finally, create a recognizerRunnerViewController
			var recognizerRunnerViewController = MBViewControllerFactory.RecognizerRunnerViewControllerWithOverlayViewController(documentCaptureOverlay);

			// in ObjC recognizerRunnerViewController would actually be of type UIViewController<MBRecognizerRunnerViewController>*, but this construct
			// is not supported in C#, so we need to use Runtime.GetINativeObject to cast obtained IMBReocognizerRunnerViewController into UIViewController
			// that can be presented
			this.PresentViewController(ObjCRuntime.Runtime.GetINativeObject<UIViewController>(recognizerRunnerViewController.Handle, false), true, null);
		}

		class CustomDocumentCaptureDelegate : MBDocumentCaptureOverlayViewControllerDelegate
		{
			ViewController me;

			MBImage highResolutionImage;

			public CustomDocumentCaptureDelegate(ViewController me)
			{
				this.me = me;
			}

			public override void DocumentCaptureOverlayViewControllerDidTapClose(MBDocumentCaptureOverlayViewController documentCaptureOverlayViewController)
			{
				me.DismissViewController(true, null);
			}

			public override void DocumentCaptureOverlayViewControllerDidFinishScanning(MBDocumentCaptureOverlayViewController documentCaptureOverlayViewController, MBRecognizerResultState state)
			{
				if (state == MBRecognizerResultState.Valid)
				{
					documentCaptureOverlayViewController.RecognizerRunnerViewController.PauseScanning();

					UIApplication.SharedApplication.InvokeOnMainThread(delegate
					{
						me.metadataImageView.Image = me.documentCaptureRecognizer.Result.FullDocumentImage.Image;

						if (this.highResolutionImage != null)
						{
							me.highResImageView.Image = this.highResolutionImage.Image;
						}

						me.DismissViewController(true, null);
					});
					
				}
			}

			public override void DocumentCaptureOverlayViewControllerDidCaptureHighResolutionImage(MBDocumentCaptureOverlayViewController documentCaptureOverlayViewController, MBImage highResImage, MBRecognizerResultState state)
			{
				this.highResolutionImage = highResImage;

				if (state == MBRecognizerResultState.Uncertain)
				{
					documentCaptureOverlayViewController.RecognizerRunnerViewController.PauseScanning();

					UIApplication.SharedApplication.InvokeOnMainThread(delegate
					{
						me.metadataImageView.Image = this.highResolutionImage.Image;

						me.DismissViewController(true, null);
					});
				}
			}
		}
	}
}


using Microblink.Forms.iOS.Overlays;
using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Microblink;

[assembly: Xamarin.Forms.Dependency(typeof(DocumentCaptureOverlaySettingsFactory))]
namespace Microblink.Forms.iOS.Overlays
{
    public sealed class DocumentCaptureOverlaySettings : OverlaySettings, IDocumentCaptureOverlaySettings
    {
        readonly MBDocumentCaptureOverlaySettings nativeDocumentCaptureOverlaySettings;
        public DocumentCaptureRecognizerWrapper DocumentCaptureRecognizerWrapper { get; }

        // this ensures GC does not collect delegate proxy while it is used by ObjC
        DocumentCaptureOverlayVCDelegate documentCaptureOverlayVCDelegate;

        public DocumentCaptureOverlaySettings(DocumentCaptureRecognizerWrapper documentCaptureRecognizerWrapper)
            : base(new MBDocumentCaptureOverlaySettings())
        {
            nativeDocumentCaptureOverlaySettings = NativeOverlaySettings as MBDocumentCaptureOverlaySettings;
            DocumentCaptureRecognizerWrapper = documentCaptureRecognizerWrapper;
        }

        public override MBOverlayViewController CreateOverlayViewController(IOverlayVCDelegate overlayVCDelegate)
        {
            documentCaptureOverlayVCDelegate = new DocumentCaptureOverlayVCDelegate(overlayVCDelegate);
            return new MBDocumentCaptureOverlayViewController(nativeDocumentCaptureOverlaySettings, (MBDocumentCaptureRecognizer)(DocumentCaptureRecognizerWrapper.DocumentCaptureRecognizer as Recognizer).NativeRecognizer, documentCaptureOverlayVCDelegate);
        }
    }

    public sealed class DocumentCaptureOverlaySettingsFactory : IDocumentCaptureOverlaySettingsFactory
    {
        public IDocumentCaptureOverlaySettings CreateDocumentCaptureOverlaySettings(DocumentCaptureRecognizerWrapper documentCaptureRecognizerWrapper)
        {
            return new DocumentCaptureOverlaySettings(documentCaptureRecognizerWrapper);
        }
    }

    public sealed class DocumentCaptureOverlayVCDelegate : MBDocumentCaptureOverlayViewControllerDelegate
    {
        readonly IOverlayVCDelegate overlayVCDelegate;

        public DocumentCaptureOverlayVCDelegate(IOverlayVCDelegate overlayVCDelegate)
        {
            this.overlayVCDelegate = overlayVCDelegate;
        }

        public override void DocumentCaptureOverlayViewControllerDidFinishScanning(MBDocumentCaptureOverlayViewController documentCaptureOverlayViewController, MBRecognizerResultState state)
        {
            overlayVCDelegate.ScanningFinished(documentCaptureOverlayViewController, state);
        }

        public override void DocumentCaptureOverlayViewControllerDidTapClose(MBDocumentCaptureOverlayViewController documentCaptureOverlayViewController)
        {
            overlayVCDelegate.CloseButtonTapped(documentCaptureOverlayViewController);
        }

        public override void DocumentCaptureOverlayViewControllerDidCaptureHighResolutionImage(MBDocumentCaptureOverlayViewController documentCaptureOverlayViewController, MBImage highResImage, MBRecognizerResultState state)
        {
            overlayVCDelegate.ScanningFinishedWithHighResolutionImage(documentCaptureOverlayViewController, highResImage, state);
        }
    }
}

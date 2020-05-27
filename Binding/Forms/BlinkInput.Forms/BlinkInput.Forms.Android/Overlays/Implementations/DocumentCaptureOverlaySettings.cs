using Microblink.Forms.Droid.Overlays;
using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Com.Microblink.Uisettings;
using Com.Microblink.Entities.Recognizers.Blinkinput.Documentcapture;

[assembly: Xamarin.Forms.Dependency(typeof(DocumentCaptureOverlaySettingsFactory))]
namespace Microblink.Forms.Droid.Overlays
{
    public sealed class DocumentCaptureOverlaySettings : OverlaySettings, IDocumentCaptureOverlaySettings
    {

        public DocumentCaptureRecognizerWrapper DocumentCaptureRecognizerWrapper { get; }

        public DocumentCaptureOverlaySettings(DocumentCaptureRecognizerWrapper documentCaptureRecognizerWrapper)
            : base(new DocumentCaptureUISettings(new DocumentCaptureRecognizerTransferable((Com.Microblink.Entities.Recognizers.Blinkinput.Documentcapture.DocumentCaptureRecognizer)(((Microblink.Forms.Droid.Recognizers.DocumentCaptureRecognizer)documentCaptureRecognizerWrapper.DocumentCaptureRecognizer).NativeRecognizer))))
        {
            DocumentCaptureRecognizerWrapper = documentCaptureRecognizerWrapper;
        }
    }

    public sealed class DocumentCaptureOverlaySettingsFactory : IDocumentCaptureOverlaySettingsFactory
    {
        public IDocumentCaptureOverlaySettings CreateDocumentCaptureOverlaySettings(DocumentCaptureRecognizerWrapper documentCaptureRecognizerWrapper)
        {
            return new DocumentCaptureOverlaySettings(documentCaptureRecognizerWrapper);
        }
    }
}

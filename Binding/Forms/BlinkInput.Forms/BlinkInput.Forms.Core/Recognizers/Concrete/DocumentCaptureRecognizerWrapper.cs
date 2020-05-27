namespace Microblink.Forms.Core.Recognizers
{

    /// <summary>
    /// Document capture recognizer wrapper used for configuring document capture scanning feature. Holds document
    /// capture recognizer and captured full camera image that will be set after scanning is done.
    /// </summary>
    public sealed class DocumentCaptureRecognizerWrapper
    {
        public DocumentCaptureRecognizerWrapper(IDocumentCaptureRecognizer documentCaptureRecognizer)
        {
            DocumentCaptureRecognizer = documentCaptureRecognizer;
        }

        /// <summary>
        /// Document capture recognizer.
        /// </summary>
        public IDocumentCaptureRecognizer DocumentCaptureRecognizer { get; }

        /// <summary>
        /// Captured full camera frame.
        /// </summary>
        public Xamarin.Forms.ImageSource CapturedFullImage { get; set;}
    }
}

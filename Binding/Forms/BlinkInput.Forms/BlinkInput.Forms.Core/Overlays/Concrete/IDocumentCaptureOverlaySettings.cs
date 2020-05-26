using System;
using Microblink.Forms.Core.Recognizers;

namespace Microblink.Forms.Core.Overlays
{
    /// <summary>
    /// Settings for document capture overlay, which is designed for taking high resolution document images and guides
    /// the user through the image capturing process.
    /// </summary>
    public interface IDocumentCaptureOverlaySettings : IOverlaySettings
    {}

    /// <summary>
    /// Document capture overlay settings factory. Use this to create an instance of IDocumentCaptureOverlaySettings.
    /// </summary>
    public interface IDocumentCaptureOverlaySettingsFactory
    {
        /// <summary>
        /// Creates the document capture overlay settings using the provided recognizer collection.
        /// </summary>
        /// <returns>The document capture overlay settings.</returns>
        /// <param name="documentCaptureRecognizerWrapper">Wrapper around DocumentCaptureRecognizer that will be used
        /// for scanning. Also holds reference to full camera image that is captured during scan. </param>
        IDocumentCaptureOverlaySettings CreateDocumentCaptureOverlaySettings(DocumentCaptureRecognizerWrapper documentCaptureRecognizerWrapper);
    }
}

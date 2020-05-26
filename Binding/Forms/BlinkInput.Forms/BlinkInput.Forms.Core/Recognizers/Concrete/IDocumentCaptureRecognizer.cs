namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// A generic document capture recognizer.
    /// </summary>
    public interface IDocumentCaptureRecognizer : IRecognizer
    {
        
        /// <summary>
        /// The extension factors for full document image. 
        ///
        /// By default, this is set to '[0.0, 0.0, 0.0, 0.0]'
        /// </summary>
        IImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
        
        /// <summary>
        /// Defines minimum document scale calculated as ratio of minimal document dimension and minimal 
        ///
        /// By default, this is set to '0.5'
        /// </summary>
        float MinDocumentScale { get; set; }
        
        /// <summary>
        /// Minimum number of stable detections required for detection to be successful. 
        ///
        /// By default, this is set to '2'
        /// </summary>
        uint NumStableDetectionsThreshold { get; set; }
        
        /// <summary>
        /// Defines whether full document image will be available in 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnFullDocumentImage { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IDocumentCaptureRecognizerResult Result { get; }
    }

    /// <summary>
    /// Result object for IDocumentCaptureRecognizer.
    /// </summary>
    public interface IDocumentCaptureRecognizerResult : IRecognizerResult {
        
        /// <summary>
        /// The location of captured document in coordinate system of image in which detection was performed. 
        /// </summary>
        IQuadrilateral DetectionLocation { get; }
        
        /// <summary>
        /// Image of the full document 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
    }
}
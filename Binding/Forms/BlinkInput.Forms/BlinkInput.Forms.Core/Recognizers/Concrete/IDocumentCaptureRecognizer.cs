namespace Microblink.Forms.Core.Recognizers
{
    /// <summary>
    /// A recognizer for DocumentCaptureRecognizer
    /// </summary>
    public interface IDocumentCaptureRecognizer : IRecognizer
    {
        
        /// <summary>
        /// Image extension factors for full document image.
        /// 
        /// @see ImageExtensionFactors
        ///  
        ///
        /// By default, this is set to '{0.0f, 0.0f, 0.0f, 0.0f}'
        /// </summary>
        IImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
        
        /// <summary>
        /// Defines minimum document scale calculated as ratio of minimal document dimension and minimal dimension of the input image.
        /// 
        ///  
        ///
        /// By default, this is set to '0.5'
        /// </summary>
        float MinDocumentScale { get; set; }
        
        /// <summary>
        /// Defines how many times the same document should be detected before the detector
        /// returns this document as a result of the deteciton
        /// 
        /// Higher number means more reliable detection, but slower processing
        /// 
        ///  
        ///
        /// By default, this is set to '3'
        /// </summary>
        uint NumStableDetectionsThreshold { get; set; }
        
        /// <summary>
        /// Sets whether full document image of ID card should be extracted.
        /// 
        ///  
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
        /// Quadrangle represeting corner points of location of the captured document 
        /// </summary>
        IQuadrilateral DetectionLocation { get; }
        
        /// <summary>
        /// full document image if enabled with returnFullDocumentImage property. 
        /// </summary>
        Xamarin.Forms.ImageSource FullDocumentImage { get; }
        
    }
}
namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// RawParser that simply returns the string version of raw OCR result, without performing
    /// any smart parsing operations.
    /// </summary>
    public interface IRawParser : IParser
    {
        
        /// <summary>
        /// Enable the usage of algorithm for combining consecutive OCR results between video frames
        /// for improving OCR quality. By default this is turned off.
        /// Note: This option works together only with if instance of {@link com.microblink.entities.ocrengine.legacy.BlinkOCREngineOptions} is given
        /// to {@link #setOcrEngineOptions(com.microblink.entities.ocrengine.AbstractOCREngineOptions)}. Otherwise, it will not be
        /// enabled and {@link IllegalArgumentException} will be thrown.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool UseSieve { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IRawParserResult Result { get; }
    }

    /// <summary>
    /// Result object for IRawParser.
    /// </summary>
    public interface IRawParserResult : IParserResult {
        
        /// <summary>
        /// Extracted date string. 
        /// </summary>
        string RawText { get; }
        
    }
}
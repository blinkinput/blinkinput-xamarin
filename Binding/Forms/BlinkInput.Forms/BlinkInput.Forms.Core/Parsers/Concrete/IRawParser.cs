namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// A parser that simply returns the string version of raw OCR result, without performing
    ///  * any smart parsing operations.
    /// </summary>
    public interface IRawParser : IParser
    {
        
        /// <summary>
        /// True if algorithm for combining consecutive OCR results between video frames 
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
        /// String version of raw OCR result. 
        /// </summary>
        string RawText { get; }
        
    }
}
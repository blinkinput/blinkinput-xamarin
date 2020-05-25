namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// A parser that can extract date from OCR result.
    /// </summary>
    public interface IDateParser : IParser
    {
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IDateParserResult Result { get; }
    }

    /// <summary>
    /// Result object for IDateParser.
    /// </summary>
    public interface IDateParserResult : IParserResult {
        
        /// <summary>
        /// Extracted date. 
        /// </summary>
        IDate Date { get; }
        
    }
}
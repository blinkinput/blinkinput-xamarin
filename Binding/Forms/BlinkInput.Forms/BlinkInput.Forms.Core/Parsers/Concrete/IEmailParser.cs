namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// Parser that can parse e-mail addresses from OCR result.
    /// </summary>
    public interface IEmailParser : IParser
    {
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IEmailParserResult Result { get; }
    }

    /// <summary>
    /// Result object for IEmailParser.
    /// </summary>
    public interface IEmailParserResult : IParserResult {
        
        /// <summary>
        /// Parsed e-mail address. 
        /// </summary>
        string Email { get; }
        
    }
}
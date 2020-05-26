namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// EmailParser is used for parsing emails
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
        /// Returns the recognized email or empty string if recognition failed. 
        /// </summary>
        string Email { get; }
        
    }
}
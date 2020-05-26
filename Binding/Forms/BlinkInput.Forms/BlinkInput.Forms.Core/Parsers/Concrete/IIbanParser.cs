namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// A parser that can extract IBAN (International Bank Account Number) from OCR result.
    /// </summary>
    public interface IIbanParser : IParser
    {
        
        /// <summary>
        /// Should prefix (country code) always be returned. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AlwaysReturnPrefix { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IIbanParserResult Result { get; }
    }

    /// <summary>
    /// Result object for IIbanParser.
    /// </summary>
    public interface IIbanParserResult : IParserResult {
        
        /// <summary>
        /// Parsed IBAN (International Bank Account Number). 
        /// </summary>
        string Iban { get; }
        
    }
}
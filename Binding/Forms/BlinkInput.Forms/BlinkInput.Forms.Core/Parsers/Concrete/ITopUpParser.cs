namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// A parser that can extract TopUp (mobile phone coupon) codes from OCR result.
    /// </summary>
    public interface ITopUpParser : IParser
    {
        
        /// <summary>
        /// Indicates whether USSD codes without prefix are allowed. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowNoPrefix { get; set; }
        
        /// <summary>
        /// Indicates whether {*digits*} prefix and {#} at the end of scanned USSD code will 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ReturnCodeWithoutPrefix { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        ITopUpParserResult Result { get; }
    }

    /// <summary>
    /// Result object for ITopUpParser.
    /// </summary>
    public interface ITopUpParserResult : IParserResult {
        
        /// <summary>
        /// Parsed TopUp code. 
        /// </summary>
        string TopUp { get; }
        
    }
}
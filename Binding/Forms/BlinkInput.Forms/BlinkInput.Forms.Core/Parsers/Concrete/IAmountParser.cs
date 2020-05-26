namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// A parser that can extract amounts from OCR result.
    /// </summary>
    public interface IAmountParser : IParser
    {
        
        /// <summary>
        /// Indicates whether amounts without decimal are accepted as valid. For example 1.465 is 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowMissingDecimals { get; set; }
        
        /// <summary>
        /// Indicates whether negative values are accepted as valid amounts. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowNegativeAmounts { get; set; }
        
        /// <summary>
        /// Indicates whether amounts with space separators between groups of digits(thousands) are allowed. 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowSpaceSeparators { get; set; }
        
        /// <summary>
        /// Indicates whether Arabic-Indic mode is enabled. In Arabic-Indic mode parser can recognize 
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool ArabicIndicMode { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IAmountParserResult Result { get; }
    }

    /// <summary>
    /// Result object for IAmountParser.
    /// </summary>
    public interface IAmountParserResult : IParserResult {
        
        /// <summary>
        /// Parsed amount. 
        /// </summary>
        string Amount { get; }
        
    }
}
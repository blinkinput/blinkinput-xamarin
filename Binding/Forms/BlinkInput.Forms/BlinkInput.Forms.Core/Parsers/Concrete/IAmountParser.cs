﻿namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// AmountParser is used for extracting amount from OCR result
    /// </summary>
    public interface IAmountParser : IParser
    {
        
        /// <summary>
        /// Indicates whether amounts without decimal are accepted as valid. For example 1.465 is
        /// accepted as valid amount, but 1465 is not, unless this is set to true.
        /// Setting this to {@code true} can yield to more false positives
        /// because any set of consequent digits can represent valid amount.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowMissingDecimals { get; set; }
        
        /// <summary>
        /// Indicates whether negative values are accepted as valid amounts.
        /// Setting this to true can yield to more false positives.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowNegativeAmounts { get; set; }
        
        /// <summary>
        /// Indicates whether amounts with space separators between groups of digits(thousands) are allowed.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowSpaceSeparators { get; set; }
        
        /// <summary>
        /// Indicates whether Arabic-Indic mode is enabled. In Arabic-Indic mode parser can recognize
        /// only amounts which consist of Arabic-Indic digits and decimal separator.
        /// 
        ///  
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
        /// Returns the recognized amount number or empty string if recognition failed. 
        /// </summary>
        string Amount { get; }
        
    }
}
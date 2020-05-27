namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// AmountParser is used for extracting from OCR result with regular expressions
    /// </summary>
    public interface IRegexParser : IParser
    {
        
        /// <summary>
        /// Defines regex that will be used to parse OCR data. Note that not all java regex features
        /// are available, such as back references and '^' and '$' meta-character. '.' meta-character
        /// that represents any character and '^' inside brackets representing all characters except those
        /// in brackets are available only if alphabet is defined.
        /// 
        /// </summary>
        string Regex { get; set; }
        
        /// <summary>
        /// Enable the usage of algorithm for combining consecutive OCR results between video frames
        /// for improving OCR quality. By default this is turned off.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool UseSieve { get; set; }
        
        /// <summary>
        /// If set to YES, regex will not be matched if there is no whitespace before matched string.
        /// Whitespace is not returned in parsed result.
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool StartWithWhitespace { get; set; }
        
        /// <summary>
        /// If set to YES, regex will not be matched if there is no whitespace after matched string.
        /// only amounts which consist of Arabic-Indic digits and decimal separator.
        /// 
        ///  Whitespace is not returned in parsed result.
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool EndWithWhitespace { get; set; }
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IRegexParserResult Result { get; }
    }

    /// <summary>
    /// Result object for IRegexParserResult.
    /// </summary>
    public interface IRegexParserResult : IParserResult {
        
        /// <summary>
        /// Returns string containing parsed OCR result according to given regular expression.
        /// </summary>
        string ParsedString { get; }
        
    }

    /// <summary>
    /// Regex parser factory. Use this to create an instance of IRegexParserFactory.
    /// </summary>
    public interface IRegexParserFactory
    {
        /// <summary>
        /// Creates regex parser.
        /// </summary>
        /// <returns>The recognizer collection.</returns>
        /// <param name="regex">Regular expression pattern for extraction.</param>
        IRegexParser CreateRegexParser(string regex);
    }
}
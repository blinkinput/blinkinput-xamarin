namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// Available date formats for date parser. To activate parsing of dates with month names in
    /// English, use formats which contain MONTH, e.g. DateFormatDDMONTHYYYY.
    /// Month names in uppercase and short month names are supported (for example March and Mar).
    /// typedef NS_ENUM(NSUInteger, DateFormat) {
    ///     DateFormatDDMMYYYY = 0,
    ///     DateFormatDDMMYY,
    ///     DateFormatMMDDYYYY,
    ///     DateFormatMMDDYY,
    ///     DateFormatYYYYMMDD,
    ///     DateFormatYYMMDD,
    ///     DateFormatDDMONTHYYYY,
    ///     DateFormatDDMONTHYY,
    ///     DateFormatMONTHDDYYYY,
    ///     DateFormatMONTHDDYY,
    ///     DateFormatYYYYMONTHDD,
    ///     DateFormatYYMONTHDD
    /// };
    /// 
    /// typedef NSArray<NSNumber
    /// > DateFormatArray;
    /// typedef NSArray<NSString
    /// > DateSeparatorCharsArray;
    /// 
    /// NS_ASSUME_falseNNULL_BEGIN
    /// 
    /// DateParser that can extract date from OCR result.
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
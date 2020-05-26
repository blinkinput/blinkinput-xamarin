namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// Parser that can parse license plate content from OCR result.
    /// </summary>
    public interface ILicensePlatesParser : IParser
    {
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        ILicensePlatesParserResult Result { get; }
    }

    /// <summary>
    /// Result object for ILicensePlatesParser.
    /// </summary>
    public interface ILicensePlatesParserResult : IParserResult {
        
        /// <summary>
        /// Parsed license plate string. 
        /// </summary>
        string LicensePlate { get; }
        
    }
}
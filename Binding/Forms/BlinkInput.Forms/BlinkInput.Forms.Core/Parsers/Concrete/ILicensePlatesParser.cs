namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// LicensePlatesParser is used for parsing license plates
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
        /// Returns the recognized license plate number or empty string if recognition failed. 
        /// </summary>
        string LicensePlate { get; }
        
    }
}
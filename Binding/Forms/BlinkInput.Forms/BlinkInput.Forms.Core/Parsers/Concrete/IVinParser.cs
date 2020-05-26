namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// VinParser is used for parsing VIN numbers
    /// </summary>
    public interface IVinParser : IParser
    {
        

        /// <summary>
        /// Gets the result.
        /// </summary>
        IVinParserResult Result { get; }
    }

    /// <summary>
    /// Result object for IVinParser.
    /// </summary>
    public interface IVinParserResult : IParserResult {
        
        /// <summary>
        /// Returns the recognized VIN number or empty string if recognition failed. 
        /// </summary>
        string Vin { get; }
        
    }
}
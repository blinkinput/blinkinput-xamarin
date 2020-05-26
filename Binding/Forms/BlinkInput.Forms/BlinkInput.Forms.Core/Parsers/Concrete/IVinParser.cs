namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// Parser that can parse VIN numbers (Vehicle identification numbers).
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
        /// Parsed VIN (Vehicle Identification Number). 
        /// </summary>
        string Vin { get; }
        
    }
}
namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// Enumeration of posibble top up presets
    /// typedef NS_ENUM(NSUInteger, TopUpPreset) {
    ///     
    ///     /
    /// 
    /// For top ups which begin with <b>
    /// 123
    /// </b> prefix and USSD code length is <b>14</b>
    ///     TopUp123,
    ///     
    ///     /
    /// 
    /// For top ups which begin with <b>
    /// 103
    /// </b> and USSD code length is <b>14</b>
    ///     TopUp103,
    ///     
    ///     /
    /// 
    /// For top ups which begin with <b>
    /// 131
    /// </b> and USSD code length is <b>13</b>
    ///     TopUp131,
    ///     
    ///     /
    /// 
    /// For top ups with any prefix and USSD code length from interval {[13, 16]}
    ///     TopUpGeneric,
    ///     
    /// };
    /// 
    /// NS_ASSUME_falseNNULL_BEGIN
    /// 
    /// TopUpParser is used for parsing Top Up numbers
    /// </summary>
    public interface ITopUpParser : IParser
    {
        
        /// <summary>
        /// Indicates whether USSD codes without prefix are allowed.
        /// 
        ///  
        ///
        /// By default, this is set to 'false'
        /// </summary>
        bool AllowNoPrefix { get; set; }
        
        /// <summary>
        /// Indicates whether digts prefix and # at the end of scanned USSD code will
        /// be returned.
        /// 
        ///  
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
        /// Returns the recognized Top Up number or empty string if recognition failed. 
        /// </summary>
        string TopUp { get; }
        
    }
}
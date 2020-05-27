using Microblink.Forms.Droid.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(LicensePlatesParser))]
namespace Microblink.Forms.Droid.Parsers
{
    public sealed class LicensePlatesParser : Parser, ILicensePlatesParser
    {
        Com.Microblink.Entities.Parsers.Licenseplates.LicensePlatesParser nativeParser;

        LicensePlatesParserResult result;

        public LicensePlatesParser() : base(new Com.Microblink.Entities.Parsers.Licenseplates.LicensePlatesParser())
        {
            nativeParser = NativeParser as Com.Microblink.Entities.Parsers.Licenseplates.LicensePlatesParser;
            result = new LicensePlatesParserResult(nativeParser.GetResult() as Com.Microblink.Entities.Parsers.Licenseplates.LicensePlatesParser.Result);
        }

        public override IParserResult BaseResult => result;

        public ILicensePlatesParserResult Result => result;

        
    }

    public sealed class LicensePlatesParserResult : ParserResult, ILicensePlatesParserResult
    {
        Com.Microblink.Entities.Parsers.Licenseplates.LicensePlatesParser.Result nativeResult;

        internal LicensePlatesParserResult(Com.Microblink.Entities.Parsers.Licenseplates.LicensePlatesParser.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string LicensePlate => nativeResult.LicensePlate;
    }
}
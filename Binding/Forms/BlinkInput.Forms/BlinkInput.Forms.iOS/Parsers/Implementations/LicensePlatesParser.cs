using Microblink.Forms.iOS.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(LicensePlatesParser))]
namespace Microblink.Forms.iOS.Parsers
{
    public sealed class LicensePlatesParser : Parser, ILicensePlatesParser
    {
        MBLicensePlatesParser nativeParser;

        LicensePlatesParserResult result;

        public LicensePlatesParser() : base(new MBLicensePlatesParser())
        {
            nativeParser = NativeParser as MBLicensePlatesParser;
            result = new LicensePlatesParserResult(nativeParser.Result);
        }

        public override IParserResult BaseResult => result;

        public ILicensePlatesParserResult Result => result;

        
    }

    public sealed class LicensePlatesParserResult : ParserResult, ILicensePlatesParserResult
    {
        MBLicensePlatesParserResult nativeResult;

        internal LicensePlatesParserResult(MBLicensePlatesParserResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string LicensePlate => nativeResult.LicensePlate;
    }
}
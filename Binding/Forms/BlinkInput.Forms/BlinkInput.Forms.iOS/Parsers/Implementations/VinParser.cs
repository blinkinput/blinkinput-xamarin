using Microblink.Forms.iOS.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(VinParser))]
namespace Microblink.Forms.iOS.Parsers
{
    public sealed class VinParser : Parser, IVinParser
    {
        MBVinParser nativeParser;

        VinParserResult result;

        public VinParser() : base(new MBVinParser())
        {
            nativeParser = NativeParser as MBVinParser;
            result = new VinParserResult(nativeParser.Result);
        }

        public override IParserResult BaseResult => result;

        public IVinParserResult Result => result;

        
    }

    public sealed class VinParserResult : ParserResult, IVinParserResult
    {
        MBVinParserResult nativeResult;

        internal VinParserResult(MBVinParserResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Vin => nativeResult.Vin;
    }
}
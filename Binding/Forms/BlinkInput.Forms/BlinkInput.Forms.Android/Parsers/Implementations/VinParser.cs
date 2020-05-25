using Microblink.Forms.Droid.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(VinParser))]
namespace Microblink.Forms.Droid.Parsers
{
    public sealed class VinParser : Parser, IVinParser
    {
        Com.Microblink.Entities.Parsers.Vin.VinParser nativeParser;

        VinParserResult result;

        public VinParser() : base(new Com.Microblink.Entities.Parsers.Vin.VinParser())
        {
            nativeParser = NativeParser as Com.Microblink.Entities.Parsers.Vin.VinParser;
            result = new VinParserResult(nativeParser.GetResult() as Com.Microblink.Entities.Parsers.Vin.VinParser.Result);
        }

        public override IParserResult BaseResult => result;

        public IVinParserResult Result => result;

        
    }

    public sealed class VinParserResult : ParserResult, IVinParserResult
    {
        Com.Microblink.Entities.Parsers.Vin.VinParser.Result nativeResult;

        internal VinParserResult(Com.Microblink.Entities.Parsers.Vin.VinParser.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Vin => nativeResult.Vin;
    }
}
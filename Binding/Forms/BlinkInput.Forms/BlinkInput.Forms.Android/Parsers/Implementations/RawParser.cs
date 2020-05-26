using Microblink.Forms.Droid.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(RawParser))]
namespace Microblink.Forms.Droid.Parsers
{
    public sealed class RawParser : Parser, IRawParser
    {
        Com.Microblink.Entities.Parsers.Raw.RawParser nativeParser;

        RawParserResult result;

        public RawParser() : base(new Com.Microblink.Entities.Parsers.Raw.RawParser())
        {
            nativeParser = NativeParser as Com.Microblink.Entities.Parsers.Raw.RawParser;
            result = new RawParserResult(nativeParser.GetResult() as Com.Microblink.Entities.Parsers.Raw.RawParser.Result);
        }

        public override IParserResult BaseResult => result;

        public IRawParserResult Result => result;

        
        public bool UseSieve
        {
            get => nativeParser.ShouldUseSieve();
            set => nativeParser.SetUseSieve(value);
        }
        
    }

    public sealed class RawParserResult : ParserResult, IRawParserResult
    {
        Com.Microblink.Entities.Parsers.Raw.RawParser.Result nativeResult;

        internal RawParserResult(Com.Microblink.Entities.Parsers.Raw.RawParser.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string RawText => nativeResult.RawText;
    }
}
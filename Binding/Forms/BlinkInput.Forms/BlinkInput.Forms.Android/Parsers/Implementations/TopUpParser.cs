using Microblink.Forms.Droid.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(TopUpParser))]
namespace Microblink.Forms.Droid.Parsers
{
    public sealed class TopUpParser : Parser, ITopUpParser
    {
        Com.Microblink.Entities.Parsers.Topup.TopUpParser nativeParser;

        TopUpParserResult result;

        public TopUpParser() : base(new Com.Microblink.Entities.Parsers.Topup.TopUpParser())
        {
            nativeParser = NativeParser as Com.Microblink.Entities.Parsers.Topup.TopUpParser;
            result = new TopUpParserResult(nativeParser.GetResult() as Com.Microblink.Entities.Parsers.Topup.TopUpParser.Result);
        }

        public override IParserResult BaseResult => result;

        public ITopUpParserResult Result => result;

        
        public bool AllowNoPrefix
        {
            get => nativeParser.ShouldAllowNoPrefix();
            set => nativeParser.SetAllowNoPrefix(value);
        }
        
        public bool ReturnCodeWithoutPrefix
        {
            get => nativeParser.ShouldReturnCodeWithoutPrefix();
            set => nativeParser.SetReturnCodeWithoutPrefix(value);
        }
        
    }

    public sealed class TopUpParserResult : ParserResult, ITopUpParserResult
    {
        Com.Microblink.Entities.Parsers.Topup.TopUpParser.Result nativeResult;

        internal TopUpParserResult(Com.Microblink.Entities.Parsers.Topup.TopUpParser.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string TopUp => nativeResult.TopUp;
    }
}
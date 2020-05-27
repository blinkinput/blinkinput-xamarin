using Microblink.Forms.iOS.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(TopUpParser))]
namespace Microblink.Forms.iOS.Parsers
{
    public sealed class TopUpParser : Parser, ITopUpParser
    {
        MBTopUpParser nativeParser;

        TopUpParserResult result;

        public TopUpParser() : base(new MBTopUpParser())
        {
            nativeParser = NativeParser as MBTopUpParser;
            result = new TopUpParserResult(nativeParser.Result);
        }

        public override IParserResult BaseResult => result;

        public ITopUpParserResult Result => result;

        
        public bool AllowNoPrefix 
        { 
            get => nativeParser.AllowNoPrefix; 
            set => nativeParser.AllowNoPrefix = value;
        }
        
        public bool ReturnCodeWithoutPrefix 
        { 
            get => nativeParser.ReturnCodeWithoutPrefix; 
            set => nativeParser.ReturnCodeWithoutPrefix = value;
        }
        
    }

    public sealed class TopUpParserResult : ParserResult, ITopUpParserResult
    {
        MBTopUpParserResult nativeResult;

        internal TopUpParserResult(MBTopUpParserResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string TopUp => nativeResult.TopUp;
    }
}
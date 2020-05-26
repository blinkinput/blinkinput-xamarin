using Microblink.Forms.iOS.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(RawParser))]
namespace Microblink.Forms.iOS.Parsers
{
    public sealed class RawParser : Parser, IRawParser
    {
        MBRawParser nativeParser;

        RawParserResult result;

        public RawParser() : base(new MBRawParser())
        {
            nativeParser = NativeParser as MBRawParser;
            result = new RawParserResult(nativeParser.Result);
        }

        public override IParserResult BaseResult => result;

        public IRawParserResult Result => result;

        
        public bool UseSieve 
        { 
            get => nativeParser.UseSieve; 
            set => nativeParser.UseSieve = value;
        }
        
    }

    public sealed class RawParserResult : ParserResult, IRawParserResult
    {
        MBRawParserResult nativeResult;

        internal RawParserResult(MBRawParserResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string RawText => nativeResult.RawText;
    }
}
using Microblink.Forms.iOS.Parsers;
using Microblink.Forms.Core.Parsers;
using Microblink;

namespace Microblink.Forms.iOS.Parsers
{
    public abstract class Parser : IParser
    {
        public MBParser NativeParser { get; }
        public abstract IParserResult BaseResult { get; }
        public bool Required { get; set; }

        protected Parser(MBParser nativeParser)
        {
            NativeParser = nativeParser;
        }
    }

    public abstract class ParserResult : IParserResult
    {
        public MBParserResult NativeResult { get; }

        protected ParserResult(MBParserResult nativeResult)
        {
            NativeResult = nativeResult;
        }

        public ParserResultState ResultState => (ParserResultState)NativeResult.ResultState;
    }
}

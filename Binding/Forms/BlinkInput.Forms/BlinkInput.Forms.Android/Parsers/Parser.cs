using System;
using Microblink.Forms.Droid.Parsers;
using Microblink.Forms.Core.Parsers;

namespace Microblink.Forms.Droid.Parsers
{
    public abstract class Parser : IParser
    {
        public Com.Microblink.Entities.Parsers.Parser NativeParser { get; }
        public abstract IParserResult BaseResult { get; }

        protected Parser(Com.Microblink.Entities.Parsers.Parser nativeParser)
        {
            NativeParser = nativeParser;
        }

        public bool Required
        {
            get => NativeParser.Required;
            set => NativeParser.Required = value;
        }
    }

    public abstract class ParserResult : IParserResult
    {
        public Com.Microblink.Entities.Parsers.Parser.Result NativeResult { get; }

        protected ParserResult(Com.Microblink.Entities.Parsers.Parser.Result nativeResult)
        {
            NativeResult = nativeResult;
        }

        public ParserResultState ResultState => (ParserResultState)NativeResult.ResultState.Ordinal();
    }
}

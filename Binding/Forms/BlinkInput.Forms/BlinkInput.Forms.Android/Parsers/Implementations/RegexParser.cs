using Microblink.Forms.Core.Parsers;
using Microblink.Forms.Droid.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(RegexParserFactory))]
namespace Microblink.Forms.Droid.Parsers
{
    public sealed class RegexParser : Parser, IRegexParser
    {
        Com.Microblink.Entities.Parsers.Regex.RegexParser nativeParser;
        readonly RegexParserResult result;

        public RegexParser(string regex)
            : base(new Com.Microblink.Entities.Parsers.Regex.RegexParser(regex))
        {
            nativeParser = NativeParser as Com.Microblink.Entities.Parsers.Regex.RegexParser;
            result = new RegexParserResult(nativeParser.GetResult() as Com.Microblink.Entities.Parsers.Regex.RegexParser.Result);
        }

        public override IParserResult BaseResult => result;

        public string Regex
        {
            get => nativeParser.Regex;
            set => nativeParser.Regex = value;
        }

        public bool UseSieve
        {
            get => nativeParser.ShouldUseSieve();
            set => nativeParser.SetUseSieve(value);
        }

        public bool StartWithWhitespace
        {
            get => nativeParser.ShouldStartWithWhitespace();
            set => nativeParser.SetStartWithWhitespace(value);
        }

        public bool EndWithWhitespace
        {
            get => nativeParser.ShouldEndWithWhitespace();
            set => nativeParser.SetEndWithWhitespace(value);
        }

        public IRegexParserResult Result => result;
    }

    public sealed class RegexParserResult : ParserResult, IRegexParserResult
    {
        readonly Com.Microblink.Entities.Parsers.Regex.RegexParser.Result nativeResult;

        internal RegexParserResult(Com.Microblink.Entities.Parsers.Regex.RegexParser.Result nativeResult)
            : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }

        public string ParsedString => nativeResult.ParsedString;
    }

    public class RegexParserFactory : IRegexParserFactory
    {
        public IRegexParser CreateRegexParser(string regex)
        {
            return new RegexParser(regex);
        }
    }
}

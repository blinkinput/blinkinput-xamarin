using Microblink.Forms.iOS.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(RegexParserFactory))]
namespace Microblink.Forms.iOS.Parsers
{
    public sealed class RegexParser : Parser, IRegexParser
    {
        MBRegexParser nativeParser;

        RegexParserResult result;

        public RegexParser(string regex) : base(new MBRegexParser(regex))
        {
            nativeParser = NativeParser as MBRegexParser;
            result = new RegexParserResult(nativeParser.Result);
        }

        public override IParserResult BaseResult => result;

        public IRegexParserResult Result => result;

        public string Regex 
        { 
            get => nativeParser.Regex; 
            set => nativeParser.Regex = value;
        }
        
        public bool UseSieve 
        { 
            get => nativeParser.UseSieve; 
            set => nativeParser.UseSieve = value;
        }
        
        public bool StartWithWhitespace 
        { 
            get => nativeParser.StartWithWhitespace; 
            set => nativeParser.StartWithWhitespace = value;
        }
        
        public bool EndWithWhitespace 
        { 
            get => nativeParser.EndWithWhitespace; 
            set => nativeParser.EndWithWhitespace = value;
        }
        
    }

    public sealed class RegexParserResult : ParserResult, IRegexParserResult
    {
        MBRegexParserResult nativeResult;

        internal RegexParserResult(MBRegexParserResult nativeResult) : base(nativeResult)
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
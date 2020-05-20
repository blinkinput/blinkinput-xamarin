using Microblink.Forms.iOS.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(EmailParser))]
namespace Microblink.Forms.iOS.Parsers
{
    public sealed class EmailParser : Parser, IEmailParser
    {
        MBEmailParser nativeParser;

        EmailParserResult result;

        public EmailParser() : base(new MBEmailParser())
        {
            nativeParser = NativeParser as MBEmailParser;
            result = new EmailParserResult(nativeParser.Result);
        }

        public override IParserResult BaseResult => result;

        public IEmailParserResult Result => result;

        
    }

    public sealed class EmailParserResult : ParserResult, IEmailParserResult
    {
        MBEmailParserResult nativeResult;

        internal EmailParserResult(MBEmailParserResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Email => nativeResult.Email;
    }
}
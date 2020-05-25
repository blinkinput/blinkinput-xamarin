using Microblink.Forms.Droid.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(EmailParser))]
namespace Microblink.Forms.Droid.Parsers
{
    public sealed class EmailParser : Parser, IEmailParser
    {
        Com.Microblink.Entities.Parsers.Email.EmailParser nativeParser;

        EmailParserResult result;

        public EmailParser() : base(new Com.Microblink.Entities.Parsers.Email.EmailParser())
        {
            nativeParser = NativeParser as Com.Microblink.Entities.Parsers.Email.EmailParser;
            result = new EmailParserResult(nativeParser.GetResult() as Com.Microblink.Entities.Parsers.Email.EmailParser.Result);
        }

        public override IParserResult BaseResult => result;

        public IEmailParserResult Result => result;

        
    }

    public sealed class EmailParserResult : ParserResult, IEmailParserResult
    {
        Com.Microblink.Entities.Parsers.Email.EmailParser.Result nativeResult;

        internal EmailParserResult(Com.Microblink.Entities.Parsers.Email.EmailParser.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Email => nativeResult.Email;
    }
}
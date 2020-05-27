using Microblink.Forms.iOS.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(DateParser))]
namespace Microblink.Forms.iOS.Parsers
{
    public sealed class DateParser : Parser, IDateParser
    {
        MBDateParser nativeParser;

        DateParserResult result;

        public DateParser() : base(new MBDateParser())
        {
            nativeParser = NativeParser as MBDateParser;
            result = new DateParserResult(nativeParser.Result);
        }

        public override IParserResult BaseResult => result;

        public IDateParserResult Result => result;

        
    }

    public sealed class DateParserResult : ParserResult, IDateParserResult
    {
        MBDateParserResult nativeResult;

        internal DateParserResult(MBDateParserResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate Date => nativeResult.Date != null ? new Date(nativeResult.Date) : null;
    }
}
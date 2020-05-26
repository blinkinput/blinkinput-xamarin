using Microblink.Forms.Droid.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(DateParser))]
namespace Microblink.Forms.Droid.Parsers
{
    public sealed class DateParser : Parser, IDateParser
    {
        Com.Microblink.Entities.Parsers.Date.DateParser nativeParser;

        DateParserResult result;

        public DateParser() : base(new Com.Microblink.Entities.Parsers.Date.DateParser())
        {
            nativeParser = NativeParser as Com.Microblink.Entities.Parsers.Date.DateParser;
            result = new DateParserResult(nativeParser.GetResult() as Com.Microblink.Entities.Parsers.Date.DateParser.Result);
        }

        public override IParserResult BaseResult => result;

        public IDateParserResult Result => result;

        
    }

    public sealed class DateParserResult : ParserResult, IDateParserResult
    {
        Com.Microblink.Entities.Parsers.Date.DateParser.Result nativeResult;

        internal DateParserResult(Com.Microblink.Entities.Parsers.Date.DateParser.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IDate Date => nativeResult.Date.Date != null ? new Date(nativeResult.Date.Date) : null;
    }
}
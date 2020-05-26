using Microblink.Forms.Droid.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(AmountParser))]
namespace Microblink.Forms.Droid.Parsers
{
    public sealed class AmountParser : Parser, IAmountParser
    {
        Com.Microblink.Entities.Parsers.Amount.AmountParser nativeParser;

        AmountParserResult result;

        public AmountParser() : base(new Com.Microblink.Entities.Parsers.Amount.AmountParser())
        {
            nativeParser = NativeParser as Com.Microblink.Entities.Parsers.Amount.AmountParser;
            result = new AmountParserResult(nativeParser.GetResult() as Com.Microblink.Entities.Parsers.Amount.AmountParser.Result);
        }

        public override IParserResult BaseResult => result;

        public IAmountParserResult Result => result;

        
        public bool AllowMissingDecimals
        {
            get => nativeParser.ShouldAllowMissingDecimals();
            set => nativeParser.SetAllowMissingDecimals(value);
        }
        
        public bool AllowNegativeAmounts
        {
            get => nativeParser.ShouldAllowNegativeAmounts();
            set => nativeParser.SetAllowNegativeAmounts(value);
        }
        
        public bool AllowSpaceSeparators
        {
            get => nativeParser.ShouldAllowSpaceSeparators();
            set => nativeParser.SetAllowSpaceSeparators(value);
        }
        
        public bool ArabicIndicMode
        {
            get => nativeParser.ArabicIndicMode;
            set => nativeParser.ArabicIndicMode = value;
        }
        
    }

    public sealed class AmountParserResult : ParserResult, IAmountParserResult
    {
        Com.Microblink.Entities.Parsers.Amount.AmountParser.Result nativeResult;

        internal AmountParserResult(Com.Microblink.Entities.Parsers.Amount.AmountParser.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Amount => nativeResult.Amount;
    }
}
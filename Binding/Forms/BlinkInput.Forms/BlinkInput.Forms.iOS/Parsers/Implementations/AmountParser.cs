using Microblink.Forms.iOS.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(AmountParser))]
namespace Microblink.Forms.iOS.Parsers
{
    public sealed class AmountParser : Parser, IAmountParser
    {
        MBAmountParser nativeParser;

        AmountParserResult result;

        public AmountParser() : base(new MBAmountParser())
        {
            nativeParser = NativeParser as MBAmountParser;
            result = new AmountParserResult(nativeParser.Result);
        }

        public override IParserResult BaseResult => result;

        public IAmountParserResult Result => result;

        
        public bool AllowMissingDecimals 
        { 
            get => nativeParser.AllowMissingDecimals; 
            set => nativeParser.AllowMissingDecimals = value;
        }
        
        public bool AllowNegativeAmounts 
        { 
            get => nativeParser.AllowNegativeAmounts; 
            set => nativeParser.AllowNegativeAmounts = value;
        }
        
        public bool AllowSpaceSeparators 
        { 
            get => nativeParser.AllowSpaceSeparators; 
            set => nativeParser.AllowSpaceSeparators = value;
        }
        
        public bool ArabicIndicMode 
        { 
            get => nativeParser.ArabicIndicMode; 
            set => nativeParser.ArabicIndicMode = value;
        }
        
    }

    public sealed class AmountParserResult : ParserResult, IAmountParserResult
    {
        MBAmountParserResult nativeResult;

        internal AmountParserResult(MBAmountParserResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Amount => nativeResult.Amount;
    }
}
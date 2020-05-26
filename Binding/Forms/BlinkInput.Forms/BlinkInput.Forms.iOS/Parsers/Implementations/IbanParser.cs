using Microblink.Forms.iOS.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(IbanParser))]
namespace Microblink.Forms.iOS.Parsers
{
    public sealed class IbanParser : Parser, IIbanParser
    {
        MBIbanParser nativeParser;

        IbanParserResult result;

        public IbanParser() : base(new MBIbanParser())
        {
            nativeParser = NativeParser as MBIbanParser;
            result = new IbanParserResult(nativeParser.Result);
        }

        public override IParserResult BaseResult => result;

        public IIbanParserResult Result => result;

        
        public bool AlwaysReturnPrefix 
        { 
            get => nativeParser.AlwaysReturnPrefix; 
            set => nativeParser.AlwaysReturnPrefix = value;
        }
        
    }

    public sealed class IbanParserResult : ParserResult, IIbanParserResult
    {
        MBIbanParserResult nativeResult;

        internal IbanParserResult(MBIbanParserResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Iban => nativeResult.Iban;
    }
}
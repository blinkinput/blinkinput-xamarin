using Microblink.Forms.Droid.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(IbanParser))]
namespace Microblink.Forms.Droid.Parsers
{
    public sealed class IbanParser : Parser, IIbanParser
    {
        Com.Microblink.Entities.Parsers.Iban.IbanParser nativeParser;

        IbanParserResult result;

        public IbanParser() : base(new Com.Microblink.Entities.Parsers.Iban.IbanParser())
        {
            nativeParser = NativeParser as Com.Microblink.Entities.Parsers.Iban.IbanParser;
            result = new IbanParserResult(nativeParser.GetResult() as Com.Microblink.Entities.Parsers.Iban.IbanParser.Result);
        }

        public override IParserResult BaseResult => result;

        public IIbanParserResult Result => result;

        
        public bool AlwaysReturnPrefix
        {
            get => nativeParser.ShouldAlwaysReturnPrefix();
            set => nativeParser.SetAlwaysReturnPrefix(value);
        }
        
    }

    public sealed class IbanParserResult : ParserResult, IIbanParserResult
    {
        Com.Microblink.Entities.Parsers.Iban.IbanParser.Result nativeResult;

        internal IbanParserResult(Com.Microblink.Entities.Parsers.Iban.IbanParser.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public string Iban => nativeResult.Iban;
    }
}
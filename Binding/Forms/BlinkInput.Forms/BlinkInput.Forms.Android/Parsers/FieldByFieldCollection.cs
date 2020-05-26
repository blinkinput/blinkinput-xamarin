using Microblink.Forms.Droid.Parsers;
using Microblink.Forms.Core.Parsers;
using Com.Microblink.Entities.Parsers;
using Com.Microblink.Entities.Parsers.Config.Fieldbyfield;
using NativeFieldByFieldElement = Com.Microblink.Entities.Parsers.Config.Fieldbyfield.FieldByFieldElement;
using NativeParser = Com.Microblink.Entities.Parsers.Parser;

[assembly: Xamarin.Forms.Dependency(typeof(FieldByFieldCollectionFactory))]
namespace Microblink.Forms.Droid.Parsers
{
    public class FieldByFieldCollection : IFieldByFieldCollection
    {
        public FieldByFieldBundle NativeFieldByFieldBundle { get; }

        IFieldByFieldElement[] fieldByFieldElements;

        public FieldByFieldCollection(IFieldByFieldElement[] fieldByFieldElements)
        {
            this.fieldByFieldElements = fieldByFieldElements;
            NativeFieldByFieldElement[] nativeElements = new NativeFieldByFieldElement[fieldByFieldElements.Length];
            for (int i = 0; i < fieldByFieldElements.Length; ++i)
            {
                IFieldByFieldElement element = fieldByFieldElements[i];
                NativeParser parser = (NativeParser)(element.Parser as Parser).NativeParser;
                NativeFieldByFieldElement nativeElement = new NativeFieldByFieldElement(element.LocalizedTitle, element.LocalizedTooltip, parser);
                nativeElements[i] = nativeElement;
            }
            NativeFieldByFieldBundle = new FieldByFieldBundle(nativeElements);
        }

        /// <summary>
        /// Gets the array of field by field objects that will be used for recognition.
        /// </summary>
        /// <value>The elements.</value>
        public IFieldByFieldElement[] FieldByFieldElements => fieldByFieldElements;
    }

    public class FieldByFieldCollectionFactory : IFieldByFieldCollectionFactory
    {
        public IFieldByFieldCollection CreateFieldByFieldCollection(params IFieldByFieldElement[] fieldByFieldElements)
        {
            return new FieldByFieldCollection(fieldByFieldElements);
        }
    }
}

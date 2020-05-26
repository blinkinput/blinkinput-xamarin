using System;
using Microblink.Forms.Core.Parsers;
using Microblink.Forms.iOS.Parsers;
using Microblink;

[assembly: Xamarin.Forms.Dependency(typeof(FieldByFieldCollectionFactory))]
namespace Microblink.Forms.iOS.Parsers
{
    /// <summary>
    /// A collection of field by field elementas objects.
    /// </summary>
    public sealed class FieldByFieldCollection : IFieldByFieldCollection
    {
        public MBScanElement[] NativeFieldByFieldCollection { get; }

        IFieldByFieldElement[] fieldByFieldElements;

        public FieldByFieldCollection(IFieldByFieldElement[] fieldByFieldElements)
        {
            this.fieldByFieldElements = fieldByFieldElements;

            MBScanElement[] nativeScanElements = new MBScanElement[fieldByFieldElements.Length];
            for (int i = 0; i < fieldByFieldElements.Length; ++i)
            {
                MBScanElement scanElement = new MBScanElement(fieldByFieldElements[i].Identifier, (MBParser)(fieldByFieldElements[i].Parser as Parser).NativeParser);
                scanElement.LocalizedTitle = fieldByFieldElements[i].LocalizedTitle;
                scanElement.LocalizedTooltip = fieldByFieldElements[i].LocalizedTooltip;

                nativeScanElements[i] = scanElement;
            }
            NativeFieldByFieldCollection = nativeScanElements;
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

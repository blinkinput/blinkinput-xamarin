using System;
using Microblink.Forms.Droid.Parsers;
using Microblink.Forms.Core.Parsers;

[assembly: Xamarin.Forms.Dependency(typeof(FieldByFieldElement))]
namespace Microblink.Forms.Droid.Parsers
{
    /// <summary>
    /// A field by field element
    /// </summary>
    public sealed class FieldByFieldElement: IFieldByFieldElement
    {

        public FieldByFieldElement()
        {
        }

        /// <summary>
        /// Unique name of the element
        /// </summary>
        /// <value>TUnique name of the element.</value>
        public string Identifier { get; set; }

        /// <summary>
        /// Gets the parser object used for Field by field element
        /// </summary>
        /// <value>Parser.</value>
        public IParser Parser { get; set; }

        /// <summary>
        /// Gets the element value after scanning is done.
        /// </summary>
        /// <value>Parser.</value>
        public string Value { get; set; }

        /// <summary>
        /// Localized title (used in the Pivot control)
        /// </summary>
        /// <value>ocalized title (used in the Pivot control).</value>
        public string LocalizedTitle { get; set; }

        /// <summary>
        /// Localized tooltip (used in the tooltip label above the viewfinder)
        /// </summary>
        /// <value>Localized tooltip (used in the tooltip label above the viewfinder).</value>
        public string LocalizedTooltip { get; set; }
    }
}

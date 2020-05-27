using System;
namespace Microblink.Forms.Core.Parsers
{
    /// <summary>
    /// A field by field element
    /// </summary>
    public interface IFieldByFieldElement
    {
        /// <summary>
        /// Unique name of the element
        /// </summary>
        /// <value>TUnique name of the element.</value>
        string Identifier { get; set; }

        /// <summary>
        /// Gets the parser object used for Field by field element
        /// </summary>
        /// <value>Parser.</value>
        IParser Parser { get; set; }

        /// <summary>
        /// Gets the element value after scanning is done.
        /// </summary>
        /// <value>Parser.</value>
        string Value { get; set; }

        /// <summary>
        /// ocalized title (used in the Pivot control)
        /// </summary>
        /// <value>ocalized title (used in the Pivot control).</value>
        string LocalizedTitle { get; set; }

        /// <summary>
        /// Localized tooltip (used in the tooltip label above the viewfinder)
        /// </summary>
        /// <value>Localized tooltip (used in the tooltip label above the viewfinder).</value>
        string LocalizedTooltip { get; set; }
    }
}

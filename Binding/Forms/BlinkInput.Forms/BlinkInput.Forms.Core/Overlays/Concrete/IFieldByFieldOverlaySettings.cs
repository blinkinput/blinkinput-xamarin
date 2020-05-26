using System;
using Microblink.Forms.Core.Parsers;

namespace Microblink.Forms.Core.Overlays
{
    /// <summary>
    /// Settings for field by field overlay, which is designed for parsing elements and guides
    /// the user through the scanning process.
    /// </summary>
    public interface IFieldByFieldOverlaySettings : IOverlaySettings
    {}

    /// <summary>
    /// Field by field overlay settings factory. Use this to create an instance of IFieldByFieldOverlaySettings.
    /// </summary>
    public interface IFieldByFieldOverlaySettingsFactory
    {
        /// <summary>
        /// Creates the field by field overlay settings using the provided field by field collection.
        /// </summary>
        /// <returns>The field by field overlay settings.</returns>
        /// <param name="fieldByFieldCollection">Wrapper around Field By Field elements that will be used
        /// for scanning. </param>
        IFieldByFieldOverlaySettings CreateFieldByFieldOverlaySettings(IFieldByFieldCollection fieldByFieldCollection);
    }
}

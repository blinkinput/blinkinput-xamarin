using Microblink.Forms.Droid.Overlays;
using Microblink.Forms.Droid.Parsers;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Parsers;
using Com.Microblink.Uisettings;

[assembly: Xamarin.Forms.Dependency(typeof(FieldByFieldOverlaySettingsFactory))]
namespace Microblink.Forms.Droid.Overlays
{
    public sealed class FieldByFieldOverlaySettings : OverlaySettings, IFieldByFieldOverlaySettings
    {
        public IFieldByFieldCollection FieldByFieldCollection { get; }

        public FieldByFieldOverlaySettings(IFieldByFieldCollection fieldByFieldCollection)
            : base(new FieldByFieldUISettings((fieldByFieldCollection as FieldByFieldCollection).NativeFieldByFieldBundle))
        {
            FieldByFieldCollection = fieldByFieldCollection;
        }
    }

    public sealed class FieldByFieldOverlaySettingsFactory : IFieldByFieldOverlaySettingsFactory
    {
        public IFieldByFieldOverlaySettings CreateFieldByFieldOverlaySettings(IFieldByFieldCollection fieldByFieldCollection)
        {
            return new FieldByFieldOverlaySettings(fieldByFieldCollection);
        }
    }
}

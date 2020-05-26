using Microblink.Forms.iOS.Overlays;
using Microblink.Forms.iOS.Parsers;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Parsers;
using Microblink;

[assembly: Xamarin.Forms.Dependency(typeof(FieldByFieldOverlaySettingsFactory))]
namespace Microblink.Forms.iOS.Overlays
{
    public sealed class FieldByFieldOverlaySettings : OverlaySettings, IFieldByFieldOverlaySettings
    {
        readonly MBFieldByFieldOverlaySettings nativeFieldByFieldOverlaySettings;
        public IFieldByFieldCollection FieldByFieldCollection { get; }

        // this ensures GC does not collect delegate proxy while it is used by ObjC
        FieldByFieldOverlayVCDelegate fieldByFieldOverlayVCDelegate;

        public FieldByFieldOverlaySettings(IFieldByFieldCollection fieldByFieldCollection)
            : base(new MBFieldByFieldOverlaySettings((fieldByFieldCollection as FieldByFieldCollection).NativeFieldByFieldCollection))
        {
            nativeFieldByFieldOverlaySettings = NativeOverlaySettings as MBFieldByFieldOverlaySettings;
            FieldByFieldCollection = fieldByFieldCollection;
        }

        public override MBOverlayViewController CreateOverlayViewController(IOverlayVCDelegate overlayVCDelegate)
        {
            fieldByFieldOverlayVCDelegate = new FieldByFieldOverlayVCDelegate(overlayVCDelegate);
            return new MBFieldByFieldOverlayViewController(nativeFieldByFieldOverlaySettings, fieldByFieldOverlayVCDelegate);
        }
    }

    public sealed class FieldByFieldOverlaySettingsFactory : IFieldByFieldOverlaySettingsFactory
    {
        public IFieldByFieldOverlaySettings CreateFieldByFieldOverlaySettings(IFieldByFieldCollection fieldByFieldCollection)
        {
            return new FieldByFieldOverlaySettings(fieldByFieldCollection);
        }
    }

    public sealed class FieldByFieldOverlayVCDelegate : MBFieldByFieldOverlayViewControllerDelegate
    {
        readonly IOverlayVCDelegate overlayVCDelegate;

        public FieldByFieldOverlayVCDelegate(IOverlayVCDelegate overlayVCDelegate)
        {
            this.overlayVCDelegate = overlayVCDelegate;
        }

		public override void FieldByFieldOverlayViewController(MBFieldByFieldOverlayViewController fieldByFieldOverlayViewController, MBScanElement[] scanElements)
		{
            overlayVCDelegate.ScanningFinishedWithFieldByFieldElements(fieldByFieldOverlayViewController, scanElements);
        }

		public override void FieldByFieldOverlayViewControllerWillClose(MBFieldByFieldOverlayViewController fieldByFieldOverlayViewController)
		{
            overlayVCDelegate.CloseButtonTapped(fieldByFieldOverlayViewController);
        }
    }
}

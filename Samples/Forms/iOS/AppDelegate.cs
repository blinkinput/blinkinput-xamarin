using Foundation;
using UIKit;

namespace BlinkInputFormsSample
{
	[Register ("AppDelegate")]
	public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
	{
		public override bool FinishedLaunching (UIApplication app, NSDictionary options)
		{
			global::Xamarin.Forms.Forms.Init ();

            Xamarin.Forms.DependencyService.Register<Microblink.Forms.iOS.MicroblinkScannerFactoryImplementation>();

			LoadApplication (new BlinkInputApp.App());

			return base.FinishedLaunching (app, options);
		}
	}
}


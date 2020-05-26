using Android.App;
using Android.Widget;
using Android.OS;
using Android.Content.PM;

using Android.Content;

using Com.Microblink.Entities.Recognizers;
using Com.Microblink.Util;
using Com.Microblink;
using Com.Microblink.Intent;
using Com.Microblink.Uisettings;
using Android.Runtime;

namespace Android
{
    [Activity(Label = "BlinkID Xamarin", MainLauncher = true, Icon = "@mipmap/icon", HardwareAccelerated = true)]
    public class MainActivity : Activity
    {
        const int ACTIVITY_REQUEST_ID = 101;

        // there are plenty of recognizers available - see Android documentation
        // for more information: https://github.com/BlinkInput/blinkinput-android/blob/master/README.md

        // RecognizerBundle is required for transferring recognizers via Intent to another activity
        // and for loading results from them back.
        RecognizerBundle recognizerBundle;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            RequestedOrientation = ScreenOrientation.Portrait;

            Button button = FindViewById<Button>(Resource.Id.startScanningButton);

            // Setup BlinkID before usage
            initBlinkId();

            // check if BlinkID is supported on current device. Device needs to have camera with autofocus.
            if (RecognizerCompatibility.GetRecognizerCompatibilityStatus(this) != RecognizerCompatibilityStatus.RecognizerSupported)
            {
                button.Enabled = false;
                Toast.MakeText(this, "BlinkInput is not supported!", ToastLength.Long).Show();
            }
            else
            {
                button.Click += delegate {
               
                };
            }
        }

        private void initBlinkId()
        {
            // set license key for Android with package name com.microblink.xamarin.blinkid
            MicroblinkSDK.SetLicenseKey("sRwAAAAhY29tLm1pY3JvYmxpbmsueGFtYXJpbi5ibGlua2lucHV0ThK1QiLOa807QbLl9G4mPnYyVPTqNfuyaNMdBIoTRcsTkOr5Ux+LoDeqv01e8bf5l7bJ8hJFzdofvTzI7ecVGK8p56s0T1CHIw9+AmSITaKxF15V8ID86o/P6JOWDsKaFwSTFwN0SBuBvXGs/cdR2t+jgxFCX7ZyIlg4fFuD82TP75dPVDIbcr16sEebYw==", this);

            // Since we plan to transfer large data between activities, we need to enable
            // PersistedOptimised intent data transfer mode.
            // for more information about transfer mode, check android documentation: https://github.com/blinkid/blinkid-android#-passing-recognizer-objects-between-activities
            MicroblinkSDK.IntentDataTransferMode = IntentDataTransferMode.PersistedOptimised;
        }

        protected override void OnActivityResult(int requestCode, [GeneratedEnum] Result resultCode, Intent data)
        {
            base.OnActivityResult(requestCode, resultCode, data);
            if (requestCode == ACTIVITY_REQUEST_ID && resultCode == Result.Ok)
            {

                // obtain image view that will display image of the document
                ImageView documentImageFrontView = this.FindViewById<ImageView>(Resource.Id.documentImageFrontView);
                ImageView documentImageBackView = this.FindViewById<ImageView>(Resource.Id.documentImageBackView);

                // unfortunately, C# does not support covariant return types, so binding
                // of AAR loses the return type of the Java's GetResult method. Therefore, a cast is required.
                // This is always a safe cast, since the original object in Java is of correct type - type
                // information was lost during conversion to C# due to https://github.com/xamarin/java.interop/pull/216
                //var blinkidResult = (BlinkIdCombinedRecognizer.Result)blinkidRecognizer.GetResult();
                // var mrtdResult = (MrtdRecognizer.Result)mrtdRecognizer.GetResult();


                var message = "";

                AlertDialog.Builder alert = new AlertDialog.Builder(this);
                alert.SetTitle("BlinkInput Results");
                alert.SetPositiveButton("OK", (senderAlert, args) => { });
                alert.SetMessage(message);
                alert.Show();
            }
        }
    }
}



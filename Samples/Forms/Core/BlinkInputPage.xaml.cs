using System;
using Microblink.Forms.Core;
using Microblink.Forms.Core.Overlays;
using Microblink.Forms.Core.Recognizers;
using Microblink.Forms.Core.Parsers;

using Xamarin.Forms;

namespace BlinkInputApp
{
    public partial class BlinkInputPage : ContentPage
    {
        /// <summary>
        /// Microblink scanner is used for scanning the identity documents.
        /// </summary>
        IMicroblinkScanner blinkInput;

        /// <summary>
        /// BlinkID Combined recognizer will be used for automatic detection and data extraction from the supported document.
        /// </summary>
        IFieldByFieldCollection fieldByFieldCollection;

        IFieldByFieldElement fieldByFieldElement;

        DocumentCaptureRecognizerWrapper documentCaptureRecognizerWrapper;

        /// <summary>
        /// USDL recognizer will be used for scanning barcode from back side of United States' driver's licenses.
        /// </summary>
        //IUsdlRecognizer usdlRecognizer;

        /// <summary>
        /// This success frame grabber recognizer will wrap usdlRecognizer and will contain camera frame of the moment
        /// when wrapped recognizer finished its recognition.
        /// </summary>
        //ISuccessFrameGrabberRecognizer usdlSuccessFrameGrabberRecognizer;

        public BlinkInputPage ()
        {
            InitializeComponent ();

            // before obtaining any of the recognizer's implementations from DependencyService, it is required
            // to obtain instance of IMicroblinkScanner and set the license key.
            // Failure to do so will crash your app.
            var microblinkFactory = DependencyService.Get<IMicroblinkScannerFactory>();

            // license keys are different for iOS and Android and depend on iOS bundleID/Android application ID
            // in your app, you may obtain the correct license key for your platform via DependencyService from
            // your Droid/iOS projects
            string licenseKey;

            // both these license keys are demo license keys for bundleID/applicationID com.microblink.xamarin.blinkinput
            if (Device.RuntimePlatform == Device.iOS)
            {
                licenseKey = "sRwAAAEhY29tLm1pY3JvYmxpbmsueGFtYXJpbi5ibGlua2lucHV0nQTDQAl4ZhU14Vz0g/pqe9DXYHPmVxK2PMxh1GVTtooenkkGwpeQQ0tQDzqAFbvKPCWrgivNeY7tRkq2IUOdnvrhaea5cfDCSazxegeLudGV/QvNcl5OCk+wupGwnzNtz3P8PVJ7q7TjXrF8skeRDWOowlsGCyHXCF3N3fCeA8mIq0nTXEYhD400l9bZPg==";
            }
            else
            {
                licenseKey = "sRwAAAAhY29tLm1pY3JvYmxpbmsueGFtYXJpbi5ibGlua2lucHV0ThK1QiLOa807QbLl9G4mPnYyVPTqNfuyaNMdBIoTRcsTkOr5Ux+LoDeqv01e8bf5l7bJ8hJFzdofvTzI7ecVGK8p56s0T1CHIw9+AmSITaKxF15V8ID86o/P6JOWDsKaFwSTFwN0SBuBvXGs/cdR2t+jgxFCX7ZyIlg4fFuD82TP75dPVDIbcr16sEebYw==";
            }

            // since DependencyService requires implementations to have default constructor, a factory is needed
            // to construct implementation of IMicroblinkScanner with given license key
            blinkInput = microblinkFactory.CreateMicroblinkScanner(licenseKey);

            // subscribe to scanning done message
            MessagingCenter.Subscribe<Messages.ScanningDoneMessage> (this, Messages.ScanningDoneMessageId, (sender) => {
                ImageSource faceImageSource = null;
                ImageSource fullDocumentFrontImageSource = null;
                ImageSource fullDocumentBackImageSource = null;
                ImageSource successFrameImageSource = null;

                string stringResult = "No valid results.";

                IFieldByFieldElement resultElement = null;

                // if user cancelled scanning, sender.ScanningCancelled will be true
                if (sender.ScanningCancelled)
                {
                    stringResult = "Scanning cancelled";
                }
                else
                {
					if (fieldByFieldCollection != null)
					{
                        resultElement = fieldByFieldCollection.FieldByFieldElements[0];
                        stringResult = "RESULT -> " + " " + "Identifier: " + resultElement.Identifier + " " + "Value: " + resultElement.Value;
                    }
					else
					{
                        fullDocumentFrontImageSource = documentCaptureRecognizerWrapper.DocumentCaptureRecognizer.Result.FullDocumentImage;
                        fullDocumentBackImageSource = documentCaptureRecognizerWrapper.CapturedFullImage;
                    }
                }

                // updating the UI must be performed on main thread
                Device.BeginInvokeOnMainThread (() => {
                    resultsEditor.Text = stringResult;
                    fullDocumentFrontImage.Source = fullDocumentFrontImageSource;
                    fullDocumentBackImage.Source = fullDocumentBackImageSource;
                    successScanImage.Source = successFrameImageSource;
                    faceImage.Source = faceImageSource;
                    fieldByFieldCollection = null;
                });

            });

        }

        /// <summary>
        /// Button click event handler that will start the scanning procedure.
        /// </summary>
        /// <param name="sender">Sender.</param>
        /// <param name="e">E.</param>
        void StartScan (object sender, EventArgs e)
        {
            var rawParser = DependencyService.Get<IRawParser>(DependencyFetchTarget.NewInstance);
            fieldByFieldElement = DependencyService.Get<IFieldByFieldElement>(DependencyFetchTarget.NewInstance);

            fieldByFieldElement.Identifier = "Raw";
            fieldByFieldElement.LocalizedTitle = "Raw Text";
            fieldByFieldElement.LocalizedTooltip = "Scan text";
            fieldByFieldElement.Parser = rawParser;

            // license keys must be set before creating Recognizer, othervise InvalidLicenseKeyException will be thrown
            // the following code creates and sets up implementation of MrtdRecognizer
            fieldByFieldCollection = DependencyService.Get<IFieldByFieldCollectionFactory>().CreateFieldByFieldCollection(fieldByFieldElement);

            // using recognizerCollection, create overlay settings that will define the UI that will be used
            // there are several available overlay settings classes in Microblink.Forms.Core.Overlays namespace
            // document overlay settings is best for scanning identity documents
            var fieldByFieldOverlaySettings = DependencyService.Get<IFieldByFieldOverlaySettingsFactory>().CreateFieldByFieldOverlaySettings(fieldByFieldCollection);

            // start scanning
            blinkInput.Scan(fieldByFieldOverlaySettings);
        }

		void startDocumentCaptureButton_Clicked(System.Object sender, System.EventArgs e)
		{
            var documentCaptureRecognizer = DependencyService.Get<IDocumentCaptureRecognizer>(DependencyFetchTarget.NewInstance);

            documentCaptureRecognizerWrapper = new DocumentCaptureRecognizerWrapper(documentCaptureRecognizer);

            var documentCaptureOverlaySettings = DependencyService.Get<IDocumentCaptureOverlaySettingsFactory>().CreateDocumentCaptureOverlaySettings(documentCaptureRecognizerWrapper);
            blinkInput.Scan(documentCaptureOverlaySettings);
        }
	}
}


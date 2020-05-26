using Microblink.Forms.Droid.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(DocumentCaptureRecognizer))]
namespace Microblink.Forms.Droid.Recognizers
{
    public sealed class DocumentCaptureRecognizer : Recognizer, IDocumentCaptureRecognizer
    {
        Com.Microblink.Entities.Recognizers.Blinkinput.Documentcapture.DocumentCaptureRecognizer nativeRecognizer;

        DocumentCaptureRecognizerResult result;

        public DocumentCaptureRecognizer() : base(new Com.Microblink.Entities.Recognizers.Blinkinput.Documentcapture.DocumentCaptureRecognizer())
        {
            nativeRecognizer = NativeRecognizer as Com.Microblink.Entities.Recognizers.Blinkinput.Documentcapture.DocumentCaptureRecognizer;
            result = new DocumentCaptureRecognizerResult(nativeRecognizer.GetResult() as Com.Microblink.Entities.Recognizers.Blinkinput.Documentcapture.DocumentCaptureRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IDocumentCaptureRecognizerResult Result => result;

        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeImageExtensionFactors;
        }
        
        public float MinDocumentScale 
        { 
            get => nativeRecognizer.MinDocumentScale; 
            set => nativeRecognizer.MinDocumentScale = value;
        }
        
        public uint NumStableDetectionsThreshold 
        { 
            get => (uint)nativeRecognizer.NumStableDetectionsThreshold; 
            set => nativeRecognizer.NumStableDetectionsThreshold = (int)value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ShouldReturnFullDocumentImage(); 
            set => nativeRecognizer.SetReturnFullDocumentImage(value);
        }
        
    }

    public sealed class DocumentCaptureRecognizerResult : RecognizerResult, IDocumentCaptureRecognizerResult
    {
        Com.Microblink.Entities.Recognizers.Blinkinput.Documentcapture.DocumentCaptureRecognizer.Result nativeResult;

        internal DocumentCaptureRecognizerResult(Com.Microblink.Entities.Recognizers.Blinkinput.Documentcapture.DocumentCaptureRecognizer.Result nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IQuadrilateral DetectionLocation => nativeResult.DetectionLocation != null ? new Quadrilateral(nativeResult.DetectionLocation) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertAndroidBitmap(nativeResult.FullDocumentImage.ConvertToBitmap()) : null;
    }
}
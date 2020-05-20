using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;

[assembly: Xamarin.Forms.Dependency(typeof(DocumentCaptureRecognizer))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class DocumentCaptureRecognizer : Recognizer, IDocumentCaptureRecognizer
    {
        MBDocumentCaptureRecognizer nativeRecognizer;

        DocumentCaptureRecognizerResult result;

        public DocumentCaptureRecognizer() : base(new MBDocumentCaptureRecognizer())
        {
            nativeRecognizer = NativeRecognizer as MBDocumentCaptureRecognizer;
            result = new DocumentCaptureRecognizerResult(nativeRecognizer.Result);
        }

        public override IRecognizerResult BaseResult => result;

        public IDocumentCaptureRecognizerResult Result => result;

        
        public IImageExtensionFactors FullDocumentImageExtensionFactors 
        { 
            get => new ImageExtensionFactors(nativeRecognizer.FullDocumentImageExtensionFactors); 
            set => nativeRecognizer.FullDocumentImageExtensionFactors = (value as ImageExtensionFactors).NativeFactors;
        }
        
        public float MinDocumentScale 
        { 
            get => (float)nativeRecognizer.MinDocumentScale; 
            set => nativeRecognizer.MinDocumentScale = value;
        }
        
        public uint NumStableDetectionsThreshold 
        { 
            get => (uint)nativeRecognizer.NumStableDetectionsThreshold; 
            set => nativeRecognizer.NumStableDetectionsThreshold = value;
        }
        
        public bool ReturnFullDocumentImage 
        { 
            get => nativeRecognizer.ReturnFullDocumentImage; 
            set => nativeRecognizer.ReturnFullDocumentImage = value;
        }
        
    }

    public sealed class DocumentCaptureRecognizerResult : RecognizerResult, IDocumentCaptureRecognizerResult
    {
        MBDocumentCaptureRecognizerResult nativeResult;

        internal DocumentCaptureRecognizerResult(MBDocumentCaptureRecognizerResult nativeResult) : base(nativeResult)
        {
            this.nativeResult = nativeResult;
        }
        public IQuadrilateral DetectionLocation => nativeResult.DetectionLocation != null ? new Quadrilateral(nativeResult.DetectionLocation) : null;
        public Xamarin.Forms.ImageSource FullDocumentImage => nativeResult.FullDocumentImage != null ? Utils.ConvertUIImage(nativeResult.FullDocumentImage.Image) : null;
    }
}
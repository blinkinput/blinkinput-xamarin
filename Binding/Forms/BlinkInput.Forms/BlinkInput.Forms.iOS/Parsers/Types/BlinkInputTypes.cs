using Microblink.Forms.iOS.Recognizers;
using Microblink.Forms.Core.Recognizers;
using Microblink;

[assembly: Xamarin.Forms.Dependency(typeof(ImageExtensionFactorsFactory))]
namespace Microblink.Forms.iOS.Recognizers
{
    public sealed class ImageExtensionFactors : IImageExtensionFactors
    {
        public MBImageExtensionFactors NativeFactors { get; }

        public ImageExtensionFactors(MBImageExtensionFactors nativeFactors)
        {
            NativeFactors = nativeFactors;
        }

        public float UpFactor => (float)NativeFactors.top;
        public float RightFactor => (float)NativeFactors.right;
        public float DownFactor => (float)NativeFactors.bottom;
        public float LeftFactor => (float)NativeFactors.left;
    }

    public sealed class ImageExtensionFactorsFactory : IImageExtensionFactorsFactory
    {
        public IImageExtensionFactors CreateImageExtensionFactors(float upFactor = 0, float downFactor = 0, float leftFactor = 0, float rightFactor = 0)
        {
            return new ImageExtensionFactors(new MBImageExtensionFactors { top = upFactor, bottom = downFactor, left = leftFactor, right = rightFactor });
        }
    }
}

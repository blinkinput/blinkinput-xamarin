using System;
namespace Microblink.Forms.Core.Recognizers
{
    public interface IImageExtensionFactors
    {
        /// <summary>
        /// Gets the image extension factor relative to full image height in UP direction.
        /// </summary>
        /// <value>Up factor.</value>
        float UpFactor { get; }

        /// <summary>
        /// Gets the image extension factor relative to full image height in RIGHT direction..
        /// </summary>
        /// <value>The right factor.</value>
        float RightFactor { get; }

        /// <summary>
        /// Gets image extension factor relative to full image height in DOWN direction.
        /// </summary>
        /// <value>Down factor.</value>
        float DownFactor { get; }

        /// <summary>
        /// Gets the image extension factor relative to full image height in LEFT direction.
        /// </summary>
        /// <value>The left factor.</value>
        float LeftFactor { get; }
    }

    /// <summary>
    /// Image extension factors factory. Use this to create an instance of IImageExtensionFactors.
    /// </summary>
    public interface IImageExtensionFactorsFactory
    {
        /// <summary>
        /// Creates the image extension factors.
        /// </summary>
        /// <returns>The image extension factors.</returns>
        /// <param name="upFactor">image extension factor relative to full image height in UP direction</param>
        /// <param name="downFactor">image extension factor relative to full image height in DOWN direction</param>
        /// <param name="leftFactor">image extension factor relative to full image width in LEFT direction</param>
        /// <param name="rightFactor">image extension factor relative to full image width in RIGHT direction</param>
        IImageExtensionFactors CreateImageExtensionFactors(float upFactor = 0.0f, float downFactor = 0.0f, float leftFactor = 0.0f, float rightFactor = 0.0f);
    }
}

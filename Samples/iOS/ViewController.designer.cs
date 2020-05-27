// WARNING
//
// This file has been generated automatically by Visual Studio from the outlets and
// actions declared in your storyboard file.
// Manual changes to this file will not be maintained.
//
using Foundation;
using System;
using System.CodeDom.Compiler;
using UIKit;

namespace iOS
{
    [Register ("ViewController")]
    partial class ViewController
    {
        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView highResImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIImageView metadataImageView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UITextView metadataTextView { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton startDocumentCaptureButton { get; set; }

        [Outlet]
        [GeneratedCode ("iOS Designer", "1.0")]
        UIKit.UIButton startScanningButton { get; set; }

        [Action ("StartDocumentCaptureButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void StartDocumentCaptureButton_TouchUpInside (UIKit.UIButton sender);

        [Action ("StartScanningButton_TouchUpInside:")]
        [GeneratedCode ("iOS Designer", "1.0")]
        partial void StartScanningButton_TouchUpInside (UIKit.UIButton sender);

        void ReleaseDesignerOutlets ()
        {
            if (highResImageView != null) {
                highResImageView.Dispose ();
                highResImageView = null;
            }

            if (metadataImageView != null) {
                metadataImageView.Dispose ();
                metadataImageView = null;
            }

            if (metadataTextView != null) {
                metadataTextView.Dispose ();
                metadataTextView = null;
            }

            if (startDocumentCaptureButton != null) {
                startDocumentCaptureButton.Dispose ();
                startDocumentCaptureButton = null;
            }

            if (startScanningButton != null) {
                startScanningButton.Dispose ();
                startScanningButton = null;
            }
        }
    }
}
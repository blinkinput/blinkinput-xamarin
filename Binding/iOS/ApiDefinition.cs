using System;
using AVFoundation;
using CoreAnimation;
using CoreGraphics;
using CoreMedia;
using Foundation;
using ObjCRuntime;
using UIKit;
using Microblink;
using System.Runtime.InteropServices;

namespace Microblink
{
    // @interface MBMicroblinkApp : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBMicroblinkApp
    {
        // @property (nonatomic) NSString * language;
        [Export("language")]
        string Language { get; set; }

        // @property (nonatomic) NSBundle * resourcesBundle;
        [Export("resourcesBundle", ArgumentSemantic.Assign)]
        NSBundle ResourcesBundle { get; set; }

        // +(instancetype)instance;
        [Static]
        [Export("instance")]
        MBMicroblinkApp Instance { get; }

        // -(void)setDefaultLanguage;
        [Export("setDefaultLanguage")]
        void SetDefaultLanguage();

        // -(void)pushStatusBarStyle:(UIStatusBarStyle)statusBarStyle;
        [Export("pushStatusBarStyle:")]
        void PushStatusBarStyle(UIStatusBarStyle statusBarStyle);

        // -(void)popStatusBarStyle;
        [Export("popStatusBarStyle")]
        void PopStatusBarStyle();

        // -(void)pushStatusBarHidden:(BOOL)hidden;
        [Export("pushStatusBarHidden:")]
        void PushStatusBarHidden(bool hidden);

        // -(void)popStatusBarHidden;
        [Export("popStatusBarHidden")]
        void PopStatusBarHidden();

        // -(void)setHelpShown:(BOOL)value;
        [Export("setHelpShown:")]
        void SetHelpShown(bool value);

        // -(BOOL)isHelpShown;
        [Export("isHelpShown")]
        bool IsHelpShown { get; }

        // +(NSBundle *)verifyAndGetDefaultResourcesBundle;
        [Static]
        [Export("verifyAndGetDefaultResourcesBundle")]
        NSBundle VerifyAndGetDefaultResourcesBundle();
    }

    interface IMBRecognizerRunnerViewController {}

    // @protocol MBRecognizerRunnerViewController <NSObject>
    [Protocol, Model]
    [BaseType (typeof(NSObject))]
    interface MBRecognizerRunnerViewController
    {
        // @required @property (nonatomic) BOOL autorotate;
        [Abstract]
        [Export ("autorotate")]
        bool Autorotate { get; set; }

        // @required @property (nonatomic) UIInterfaceOrientationMask supportedOrientations;
        [Abstract]
        [Export ("supportedOrientations", ArgumentSemantic.Assign)]
        UIInterfaceOrientationMask SupportedOrientations { get; set; }

        // @required -(void)pauseScanning;
        [Abstract]
        [Export ("pauseScanning")]
        void PauseScanning ();

        // @required -(BOOL)isScanningPaused;
        [Abstract]
        [Export ("isScanningPaused")]
        bool IsScanningPaused { get; }

        // @required -(void)resumeScanningAndResetState:(BOOL)resetState;
        [Abstract]
        [Export ("resumeScanningAndResetState:")]
        void ResumeScanningAndResetState (bool resetState);

        // @required -(BOOL)resumeCamera;
        [Abstract]
        [Export ("resumeCamera")]
        bool ResumeCamera { get; }

        // @required -(BOOL)pauseCamera;
        [Abstract]
        [Export ("pauseCamera")]
        bool PauseCamera { get; }

        // @required -(BOOL)isCameraPaused;
        [Abstract]
        [Export ("isCameraPaused")]
        bool IsCameraPaused { get; }

        // @required -(void)playScanSuccessSound;
        [Abstract]
        [Export ("playScanSuccessSound")]
        void PlayScanSuccessSound ();

        // @required -(void)willSetTorchOn:(BOOL)torchOn;
        [Abstract]
        [Export ("willSetTorchOn:")]
        void WillSetTorchOn (bool torchOn);

        // @required -(void)resetState;
        [Abstract]
        [Export ("resetState")]
        void ResetState ();

        // @required -(void)captureHighResImage:(MBCaptureHighResImage _Nonnull)highResoulutionImageCaptured;
        [Abstract]
        [Export ("captureHighResImage:")]
        void CaptureHighResImage (MBCaptureHighResImage highResoulutionImageCaptured);
    }

    // typedef void (^MBCaptureHighResImage)(MBImage * _Nullable);
    delegate void MBCaptureHighResImage ([NullAllowed] MBImage arg0);

    // @protocol MBOverlayContainerViewController <MBRecognizerRunnerViewController>
    [Protocol]
    interface MBOverlayContainerViewController : MBRecognizerRunnerViewController
    {
        // @required -(void)overlayViewControllerWillCloseCamera:(MBOverlayViewController *)overlayViewController;
        [Abstract]
        [Export("overlayViewControllerWillCloseCamera:")]
        void OverlayViewControllerWillCloseCamera(MBOverlayViewController overlayViewController);

        // @required -(BOOL)overlayViewControllerShouldDisplayTorch:(MBOverlayViewController *)overlayViewController;
        [Abstract]
        [Export("overlayViewControllerShouldDisplayTorch:")]
        bool OverlayViewControllerShouldDisplayTorch(MBOverlayViewController overlayViewController);

        // @required -(BOOL)overlayViewController:(MBOverlayViewController *)overlayViewController willSetTorch:(BOOL)isTorchOn;
        [Abstract]
        [Export("overlayViewController:willSetTorch:")]
        bool OverlayViewController(MBOverlayViewController overlayViewController, bool isTorchOn);

        // @required -(BOOL)shouldDisplayHelpButton;
        [Abstract]
        [Export("shouldDisplayHelpButton")]
        bool ShouldDisplayHelpButton { get; }

        // @required -(BOOL)isStatusBarPresented;
        [Abstract]
        [Export("isStatusBarPresented")]
        bool IsStatusBarPresented { get; }

        // @required -(BOOL)isTorchOn;
        [Abstract]
        [Export("isTorchOn")]
        bool IsTorchOn { get; }

        // @required -(BOOL)isCameraAuthorized;
        [Abstract]
        [Export("isCameraAuthorized")]
        bool IsCameraAuthorized { get; }
    }

    interface IMBOverlayContainerViewController {}

    // @interface MBOverlayViewController : UIViewController
    
    [BaseType(typeof(UIViewController))]
    [DisableDefaultCtor]
    interface MBOverlayViewController
    {
        // @property (nonatomic, weak) UIViewController<MBOverlayContainerViewController> * _Nullable recognizerRunnerViewController;
        [NullAllowed, Export("recognizerRunnerViewController", ArgumentSemantic.Weak)]
        IMBOverlayContainerViewController RecognizerRunnerViewController { get; set; }

        // @property (nonatomic, strong) UIView * _Nullable cameraPausedView;
        [NullAllowed, Export("cameraPausedView", ArgumentSemantic.Strong)]
        UIView CameraPausedView { get; set; }
    }

    // @interface MBViewControllerFactory : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBViewControllerFactory
    {
        // +(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewControllerWithOverlayViewController:(MBOverlayViewController * _Nonnull)overlayViewController;
        [Static]
        [Export("recognizerRunnerViewControllerWithOverlayViewController:")]
        IMBRecognizerRunnerViewController RecognizerRunnerViewControllerWithOverlayViewController(MBOverlayViewController overlayViewController);
    }

    // @interface MBMicroblinkSDK : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBMicroblinkSDK
    {
        // +(instancetype _Nonnull)sharedInstance;
        [Static]
        [Export("sharedInstance")]
        MBMicroblinkSDK SharedInstance { get; }

        // @property (assign, nonatomic) BOOL showLicenseKeyTimeLimitedWarning;
        [Export("showLicenseKeyTimeLimitedWarning")]
        bool ShowLicenseKeyTimeLimitedWarning { get; set; }

        // @property (nonatomic, strong) NSBundle * _Nonnull resourcesBundle;
        [Export("resourcesBundle", ArgumentSemantic.Strong)]
        NSBundle ResourcesBundle { get; set; }

        // -(void)setLicenseBuffer:(NSData * _Nonnull)licenseBuffer;
        [Export("setLicenseBuffer:")]
        void SetLicenseBuffer(NSData licenseBuffer);

        // -(void)setLicenseBuffer:(NSData * _Nonnull)licenseBuffer andLicensee:(NSString * _Nonnull)licensee;
        [Export("setLicenseBuffer:andLicensee:")]
        void SetLicenseBuffer(NSData licenseBuffer, string licensee);

        // -(void)setLicenseKey:(NSString * _Nonnull)base64LicenseKey;
        [Export("setLicenseKey:")]
        void SetLicenseKey(string base64LicenseKey);

        // -(void)setLicenseKey:(NSString * _Nonnull)base64LicenseKey andLicensee:(NSString * _Nonnull)licensee;
        [Export("setLicenseKey:andLicensee:")]
        void SetLicenseKey(string base64LicenseKey, string licensee);

        // -(void)setLicenseResource:(NSString * _Nonnull)fileName withExtension:(NSString * _Nullable)extension inSubdirectory:(NSString * _Nullable)subdirectory forBundle:(NSBundle * _Nonnull)bundle;
        [Export("setLicenseResource:withExtension:inSubdirectory:forBundle:")]
        void SetLicenseResource(string fileName, [NullAllowed] string extension, [NullAllowed] string subdirectory, NSBundle bundle);

        // -(void)setLicenseResource:(NSString * _Nonnull)fileName withExtension:(NSString * _Nullable)extension inSubdirectory:(NSString * _Nullable)subdirectory forBundle:(NSBundle * _Nonnull)bundle andLicensee:(NSString * _Nonnull)licensee;
        [Export("setLicenseResource:withExtension:inSubdirectory:forBundle:andLicensee:")]
        void SetLicenseResource(string fileName, [NullAllowed] string extension, [NullAllowed] string subdirectory, NSBundle bundle, string licensee);

        // +(NSString * _Nonnull)buildVersionString;
        [Static]
        [Export("buildVersionString")]
        string BuildVersionString { get; }

        // +(BOOL)isScanningUnsupportedForCameraType:(MBCameraType)type error:(NSError * _Nullable * _Nullable)error;
        [Static]
        [Export("isScanningUnsupportedForCameraType:error:")]
        bool IsScanningUnsupportedForCameraType (MBCameraType type, [NullAllowed] out NSError error);
    }

    [Static]
    partial interface Constants
    {
        // extern const MBExceptionName MBIllegalModificationException;
        [Field("MBIllegalModificationException", "__Internal")]
        NSString MBIllegalModificationException { get; }

        // extern const MBExceptionName MBInvalidLicenseKeyException;
        [Field("MBInvalidLicenseKeyException", "__Internal")]
        NSString MBInvalidLicenseKeyException { get; }

        // extern const MBExceptionName MBInvalidLicenseeKeyException;
        [Field("MBInvalidLicenseeKeyException", "__Internal")]
        NSString MBInvalidLicenseeKeyException { get; }

        // extern const MBExceptionName MBInvalidLicenseResourceException;
        [Field("MBInvalidLicenseResourceException", "__Internal")]
        NSString MBInvalidLicenseResourceException { get; }

        // extern const MBExceptionName MBInvalidBundleException;
        [Field("MBInvalidBundleException", "__Internal")]
        NSString MBInvalidBundleException { get; }

        // extern const MBExceptionName MBMissingSettingsException;
        [Field("MBMissingSettingsException", "__Internal")]
        NSString MBMissingSettingsException { get; }

        // extern const MBExceptionName MBInvalidArgumentException;
        [Field("MBInvalidArgumentException", "__Internal")]
        NSString MBInvalidArgumentException { get; }
    }

    // @interface MBImage : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBImage
    {
        // @property (readonly, nonatomic) UIImage * _Nonnull image;
        [Export("image")]
        UIImage Image { get; }

        // @property (nonatomic) CGRect roi;
        [Export("roi", ArgumentSemantic.Assign)]
        CGRect Roi { get; set; }

        // @property (nonatomic) MBProcessingOrientation orientation;
        [Export("orientation", ArgumentSemantic.Assign)]
        MBProcessingOrientation Orientation { get; set; }

        // @property (nonatomic) BOOL mirroredHorizontally;
        [Export("mirroredHorizontally")]
        bool MirroredHorizontally { get; set; }

        // @property (nonatomic) BOOL mirroredVertically;
        [Export("mirroredVertically")]
        bool MirroredVertically { get; set; }

        // @property (nonatomic) BOOL estimateFrameQuality;
        [Export("estimateFrameQuality")]
        bool EstimateFrameQuality { get; set; }

        // @property (nonatomic) BOOL cameraFrame;
        [Export("cameraFrame")]
        bool CameraFrame { get; set; }

        // +(instancetype _Nonnull)imageWithUIImage:(UIImage * _Nonnull)image;
        [Static]
        [Export("imageWithUIImage:")]
        MBImage ImageWithUIImage(UIImage image);

        // +(instancetype _Nonnull)imageWithCmSampleBuffer:(CMSampleBufferRef _Nonnull)buffer;
        [Static]
        [Export("imageWithCmSampleBuffer:")]
        unsafe MBImage ImageWithCmSampleBuffer(CMSampleBuffer buffer);
    }

   // @interface MBCameraSettings : NSObject <NSCopying>
    [iOS (8,0)]
    [BaseType(typeof(NSObject))]
    interface MBCameraSettings : INSCopying
    {
        // @property (assign, nonatomic) MBCameraPreset cameraPreset;
        [Export("cameraPreset", ArgumentSemantic.Assign)]
        MBCameraPreset CameraPreset { get; set; }

        // @property (assign, nonatomic) MBCameraType cameraType;
        [Export("cameraType", ArgumentSemantic.Assign)]
        MBCameraType CameraType { get; set; }

        // @property (assign, nonatomic) NSTimeInterval autofocusInterval;
        [Export("autofocusInterval")]
        double AutofocusInterval { get; set; }

        // @property (assign, nonatomic) MBCameraAutofocusRestriction cameraAutofocusRestriction;
        [Export("cameraAutofocusRestriction", ArgumentSemantic.Assign)]
        MBCameraAutofocusRestriction CameraAutofocusRestriction { get; set; }

        // @property (nonatomic, weak) NSString * videoGravity;
        [Export("videoGravity", ArgumentSemantic.Weak)]
        string VideoGravity { get; set; }

        // @property (assign, nonatomic) CGPoint focusPoint;
        [Export("focusPoint", ArgumentSemantic.Assign)]
        CGPoint FocusPoint { get; set; }

        // @property (nonatomic) BOOL cameraMirroredHorizontally;
        [Export("cameraMirroredHorizontally")]
        bool CameraMirroredHorizontally { get; set; }

        // @property (nonatomic) BOOL cameraMirroredVertically;
        [Export("cameraMirroredVertically")]
        bool CameraMirroredVertically { get; set; }

        // -(NSString *)calcSessionPreset;
        [Export("calcSessionPreset")]
        string CalcSessionPreset { get; }

        // -(AVCaptureAutoFocusRangeRestriction)calcAutofocusRangeRestriction;
        [Export("calcAutofocusRangeRestriction")]
        AVCaptureAutoFocusRangeRestriction CalcAutofocusRangeRestriction { get; }
    }


    // @protocol MBDebugRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBDebugRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didOutputDebugImage:(MBImage * _Nonnull)image;
        [Abstract]
        [Export("recognizerRunnerViewController:didOutputDebugImage:")]
        void DidOutputDebugImage(IMBRecognizerRunnerViewController recognizerRunnerViewController, MBImage image);

        // @required -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didOutputDebugText:(NSString * _Nonnull)text;
        [Abstract]
        [Export("recognizerRunnerViewController:didOutputDebugText:")]
        void DidOutputDebugText(IMBRecognizerRunnerViewController recognizerRunnerViewController, string text);
    }

    // @protocol MBDetectionRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBDetectionRecognizerRunnerViewControllerDelegate
    {
        // @optional -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFinishDetectionWithDisplayableQuad:(MBDisplayableQuadDetection * _Nonnull)displayableQuad;
        [Export("recognizerRunnerViewController:didFinishDetectionWithDisplayableQuad:")]
        void RecognizerRunnerViewController(IMBRecognizerRunnerViewController recognizerRunnerViewController, MBDisplayableQuadDetection displayableQuad);

        // @optional -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFinishDetectionWithDisplayablePoints:(MBDisplayablePointsDetection * _Nonnull)displayablePoints;
        [Export("recognizerRunnerViewController:didFinishDetectionWithDisplayablePoints:")]
        void RecognizerRunnerViewController(IMBRecognizerRunnerViewController recognizerRunnerViewController, MBDisplayablePointsDetection displayablePoints);

        // @optional -(void)recognizerRunnerViewControllerDidFailDetection:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Export("recognizerRunnerViewControllerDidFailDetection:")]
        void RecognizerRunnerViewControllerDidFailDetection(IMBRecognizerRunnerViewController recognizerRunnerViewController);
    }

    // @interface MBDewarpPolicy : NSObject
    [iOS (8,0)]
    [BaseType (typeof(NSObject))]
    interface MBDewarpPolicy
    {
    }

    // @interface MBFixedDewarpPolicy : MBDewarpPolicy
    [iOS (8,0)]
    [BaseType (typeof(MBDewarpPolicy))]
    interface MBFixedDewarpPolicy
    {
        // -(instancetype _Nonnull)initWithDewarpHeight:(NSUInteger)dewarpHeight __attribute__((objc_designated_initializer));
        [Export ("initWithDewarpHeight:")]
        [DesignatedInitializer]
        IntPtr Constructor (nuint dewarpHeight);

        // @property (readonly, assign, nonatomic) NSUInteger dewarpHeight;
        [Export ("dewarpHeight")]
        nuint DewarpHeight { get; }
    }

    // @interface MBDPIBasedDewarpPolicy : MBDewarpPolicy
    [iOS (8,0)]
    [BaseType (typeof(MBDewarpPolicy))]
    interface MBDPIBasedDewarpPolicy
    {
        // -(instancetype _Nonnull)initWithDesiredDPI:(NSUInteger)desiredDPI __attribute__((objc_designated_initializer));
        [Export ("initWithDesiredDPI:")]
        [DesignatedInitializer]
        IntPtr Constructor (nuint desiredDPI);

        // @property (readonly, assign, nonatomic) NSUInteger desiredDPI;
        [Export ("desiredDPI")]
        nuint DesiredDPI { get; }
    }

    // @interface MBNoUpScalingDewarpPolicy : MBDewarpPolicy
    [iOS (8,0)]
    [BaseType (typeof(MBDewarpPolicy))]
    interface MBNoUpScalingDewarpPolicy
    {
        // -(instancetype _Nonnull)initWithMaxAllowedDewarpHeight:(NSUInteger)maxAllowedDewarpHeight __attribute__((objc_designated_initializer));
        [Export ("initWithMaxAllowedDewarpHeight:")]
        [DesignatedInitializer]
        IntPtr Constructor (nuint maxAllowedDewarpHeight);

        // @property (readonly, assign, nonatomic) NSUInteger maxAllowedDewarpHeight;
        [Export ("maxAllowedDewarpHeight")]
        nuint MaxAllowedDewarpHeight { get; }
    }

    // @protocol MBOcrRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBOcrRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didObtainOcrResult:(MBOcrLayout * _Nonnull)ocrResult withResultName:(NSString * _Nonnull)resultName;
        [Abstract]
        [Export("recognizerRunnerViewController:didObtainOcrResult:withResultName:")]
        void DidObtainOcrResult(IMBRecognizerRunnerViewController recognizerRunnerViewController, MBOcrLayout ocrResult, string resultName);
    }

    // @protocol MBGlareRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBGlareRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFinishGlareDetectionWithResult:(BOOL)glareFound;
        [Abstract]
        [Export("recognizerRunnerViewController:didFinishGlareDetectionWithResult:")]
        void DidFinishGlareDetectionWithResult(IMBRecognizerRunnerViewController recognizerRunnerViewController, bool glareFound);
    }

    // @protocol MBFirstSideFinishedRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBFirstSideFinishedRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewControllerDidFinishRecognitionOfFirstSide:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerDidFinishRecognitionOfFirstSide:")]
        void RecognizerRunnerViewControllerDidFinishRecognitionOfFirstSide(IMBRecognizerRunnerViewController recognizerRunnerViewController);
    }

    // @interface MBRecognizerRunnerViewControllerMetadataDelegates : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBRecognizerRunnerViewControllerMetadataDelegates
    {
        [Wrap("WeakDebugRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBDebugRecognizerRunnerViewControllerDelegate DebugRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBDebugRecognizerRunnerViewControllerDelegate> _Nullable debugRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("debugRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakDebugRecognizerRunnerViewControllerDelegate { get; set; }

        [Wrap("WeakDetectionRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBDetectionRecognizerRunnerViewControllerDelegate DetectionRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBDetectionRecognizerRunnerViewControllerDelegate> _Nullable detectionRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("detectionRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakDetectionRecognizerRunnerViewControllerDelegate { get; set; }

        [Wrap("WeakOcrRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBOcrRecognizerRunnerViewControllerDelegate OcrRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBOcrRecognizerRunnerViewControllerDelegate> _Nullable ocrRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("ocrRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakOcrRecognizerRunnerViewControllerDelegate { get; set; }

        [Wrap("WeakGlareRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBGlareRecognizerRunnerViewControllerDelegate GlareRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBGlareRecognizerRunnerViewControllerDelegate> _Nullable glareRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("glareRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakGlareRecognizerRunnerViewControllerDelegate { get; set; }

        [Wrap("WeakFirstSideFinishedRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBFirstSideFinishedRecognizerRunnerViewControllerDelegate FirstSideFinishedRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBFirstSideFinishedRecognizerRunnerViewControllerDelegate> _Nullable firstSideFinishedRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("firstSideFinishedRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakFirstSideFinishedRecognizerRunnerViewControllerDelegate { get; set; }
    }

    // @protocol MBRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewControllerUnauthorizedCamera:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerUnauthorizedCamera:")]
        void RecognizerRunnerViewControllerUnauthorizedCamera(IMBRecognizerRunnerViewController recognizerRunnerViewController);

        // @required -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFindError:(NSError * _Nonnull)error;
        [Abstract]
        [Export("recognizerRunnerViewController:didFindError:")]
        void RecognizerRunnerViewController(IMBRecognizerRunnerViewController recognizerRunnerViewController, NSError error);

        // @required -(void)recognizerRunnerViewControllerDidClose:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerDidClose:")]
        void RecognizerRunnerViewControllerDidClose(IMBRecognizerRunnerViewController recognizerRunnerViewController);

        // @required -(void)recognizerRunnerViewControllerWillPresentHelp:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerWillPresentHelp:")]
        void RecognizerRunnerViewControllerWillPresentHelp(IMBRecognizerRunnerViewController recognizerRunnerViewController);

        // @required -(void)recognizerRunnerViewControllerDidResumeScanning:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerDidResumeScanning:")]
        void RecognizerRunnerViewControllerDidResumeScanning(IMBRecognizerRunnerViewController recognizerRunnerViewController);

        // @required -(void)recognizerRunnerViewControllerDidStopScanning:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController;
        [Abstract]
        [Export("recognizerRunnerViewControllerDidStopScanning:")]
        void RecognizerRunnerViewControllerDidStopScanning(IMBRecognizerRunnerViewController recognizerRunnerViewController);
    }

    // @interface MBRecognizerResult : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRecognizerResult
    {
        // @property (readonly, assign, nonatomic) MBRecognizerResultState resultState;
        [Export("resultState", ArgumentSemantic.Assign)]
        MBRecognizerResultState ResultState { get; }
    }

    // @protocol MBScanningRecognizerRunnerViewControllerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBScanningRecognizerRunnerViewControllerDelegate
    {
        // @required -(void)recognizerRunnerViewController:(UIViewController<MBRecognizerRunnerViewController> * _Nonnull)recognizerRunnerViewController didFinishScanningWithState:(MBRecognizerResultState)state;
        [Abstract]
        [Export("recognizerRunnerViewController:didFinishScanningWithState:")]
        void DidFinishScanningWithState(IMBRecognizerRunnerViewController recognizerRunnerViewController, MBRecognizerResultState state);
    }

    // @protocol MBDebugRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBDebugRecognizerRunnerDelegate
    {
        // @optional -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didOutputDebugImage:(MBImage * _Nonnull)image;
        [Export("recognizerRunner:didOutputDebugImage:")]
        void DidOutputDebugImage(MBRecognizerRunner recognizerRunner, MBImage image);

        // @optional -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didOutputDebugText:(NSString * _Nonnull)text;
        [Export("recognizerRunner:didOutputDebugText:")]
        void DidOutputDebugText(MBRecognizerRunner recognizerRunner, string text);
    }

    // @protocol MBDetectionRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBDetectionRecognizerRunnerDelegate
    {
        // @optional -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishDetectionWithDisplayableQuad:(MBDisplayableQuadDetection * _Nonnull)displayableQuad;
        [Export("recognizerRunner:didFinishDetectionWithDisplayableQuad:")]
        void RecognizerRunner(MBRecognizerRunner recognizerRunner, MBDisplayableQuadDetection displayableQuad);

        // @optional -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishDetectionWithDisplayablePoints:(MBDisplayablePointsDetection * _Nonnull)displayablePoints;
        [Export("recognizerRunner:didFinishDetectionWithDisplayablePoints:")]
        void RecognizerRunner(MBRecognizerRunner recognizerRunner, MBDisplayablePointsDetection displayablePoints);

        // @optional -(void)recognizerRunnerDidFailDetection:(MBRecognizerRunner * _Nonnull)recognizerRunner;
        [Export("recognizerRunnerDidFailDetection:")]
        void RecognizerRunnerDidFailDetection(MBRecognizerRunner recognizerRunner);
    }

    // @protocol MBOcrRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBOcrRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didObtainOcrResult:(MBOcrLayout * _Nonnull)ocrResult withResultName:(NSString * _Nonnull)resultName;
        [Abstract]
        [Export("recognizerRunner:didObtainOcrResult:withResultName:")]
        void DidObtainOcrResult(MBRecognizerRunner recognizerRunner, MBOcrLayout ocrResult, string resultName);
    }

    // @protocol MBGlareRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBGlareRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishGlareDetectionWithResult:(BOOL)glareFound;
        [Abstract]
        [Export("recognizerRunner:didFinishGlareDetectionWithResult:")]
        void DidFinishGlareDetectionWithResult(MBRecognizerRunner recognizerRunner, bool glareFound);
    }

    // @protocol MBFirstSideFinishedRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBFirstSideFinishedRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunnerDidFinishRecognitionOfFirstSide:(MBRecognizerRunner * _Nonnull)recognizerRunner;
        [Abstract]
        [Export("recognizerRunnerDidFinishRecognitionOfFirstSide:")]
        void RecognizerRunnerDidFinishRecognitionOfFirstSide(MBRecognizerRunner recognizerRunner);
    }

    // @interface MBRecognizerRunnerMetadataDelegates : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBRecognizerRunnerMetadataDelegates
    {
        [Wrap("WeakDebugRecognizerRunnerDelegate")]
        [NullAllowed]
        MBDebugRecognizerRunnerDelegate DebugRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBDebugRecognizerRunnerDelegate> _Nullable debugRecognizerRunnerDelegate;
        [NullAllowed, Export("debugRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakDebugRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakDetectionRecognizerRunnerDelegate")]
        [NullAllowed]
        MBDetectionRecognizerRunnerDelegate DetectionRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBDetectionRecognizerRunnerDelegate> _Nullable detectionRecognizerRunnerDelegate;
        [NullAllowed, Export("detectionRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakDetectionRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakOcrRecognizerRunnerDelegate")]
        [NullAllowed]
        MBOcrRecognizerRunnerDelegate OcrRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBOcrRecognizerRunnerDelegate> _Nullable ocrRecognizerRunnerDelegate;
        [NullAllowed, Export("ocrRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakOcrRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakGlareRecognizerRunnerDelegate")]
        [NullAllowed]
        MBGlareRecognizerRunnerDelegate GlareRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBGlareRecognizerRunnerDelegate> _Nullable glareRecognizerRunnerDelegate;
        [NullAllowed, Export("glareRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakGlareRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakFirstSideFinishedRecognizerRunnerDelegate")]
        [NullAllowed]
        MBFirstSideFinishedRecognizerRunnerDelegate FirstSideFinishedRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBFirstSideFinishedRecognizerRunnerDelegate> _Nullable firstSideFinishedRecognizerRunnerDelegate;
        [NullAllowed, Export("firstSideFinishedRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakFirstSideFinishedRecognizerRunnerDelegate { get; set; }
    }

    // @protocol MBScanningRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBScanningRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishScanningWithState:(MBRecognizerResultState)state;
        [Abstract]
        [Export("recognizerRunner:didFinishScanningWithState:")]
        void DidFinishScanningWithState(MBRecognizerRunner recognizerRunner, MBRecognizerResultState state);
    }

    // @protocol MBImageProcessingRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBImageProcessingRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishProcessingImage:(MBImage * _Nonnull)image;
        [Abstract]
        [Export("recognizerRunner:didFinishProcessingImage:")]
        void DidFinishProcessingImage(MBRecognizerRunner recognizerRunner, MBImage image);
    }

    // @protocol MBStringProcessingRecognizerRunnerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBStringProcessingRecognizerRunnerDelegate
    {
        // @required -(void)recognizerRunner:(MBRecognizerRunner * _Nonnull)recognizerRunner didFinishProcessingString:(NSString * _Nonnull)string;
        [Abstract]
        [Export("recognizerRunner:didFinishProcessingString:")]
        void DidFinishProcessingString(MBRecognizerRunner recognizerRunner, string @string);
    }

    // @interface MBRecognizerRunner : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBRecognizerRunner
    {
        // @property (readonly, nonatomic, strong) MBRecognizerRunnerMetadataDelegates * _Nonnull metadataDelegates;
        [Export("metadataDelegates", ArgumentSemantic.Strong)]
        MBRecognizerRunnerMetadataDelegates MetadataDelegates { get; }

        [Wrap("WeakScanningRecognizerRunnerDelegate")]
        [NullAllowed]
        MBScanningRecognizerRunnerDelegate ScanningRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBScanningRecognizerRunnerDelegate> _Nullable scanningRecognizerRunnerDelegate;
        [NullAllowed, Export("scanningRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakScanningRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakImageProcessingRecognizerRunnerDelegate")]
        [NullAllowed]
        MBImageProcessingRecognizerRunnerDelegate ImageProcessingRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBImageProcessingRecognizerRunnerDelegate> _Nullable imageProcessingRecognizerRunnerDelegate;
        [NullAllowed, Export("imageProcessingRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakImageProcessingRecognizerRunnerDelegate { get; set; }

        [Wrap("WeakStringProcessingRecognizerRunnerDelegate")]
        [NullAllowed]
        MBStringProcessingRecognizerRunnerDelegate StringProcessingRecognizerRunnerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBStringProcessingRecognizerRunnerDelegate> _Nullable stringProcessingRecognizerRunnerDelegate;
        [NullAllowed, Export("stringProcessingRecognizerRunnerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakStringProcessingRecognizerRunnerDelegate { get; set; }

        // -(instancetype _Nonnull)initWithRecognizerCollection:(MBRecognizerCollection * _Nonnull)recognizerCollection __attribute__((objc_designated_initializer));
        [Export("initWithRecognizerCollection:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRecognizerCollection recognizerCollection);

        // -(void)resetState;
        [Export("resetState")]
        void ResetState();

        // -(void)resetState:(BOOL)hard;
        [Export("resetState:")]
        void ResetState(bool hard);

        // -(void)cancelProcessing;
        [Export("cancelProcessing")]
        void CancelProcessing();

        // -(void)processImage:(MBImage * _Nonnull)image;
        [Export("processImage:")]
        void ProcessImage(MBImage image);

        // -(void)processString:(NSString * _Nonnull)string;
        [Export("processString:")]
        void ProcessString(string @string);

        // -(void)reconfigureRecognizers:(MBRecognizerCollection * _Nonnull)recognizerCollection;
        [Export("reconfigureRecognizers:")]
        void ReconfigureRecognizers(MBRecognizerCollection recognizerCollection);
    }

    // @interface MBEntity : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBEntity
    {
    }

    // @interface MBRecognizer : MBEntity
    
    [BaseType(typeof(MBEntity))]
    interface MBRecognizer
    {
        // @property (getter = isEnabled, nonatomic) BOOL enabled;
        [Export("enabled")]
        bool Enabled { [Bind("isEnabled")] get; set; }

        // @property (readonly, nonatomic, weak) MBRecognizerResult * _Nullable baseResult;
        [NullAllowed, Export("baseResult", ArgumentSemantic.Weak)]
        MBRecognizerResult BaseResult { get; }

        // -(UIInterfaceOrientationMask)getOptimalHudOrientation;
        [Export("getOptimalHudOrientation")]
        UIInterfaceOrientationMask OptimalHudOrientation { get; }
    }

    // @interface MBFrameGrabberRecognizer : MBRecognizer <NSCopying>
    
    [BaseType(typeof(MBRecognizer))]
    [DisableDefaultCtor]
    interface MBFrameGrabberRecognizer : INSCopying
    {
        // -(instancetype _Nonnull)initWithFrameGrabberDelegate:(id<MBFrameGrabberRecognizerDelegate> _Nonnull)frameGrabberDelegate;
        [Export("initWithFrameGrabberDelegate:")]
        IntPtr Constructor(MBFrameGrabberRecognizerDelegate frameGrabberDelegate);

        // @property (assign, nonatomic) BOOL grabFocusedFrames;
        [Export("grabFocusedFrames")]
        bool GrabFocusedFrames { get; set; }

        // @property (assign, nonatomic) BOOL grabUnfocusedFrames;
        [Export("grabUnfocusedFrames")]
        bool GrabUnfocusedFrames { get; set; }
    }

    // @protocol MBFrameGrabberRecognizerDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBFrameGrabberRecognizerDelegate
    {
        // @required -(void)onFrameAvailable:(MBImage * _Nonnull)cameraFrame isFocused:(BOOL)focused frameQuality:(CGFloat)frameQuality;
        [Abstract]
        [Export("onFrameAvailable:isFocused:frameQuality:")]
        void IsFocused(MBImage cameraFrame, bool focused, nfloat frameQuality);
    }

    // @interface MBSuccessFrameGrabberRecognizerResult : MBRecognizerResult <NSCopying>
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBSuccessFrameGrabberRecognizerResult : INSCopying
    {
        // @property (readonly, nonatomic, strong) MBImage * _Nonnull successFrame;
        [Export("successFrame", ArgumentSemantic.Strong)]
        MBImage SuccessFrame { get; }
    }

    // @interface MBSuccessFrameGrabberRecognizer : MBRecognizer <NSCopying>
    
    [BaseType(typeof(MBRecognizer))]
    [DisableDefaultCtor]
    interface MBSuccessFrameGrabberRecognizer : INSCopying
    {
        // -(instancetype _Nonnull)initWithRecognizer:(MBRecognizer * _Nonnull)recognizer __attribute__((objc_designated_initializer));
        [Export("initWithRecognizer:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRecognizer recognizer);

        // @property (readonly, nonatomic, strong) MBSuccessFrameGrabberRecognizerResult * _Nonnull result;
        [Export("result", ArgumentSemantic.Strong)]
        MBSuccessFrameGrabberRecognizerResult Result { get; }

        // @property (readonly, nonatomic, strong) MBRecognizer * _Nonnull slaveRecognizer;
        [Export("slaveRecognizer", ArgumentSemantic.Strong)]
        MBRecognizer SlaveRecognizer { get; }
    }

    // @interface MBQuadrangle : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBQuadrangle
    {
        // @property (assign, nonatomic) CGPoint upperLeft;
        [Export("upperLeft", ArgumentSemantic.Assign)]
        CGPoint UpperLeft { get; set; }

        // @property (assign, nonatomic) CGPoint upperRight;
        [Export("upperRight", ArgumentSemantic.Assign)]
        CGPoint UpperRight { get; set; }

        // @property (assign, nonatomic) CGPoint lowerLeft;
        [Export("lowerLeft", ArgumentSemantic.Assign)]
        CGPoint LowerLeft { get; set; }

        // @property (assign, nonatomic) CGPoint lowerRight;
        [Export("lowerRight", ArgumentSemantic.Assign)]
        CGPoint LowerRight { get; set; }

        // -(instancetype _Nonnull)initWithUpperLeft:(CGPoint)upperLeft upperRight:(CGPoint)upperRight lowerLeft:(CGPoint)lowerLeft lowerRight:(CGPoint)lowerRight;
        [Export("initWithUpperLeft:upperRight:lowerLeft:lowerRight:")]
        IntPtr Constructor(CGPoint upperLeft, CGPoint upperRight, CGPoint lowerLeft, CGPoint lowerRight);

        // -(NSArray * _Nonnull)toPointsArray;
        [Export("toPointsArray")]
        NSValue[] ToPointsArray { get; }

        // -(instancetype _Nonnull)quadrangleWithTransformation:(CGAffineTransform)transform;
        [Export("quadrangleWithTransformation:")]
        MBQuadrangle QuadrangleWithTransformation(CGAffineTransform transform);

        // -(CGPoint)center;
        [Export("center")]
        CGPoint Center { get; }
    }

    // @protocol MBNativeResult
    [Protocol]
    interface MBNativeResult
    {
        // @required -(NSObject * _Nullable)nativeResult;
        [Abstract]
        [NullAllowed, Export("nativeResult")]
        NSObject NativeResult { get; }

        // @required -(NSString * _Nullable)stringResult;
        [Abstract]
        [NullAllowed, Export("stringResult")]
        string StringResult { get; }
    }

    // @interface MBDateResult : NSObject <MBNativeResult>
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBDateResult : MBNativeResult
    {
        // -(instancetype _Nonnull)initWithDay:(NSInteger)day month:(NSInteger)month year:(NSInteger)year originalDateString:(NSString * _Nullable)originalDateString __attribute__((objc_designated_initializer));
        [Export("initWithDay:month:year:originalDateString:")]
        [DesignatedInitializer]
        IntPtr Constructor(nint day, nint month, nint year, [NullAllowed] string originalDateString);

        // @property (readonly, nonatomic) NSString * _Nullable originalDateString;
        [NullAllowed, Export("originalDateString")]
        string OriginalDateString { get; }

        // @property (readonly, nonatomic) NSDate * _Nonnull date;
        [Export("date")]
        NSDate Date { get; }

        // @property (readonly, assign, nonatomic) NSInteger day;
        [Export("day")]
        nint Day { get; }

        // @property (readonly, assign, nonatomic) NSInteger month;
        [Export("month")]
        nint Month { get; }

        // @property (readonly, assign, nonatomic) NSInteger year;
        [Export("year")]
        nint Year { get; }

        // +(instancetype _Nonnull)dateResultWithDay:(NSInteger)day month:(NSInteger)month year:(NSInteger)year originalDateString:(NSString * _Nullable)originalDateString;
        [Static]
        [Export("dateResultWithDay:month:year:originalDateString:")]
        MBDateResult DateResultWithDay(nint day, nint month, nint year, [NullAllowed] string originalDateString);
    }

    // @interface MBTemplatingClass : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBTemplatingClass
    {
        // -(void)setTemplatingClassifier:(id<MBTemplatingClassifier> _Nullable)templatingClassifier;
        [Export("setTemplatingClassifier:")]
        void SetTemplatingClassifier([NullAllowed] MBTemplatingClassifier templatingClassifier);
    }

    // @protocol MBTemplatingClassifier <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBTemplatingClassifier
    {
        // @required -(BOOL)classify;
        [Abstract]
        [Export("classify")]
        bool Classify();
    }

    // @interface MBTemplatingRecognizerResult : MBRecognizerResult
    
    [BaseType(typeof(MBRecognizerResult))]
    [DisableDefaultCtor]
    interface MBTemplatingRecognizerResult
    {
        // @property (readonly, nonatomic, strong) MBTemplatingClass * _Nullable templatingClass;
        [NullAllowed, Export("templatingClass", ArgumentSemantic.Strong)]
        MBTemplatingClass TemplatingClass { get; }
    }

    // @interface MBTemplatingRecognizer : MBRecognizer
    
    [BaseType(typeof(MBRecognizer))]
    [DisableDefaultCtor]
    interface MBTemplatingRecognizer
    {
        // @property (readonly, nonatomic, strong) MBTemplatingRecognizerResult * _Nonnull templatingResult;
        [Export("templatingResult", ArgumentSemantic.Strong)]
        MBTemplatingRecognizerResult TemplatingResult { get; }

        // @property (assign, nonatomic) BOOL useGlareDetector;
        [Export("useGlareDetector")]
        bool UseGlareDetector { get; set; }

        // @property (readonly, nonatomic, strong) NSArray<__kindof MBTemplatingClass *> * _Nullable templatingClasses;
        [NullAllowed, Export("templatingClasses", ArgumentSemantic.Strong)]
        MBTemplatingClass[] TemplatingClasses { get; }

        // -(void)setTemplatingClasses:(NSArray<__kindof MBTemplatingClass *> * _Nullable)templatingClasses;
        [Export("setTemplatingClasses:")]
        void SetTemplatingClasses([NullAllowed] MBTemplatingClass[] templatingClasses);
    }

    // @interface MBParserResult : NSObject
	[iOS (8,0)]
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBParserResult
	{
		// @property (readonly, assign, nonatomic) MBParserResultState resultState;
		[Export ("resultState", ArgumentSemantic.Assign)]
		MBParserResultState ResultState { get; }
	}

	// @interface MBParser : MBEntity
	[iOS (8,0)]
	[BaseType (typeof(MBEntity))]
	interface MBParser
	{
		// @property (readonly, nonatomic, weak) MBParserResult * _Nullable baseResult;
		[NullAllowed, Export ("baseResult", ArgumentSemantic.Weak)]
		MBParserResult BaseResult { get; }

		// @property (assign, nonatomic) BOOL required;
		[Export ("required")]
		bool Required { get; set; }
	}

	// @interface MBVinParserResult : MBParserResult <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParserResult))]
	[DisableDefaultCtor]
	interface MBVinParserResult : INSCopying
	{
		// @property (readonly, nonatomic, strong) NSString * _Nullable vin;
		[NullAllowed, Export ("vin", ArgumentSemantic.Strong)]
		string Vin { get; }
	}

	// @interface MBVinParser : MBParser <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParser))]
	interface MBVinParser : INSCopying
	{
		// @property (readonly, nonatomic, strong) MBVinParserResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBVinParserResult Result { get; }
	}

	// @interface MBTopUpParserResult : MBParserResult <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParserResult))]
	[DisableDefaultCtor]
	interface MBTopUpParserResult : INSCopying
	{
		// @property (readonly, nonatomic, strong) NSString * _Nullable topUp;
		[NullAllowed, Export ("topUp", ArgumentSemantic.Strong)]
		string TopUp { get; }
	}

	// @interface MBTopUpParser : MBParser <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParser))]
	interface MBTopUpParser : INSCopying
	{
		// @property (readonly, nonatomic, strong) MBTopUpParserResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBTopUpParserResult Result { get; }

		// @property (assign, nonatomic) BOOL allowNoPrefix;
		[Export ("allowNoPrefix")]
		bool AllowNoPrefix { get; set; }

		// @property (assign, nonatomic) BOOL returnCodeWithoutPrefix;
		[Export ("returnCodeWithoutPrefix")]
		bool ReturnCodeWithoutPrefix { get; set; }

		// -(void)setPrefix:(NSString * _Nonnull)prefix andUssdCodeLength:(NSInteger)ussdCodeLength;
		[Export ("setPrefix:andUssdCodeLength:")]
		void SetPrefix (string prefix, nint ussdCodeLength);
	}

	// @interface MBEmailParserResult : MBParserResult <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParserResult))]
	[DisableDefaultCtor]
	interface MBEmailParserResult : INSCopying
	{
		// @property (readonly, nonatomic, strong) NSString * _Nullable email;
		[NullAllowed, Export ("email", ArgumentSemantic.Strong)]
		string Email { get; }
	}

	// @interface MBEmailParser : MBParser <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParser))]
	interface MBEmailParser : INSCopying
	{
		// @property (readonly, nonatomic, strong) MBEmailParserResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBEmailParserResult Result { get; }
	}

	// @interface MBLicensePlatesParserResult : MBParserResult <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParserResult))]
	[DisableDefaultCtor]
	interface MBLicensePlatesParserResult : INSCopying
	{
		// @property (readonly, nonatomic, strong) NSString * _Nullable licensePlate;
		[NullAllowed, Export ("licensePlate", ArgumentSemantic.Strong)]
		string LicensePlate { get; }
	}

	// @interface MBLicensePlatesParser : MBParser <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParser))]
	interface MBLicensePlatesParser : INSCopying
	{
		// @property (readonly, nonatomic, strong) MBLicensePlatesParserResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBLicensePlatesParserResult Result { get; }
	}

	// @interface MBAmountParserResult : MBParserResult <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParserResult))]
	[DisableDefaultCtor]
	interface MBAmountParserResult : INSCopying
	{
		// @property (readonly, nonatomic, strong) NSString * _Nullable amount;
		[NullAllowed, Export ("amount", ArgumentSemantic.Strong)]
		string Amount { get; }
	}

	// @interface MBAmountParser : MBParser <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParser))]
	interface MBAmountParser : INSCopying
	{
		// @property (readonly, nonatomic, strong) MBAmountParserResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBAmountParserResult Result { get; }

		// @property (assign, nonatomic) BOOL allowNegativeAmounts;
		[Export ("allowNegativeAmounts")]
		bool AllowNegativeAmounts { get; set; }

		// @property (assign, nonatomic) BOOL allowSpaceSeparators;
		[Export ("allowSpaceSeparators")]
		bool AllowSpaceSeparators { get; set; }

		// @property (assign, nonatomic) BOOL allowMissingDecimals;
		[Export ("allowMissingDecimals")]
		bool AllowMissingDecimals { get; set; }

		// @property (assign, nonatomic) BOOL arabicIndicMode;
		[Export ("arabicIndicMode")]
		bool ArabicIndicMode { get; set; }
	}

	// @interface MBIbanParserResult : MBParserResult <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParserResult))]
	[DisableDefaultCtor]
	interface MBIbanParserResult : INSCopying
	{
		// @property (readonly, nonatomic, strong) NSString * _Nullable iban;
		[NullAllowed, Export ("iban", ArgumentSemantic.Strong)]
		string Iban { get; }
	}

	// @interface MBIbanParser : MBParser <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParser))]
	interface MBIbanParser : INSCopying
	{
		// @property (readonly, nonatomic, strong) MBIbanParserResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBIbanParserResult Result { get; }

		// @property (assign, nonatomic) BOOL alwaysReturnPrefix;
		[Export ("alwaysReturnPrefix")]
		bool AlwaysReturnPrefix { get; set; }

		// @property (nonatomic, strong) NSArray<NSString *> * _Nullable countryCodeWhitelist;
		[NullAllowed, Export ("countryCodeWhitelist", ArgumentSemantic.Strong)]
		string[] CountryCodeWhitelist { get; set; }
	}

	// @interface MBDateParserResult : MBParserResult <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParserResult))]
	[DisableDefaultCtor]
	interface MBDateParserResult : INSCopying
	{
		// @property (readonly, nonatomic, strong) MBDateResult * _Nonnull date;
		[Export ("date", ArgumentSemantic.Strong)]
		MBDateResult Date { get; }
	}

	// @interface MBDateParser : MBParser <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParser))]
	interface MBDateParser : INSCopying
	{
		// @property (readonly, nonatomic, strong) MBDateParserResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBDateParserResult Result { get; }

		// -(void)setDateFormats:(MBDateFormatArray * _Nonnull)dateFormats;
		[Export ("setDateFormats:")]
		void SetDateFormats (NSNumber[] dateFormats);

		// -(void)setDateSeparatorChars:(MBDateSeparatorCharsArray * _Nonnull)dateSeparatorChars;
		[Export ("setDateSeparatorChars:")]
		void SetDateSeparatorChars (string[] dateSeparatorChars);
	}

	// @interface MBVinRecognizerResult : MBRecognizerResult <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizerResult))]
	[DisableDefaultCtor]
	interface MBVinRecognizerResult : INSCopying
	{
		// @property (readonly, nonatomic, strong) NSString * _Nullable vin;
		[NullAllowed, Export ("vin", ArgumentSemantic.Strong)]
		string Vin { get; }
	}

	// @interface MBVinRecognizer : MBRecognizer <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizer))]
	interface MBVinRecognizer : INSCopying
	{
		// @property (readonly, nonatomic, strong) MBVinRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBVinRecognizerResult Result { get; }
	}

	// @interface MBRawParserResult : MBParserResult <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParserResult))]
	[DisableDefaultCtor]
	interface MBRawParserResult : INSCopying
	{
		// @property (readonly, nonatomic, strong) NSString * _Nonnull rawText;
		[Export ("rawText", ArgumentSemantic.Strong)]
		string RawText { get; }
	}

	// @interface MBBaseOcrEngineOptions : NSObject
	[iOS (8,0)]
	[BaseType (typeof(NSObject))]
	interface MBBaseOcrEngineOptions
	{
		// @property (assign, nonatomic) NSUInteger maxCharsExpected;
		[Export ("maxCharsExpected")]
		nuint MaxCharsExpected { get; set; }

		// @property (assign, nonatomic) BOOL colorDropoutEnabled;
		[Export ("colorDropoutEnabled")]
		bool ColorDropoutEnabled { get; set; }
	}

	// @interface MBRawParser : MBParser <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParser))]
	interface MBRawParser : INSCopying
	{
		// @property (readonly, nonatomic, strong) MBRawParserResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBRawParserResult Result { get; }

		// @property (assign, nonatomic) BOOL useSieve;
		[Export ("useSieve")]
		bool UseSieve { get; set; }

		// @property (nonatomic, strong) MBBaseOcrEngineOptions * _Nonnull ocrEngineOptions;
		[Export ("ocrEngineOptions", ArgumentSemantic.Strong)]
		MBBaseOcrEngineOptions OcrEngineOptions { get; set; }
	}

	// @interface MBRegexParserResult : MBParserResult <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParserResult))]
	[DisableDefaultCtor]
	interface MBRegexParserResult : INSCopying
	{
		// @property (readonly, nonatomic, strong) NSString * _Nonnull parsedString;
		[Export ("parsedString", ArgumentSemantic.Strong)]
		string ParsedString { get; }
	}

	// @interface MBRegexParser : MBParser <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBParser))]
	[DisableDefaultCtor]
	interface MBRegexParser : INSCopying
	{
		// -(instancetype _Nonnull)initWithRegex:(NSString * _Nonnull)regex __attribute__((objc_designated_initializer));
		[Export ("initWithRegex:")]
		[DesignatedInitializer]
		IntPtr Constructor (string regex);

		// @property (readonly, nonatomic, strong) MBRegexParserResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBRegexParserResult Result { get; }

		// @property (nonatomic, strong) NSString * _Nonnull regex;
		[Export ("regex", ArgumentSemantic.Strong)]
		string Regex { get; set; }

		// @property (assign, nonatomic) BOOL useSieve;
		[Export ("useSieve")]
		bool UseSieve { get; set; }

		// @property (assign, nonatomic) BOOL startWithWhitespace;
		[Export ("startWithWhitespace")]
		bool StartWithWhitespace { get; set; }

		// @property (assign, nonatomic) BOOL endWithWhitespace;
		[Export ("endWithWhitespace")]
		bool EndWithWhitespace { get; set; }

		// @property (nonatomic, strong) MBBaseOcrEngineOptions * _Nonnull ocrEngineOptions;
		[Export ("ocrEngineOptions", ArgumentSemantic.Strong)]
		MBBaseOcrEngineOptions OcrEngineOptions { get; set; }
	}

    	// @interface MBScanElement : NSObject
	[iOS (8,0)]
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBScanElement
	{
		// -(instancetype _Nonnull)initWithIdentifier:(NSString * _Nonnull)identifier parser:(MBParser * _Nonnull)parser __attribute__((objc_designated_initializer));
		[Export ("initWithIdentifier:parser:")]
		[DesignatedInitializer]
		IntPtr Constructor (string identifier, MBParser parser);

		// @property (readonly, nonatomic, strong) NSString * _Nonnull identifier;
		[Export ("identifier", ArgumentSemantic.Strong)]
		string Identifier { get; }

		// @property (readonly, nonatomic, strong) MBParser * _Nonnull parser;
		[Export ("parser", ArgumentSemantic.Strong)]
		MBParser Parser { get; }

		// @property (nonatomic, strong) NSString * _Nonnull localizedTitle;
		[Export ("localizedTitle", ArgumentSemantic.Strong)]
		string LocalizedTitle { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull localizedTooltip;
		[Export ("localizedTooltip", ArgumentSemantic.Strong)]
		string LocalizedTooltip { get; set; }

		// @property (assign, nonatomic) UIKeyboardType keyboardType;
		[Export ("keyboardType", ArgumentSemantic.Assign)]
		UIKeyboardType KeyboardType { get; set; }

		// @property (nonatomic) NSString * _Nonnull localizedTextfieldText;
		[Export ("localizedTextfieldText")]
		string LocalizedTextfieldText { get; set; }

		// @property (assign, nonatomic) BOOL scanned;
		[Export ("scanned")]
		bool Scanned { get; set; }

		// @property (assign, nonatomic) BOOL edited;
		[Export ("edited")]
		bool Edited { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull value;
		[Export ("value", ArgumentSemantic.Strong)]
		string Value { get; set; }

		// @property (nonatomic) float scanningRegionWidth;
		[Export ("scanningRegionWidth")]
		float ScanningRegionWidth { get; set; }

		// @property (nonatomic) float scanningRegionHeight;
		[Export ("scanningRegionHeight")]
		float ScanningRegionHeight { get; set; }

		// @property (nonatomic) MBImage * _Nonnull successfulScanImage;
		[Export ("successfulScanImage", ArgumentSemantic.Assign)]
		MBImage SuccessfulScanImage { get; set; }
	}

	// @interface MBFieldByFieldOverlaySettings : MBOverlaySettings
	[iOS (8,0)]
	[BaseType (typeof(MBOverlaySettings))]
	[DisableDefaultCtor]
	interface MBFieldByFieldOverlaySettings
	{
		// -(instancetype _Nonnull)initWithScanElements:(NSArray<MBScanElement *> * _Nonnull)scanElements __attribute__((objc_designated_initializer));
		[Export ("initWithScanElements:")]
		[DesignatedInitializer]
		IntPtr Constructor (MBScanElement[] scanElements);

		// @property (readonly, nonatomic, strong) NSArray<MBScanElement *> * _Nonnull scanElements;
		[Export ("scanElements", ArgumentSemantic.Strong)]
		MBScanElement[] ScanElements { get; }

		// @property (nonatomic) BOOL showOcrDots;
		[Export ("showOcrDots")]
		bool ShowOcrDots { get; set; }

		// @property (nonatomic) BOOL outputSuccessfulImages;
		[Export ("outputSuccessfulImages")]
		bool OutputSuccessfulImages { get; set; }

		// @property (nonatomic) NSUInteger consecutiveScanThreshold;
		[Export ("consecutiveScanThreshold")]
		nuint ConsecutiveScanThreshold { get; set; }

		// @property (nonatomic) UIColor * _Nonnull scanResultViewColor;
		[Export ("scanResultViewColor", ArgumentSemantic.Assign)]
		UIColor ScanResultViewColor { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull nextButtonDescriptionText;
		[Export ("nextButtonDescriptionText", ArgumentSemantic.Strong)]
		string NextButtonDescriptionText { get; set; }

		// @property (nonatomic, strong) NSString * _Nonnull nextButtonLastDescriptionText;
		[Export ("nextButtonLastDescriptionText", ArgumentSemantic.Strong)]
		string NextButtonLastDescriptionText { get; set; }
	}

	// @interface MBFieldByFieldOverlayViewController : MBOverlayViewController
	[iOS (8,0)]
	[BaseType (typeof(MBOverlayViewController))]
	[DisableDefaultCtor]
	interface MBFieldByFieldOverlayViewController
	{
		// -(instancetype _Nonnull)initWithSettings:(MBFieldByFieldOverlaySettings * _Nonnull)settings delegate:(id<MBFieldByFieldOverlayViewControllerDelegate> _Nonnull)delegate __attribute__((objc_designated_initializer));
		[Export ("initWithSettings:delegate:")]
		[DesignatedInitializer]
		IntPtr Constructor (MBFieldByFieldOverlaySettings settings, MBFieldByFieldOverlayViewControllerDelegate @delegate);

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		MBFieldByFieldOverlayViewControllerDelegate Delegate { get; set; }

		// @property (nonatomic, weak) id<MBFieldByFieldOverlayViewControllerDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; set; }
	}

	// @protocol MBFieldByFieldOverlayViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MBFieldByFieldOverlayViewControllerDelegate
	{
		// @required -(void)fieldByFieldOverlayViewControllerWillClose:(MBFieldByFieldOverlayViewController * _Nonnull)fieldByFieldOverlayViewController;
		[Abstract]
		[Export ("fieldByFieldOverlayViewControllerWillClose:")]
		void FieldByFieldOverlayViewControllerWillClose (MBFieldByFieldOverlayViewController fieldByFieldOverlayViewController);

		// @required -(void)fieldByFieldOverlayViewController:(MBFieldByFieldOverlayViewController * _Nonnull)fieldByFieldOverlayViewController didFinishScanningWithElements:(NSArray<MBScanElement *> * _Nonnull)scanElements;
		[Abstract]
		[Export ("fieldByFieldOverlayViewController:didFinishScanningWithElements:")]
		void FieldByFieldOverlayViewController (MBFieldByFieldOverlayViewController fieldByFieldOverlayViewController, MBScanElement[] scanElements);

		// @optional -(void)fieldByFieldOverlayViewControllerWillPresentHelp:(MBFieldByFieldOverlayViewController * _Nonnull)fieldByFieldOverlayViewController;
		[Export ("fieldByFieldOverlayViewControllerWillPresentHelp:")]
		void FieldByFieldOverlayViewControllerWillPresentHelp (MBFieldByFieldOverlayViewController fieldByFieldOverlayViewController);

		// @optional -(void)fieldByFieldOverlayViewController:(MBFieldByFieldOverlayViewController * _Nonnull)fieldByFieldOverlayViewController didOutputCurrentImage:(MBImage * _Nonnull)currentImage;
		[Export ("fieldByFieldOverlayViewController:didOutputCurrentImage:")]
		void FieldByFieldOverlayViewController (MBFieldByFieldOverlayViewController fieldByFieldOverlayViewController, MBImage currentImage);
	}

    // @interface MBOcrLayout : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBOcrLayout
    {
        // @property (nonatomic) CGRect box;
        [Export("box", ArgumentSemantic.Assign)]
        CGRect Box { get; set; }

        // @property (nonatomic) NSArray<MBOcrBlock *> * _Nonnull blocks;
        [Export("blocks", ArgumentSemantic.Assign)]
        MBOcrBlock[] Blocks { get; set; }

        // @property (nonatomic) CGAffineTransform transform;
        [Export("transform", ArgumentSemantic.Assign)]
        CGAffineTransform Transform { get; set; }

        // @property (nonatomic) BOOL transformInvalid;
        [Export("transformInvalid")]
        bool TransformInvalid { get; set; }

        // @property (nonatomic) MBPosition * _Nonnull position;
        [Export("position", ArgumentSemantic.Assign)]
        MBPosition Position { get; set; }

        // @property (nonatomic) BOOL flipped;
        [Export("flipped")]
        bool Flipped { get; set; }

        // -(instancetype _Nonnull)initWithOcrBlocks:(NSArray<MBOcrBlock *> * _Nonnull)ocrBlocks transform:(CGAffineTransform)transform box:(CGRect)box flipped:(BOOL)flipped __attribute__((objc_designated_initializer));
        [Export("initWithOcrBlocks:transform:box:flipped:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBOcrBlock[] ocrBlocks, CGAffineTransform transform, CGRect box, bool flipped);

        // -(instancetype _Nonnull)initWithOcrBlocks:(NSArray * _Nonnull)ocrBlocks;
        [Export("initWithOcrBlocks:")]
        IntPtr Constructor(MBOcrBlock[] ocrBlocks);

        // -(NSString * _Nonnull)string;
        [Export("string")]
        string String { get; }
    }

    // @interface MBOcrBlock : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBOcrBlock
    {
        // @property (nonatomic) NSArray<MBOcrLine *> * _Nonnull lines;
        [Export("lines", ArgumentSemantic.Assign)]
        MBOcrLine[] Lines { get; set; }

        // @property (nonatomic) MBPosition * _Nonnull position;
        [Export("position", ArgumentSemantic.Assign)]
        MBPosition Position { get; set; }

        // -(instancetype _Nonnull)initWithOcrLines:(NSArray<MBOcrLine *> * _Nonnull)ocrLines position:(MBPosition * _Nonnull)position __attribute__((objc_designated_initializer));
        [Export("initWithOcrLines:position:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBOcrLine[] ocrLines, MBPosition position);

        // -(NSString * _Nonnull)string;
        [Export("string")]
        string String { get; }
    }

    // @interface MBOcrLine : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBOcrLine
    {
        // @property (nonatomic) NSArray<MBCharWithVariants *> * _Nonnull chars;
        [Export("chars", ArgumentSemantic.Assign)]
        MBCharWithVariants[] Chars { get; set; }

        // @property (nonatomic) MBPosition * _Nonnull position;
        [Export("position", ArgumentSemantic.Assign)]
        MBPosition Position { get; set; }

        // -(instancetype _Nonnull)initWithOcrChars:(NSArray<MBCharWithVariants *> * _Nonnull)ocrChars position:(MBPosition * _Nonnull)position __attribute__((objc_designated_initializer));
        [Export("initWithOcrChars:position:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBCharWithVariants[] ocrChars, MBPosition position);

        // -(NSString * _Nonnull)string;
        [Export("string")]
        string String { get; }
    }

    // @interface MBCharWithVariants : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBCharWithVariants
    {
        // @property (nonatomic) MBOcrChar * _Nonnull character;
        [Export("character", ArgumentSemantic.Assign)]
        MBOcrChar Character { get; set; }

        // @property (nonatomic) NSSet * _Nonnull variants;
        [Export("variants", ArgumentSemantic.Assign)]
        NSSet Variants { get; set; }

        // -(instancetype _Nonnull)initWithValue:(MBOcrChar * _Nonnull)character __attribute__((objc_designated_initializer));
        [Export("initWithValue:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBOcrChar character);
    }

    // @interface MBOcrChar : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBOcrChar
    {
        // @property (nonatomic) unichar value;
        [Export("value")]
        ushort Value { get; set; }

        // @property (nonatomic) MBPosition * _Nonnull position;
        [Export("position", ArgumentSemantic.Assign)]
        MBPosition Position { get; set; }

        // @property (nonatomic) CGFloat height;
        [Export("height")]
        nfloat Height { get; set; }

        // @property (getter = isUncertain, nonatomic) BOOL uncertain;
        [Export("uncertain")]
        bool Uncertain { [Bind("isUncertain")] get; set; }

        // @property (nonatomic) NSInteger quality;
        [Export("quality")]
        nint Quality { get; set; }

        // @property (nonatomic) MBOcrFont font;
        [Export("font", ArgumentSemantic.Assign)]
        MBOcrFont Font { get; set; }

        // -(instancetype _Nonnull)initWithValue:(unichar)value position:(MBPosition * _Nonnull)position height:(CGFloat)height __attribute__((objc_designated_initializer));
        [Export("initWithValue:position:height:")]
        [DesignatedInitializer]
        IntPtr Constructor(ushort value, MBPosition position, nfloat height);
    }

    // @interface MBPosition : NSObject
    
    [BaseType(typeof(NSObject))]
    [DisableDefaultCtor]
    interface MBPosition
    {
        // @property (nonatomic) CGPoint ul;
        [Export("ul", ArgumentSemantic.Assign)]
        CGPoint Ul { get; set; }

        // @property (nonatomic) CGPoint ur;
        [Export("ur", ArgumentSemantic.Assign)]
        CGPoint Ur { get; set; }

        // @property (nonatomic) CGPoint ll;
        [Export("ll", ArgumentSemantic.Assign)]
        CGPoint Ll { get; set; }

        // @property (nonatomic) CGPoint lr;
        [Export("lr", ArgumentSemantic.Assign)]
        CGPoint Lr { get; set; }

        // -(instancetype _Nonnull)initWithUpperLeft:(CGPoint)ul upperRight:(CGPoint)ur lowerLeft:(CGPoint)ll lowerRight:(CGPoint)lr __attribute__((objc_designated_initializer));
        [Export("initWithUpperLeft:upperRight:lowerLeft:lowerRight:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGPoint ul, CGPoint ur, CGPoint ll, CGPoint lr);

        // -(MBPosition * _Nonnull)positionWithOffset:(CGPoint)offset;
        [Export("positionWithOffset:")]
        MBPosition PositionWithOffset(CGPoint offset);

        // -(CGRect)rect;
        [Export("rect")]
        CGRect Rect { get; }

        // -(CGPoint)center;
        [Export("center")]
        CGPoint Center { get; }

        // -(CGFloat)height;
        [Export("height")]
        nfloat Height { get; }
    }

    // @protocol MBFaceImageResult
    [Protocol]
    interface IMBFaceImageResult
    {
        // @required @property (readonly, nonatomic) MBImage * _Nullable faceImage;
        [Abstract]
        [NullAllowed, Export("faceImage")]
        MBImage FaceImage { get; }
    }

    // @protocol MBSignatureImageResult
    [Protocol]
    interface IMBSignatureImageResult
    {
        // @required @property (readonly, nonatomic) MBImage * _Nullable signatureImage;
        [Abstract]
        [NullAllowed, Export("signatureImage")]
        MBImage SignatureImage { get; }
    }

    // @protocol MBFullDocumentImageResult
    [Protocol]
    interface IMBFullDocumentImageResult
    {
        // @required @property (readonly, nonatomic) MBImage * _Nullable fullDocumentImage;
        [Abstract]
        [NullAllowed, Export("fullDocumentImage")]
        MBImage FullDocumentImage { get; }
    }

    // @protocol MBFaceImage
    [Protocol]
    interface IMBFaceImage
    {
        // @required @property (assign, nonatomic) BOOL returnFaceImage;
        [Abstract]
        [Export("returnFaceImage")]
        bool ReturnFaceImage { get; set; }
    }

    // @protocol MBSignatureImage
    [Protocol]
    interface IMBSignatureImage
    {
        // @required @property (assign, nonatomic) BOOL returnSignatureImage;
        [Abstract]
        [Export("returnSignatureImage")]
        bool ReturnSignatureImage { get; set; }
    }

    // @protocol MBFullDocumentImage
    [Protocol]
    interface IMBFullDocumentImage
    {
        // @required @property (assign, nonatomic) BOOL returnFullDocumentImage;
        [Abstract]
        [Export("returnFullDocumentImage")]
        bool ReturnFullDocumentImage { get; set; }
    }

    // @protocol MBFullDocumentImageDpi
    [Protocol]
    interface IMBFullDocumentImageDpi
    {
        // @required @property (assign, nonatomic) NSUInteger fullDocumentImageDpi;
        [Abstract]
        [Export("fullDocumentImageDpi")]
        nuint FullDocumentImageDpi { get; set; }
    }

    // @interface MBOverlaySettings : NSObject <NSCopying>
    
    [BaseType(typeof(NSObject))]
    interface MBOverlaySettings : INSCopying
    {
        // @property (nonatomic, strong) NSString * _Nullable language;
        [NullAllowed, Export("language", ArgumentSemantic.Strong)]
        string Language { get; set; }

        // @property (nonatomic, strong) MBCameraSettings * _Nonnull cameraSettings;
        [Export("cameraSettings", ArgumentSemantic.Strong)]
        MBCameraSettings CameraSettings { get; set; }
    }

    // @interface MBBaseOverlaySettings : MBOverlaySettings
    
    [BaseType(typeof(MBOverlaySettings))]
    interface MBBaseOverlaySettings
    {
        // @property (assign, nonatomic) BOOL autorotateOverlay;
        [Export("autorotateOverlay")]
        bool AutorotateOverlay { get; set; }

        // @property (assign, nonatomic) BOOL showStatusBar;
        [Export("showStatusBar")]
        bool ShowStatusBar { get; set; }

        // @property (assign, nonatomic) NSUInteger supportedOrientations;
        [Export("supportedOrientations")]
        nuint SupportedOrientations { get; set; }

        // @property (nonatomic, strong) NSString * _Nullable soundFilePath;
        [NullAllowed, Export("soundFilePath", ArgumentSemantic.Strong)]
        string SoundFilePath { get; set; }

        // @property (assign, nonatomic) BOOL displayCancelButton;
        [Export("displayCancelButton")]
        bool DisplayCancelButton { get; set; }

        // @property (assign, nonatomic) BOOL displayTorchButton;
        [Export("displayTorchButton")]
        bool DisplayTorchButton { get; set; }
    }

    // @interface MBCustomOverlayViewController : MBOverlayViewController
    
    [BaseType(typeof(MBOverlayViewController))]
    interface MBCustomOverlayViewController
    {
        // @property (readonly, nonatomic, strong) MBRecognizerCollection * _Nonnull recognizerCollection;
        [Export("recognizerCollection", ArgumentSemantic.Strong)]
        MBRecognizerCollection RecognizerCollection { get; }

        // @property (readonly, nonatomic, strong) MBCameraSettings * _Nonnull cameraSettings;
        [Export("cameraSettings", ArgumentSemantic.Strong)]
        MBCameraSettings CameraSettings { get; }

        // @property (nonatomic, strong) MBRecognizerRunnerViewControllerMetadataDelegates * _Nonnull metadataDelegates;
        [Export("metadataDelegates", ArgumentSemantic.Strong)]
        MBRecognizerRunnerViewControllerMetadataDelegates MetadataDelegates { get; set; }

        [Wrap("WeakScanningRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBScanningRecognizerRunnerViewControllerDelegate ScanningRecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBScanningRecognizerRunnerViewControllerDelegate> _Nullable scanningRecognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("scanningRecognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakScanningRecognizerRunnerViewControllerDelegate { get; set; }

        [Wrap("WeakRecognizerRunnerViewControllerDelegate")]
        [NullAllowed]
        MBRecognizerRunnerViewControllerDelegate RecognizerRunnerViewControllerDelegate { get; set; }

        // @property (nonatomic, weak) id<MBRecognizerRunnerViewControllerDelegate> _Nullable recognizerRunnerViewControllerDelegate;
        [NullAllowed, Export("recognizerRunnerViewControllerDelegate", ArgumentSemantic.Weak)]
        NSObject WeakRecognizerRunnerViewControllerDelegate { get; set; }

        // -(instancetype _Nonnull)initWithRecognizerCollection:(MBRecognizerCollection * _Nonnull)recognizerCollection cameraSettings:(MBCameraSettings * _Nonnull)cameraSettings __attribute__((objc_designated_initializer));
        [Export("initWithRecognizerCollection:cameraSettings:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBRecognizerCollection recognizerCollection, MBCameraSettings cameraSettings);

        // @property (nonatomic) CGRect scanningRegion;
        [Export("scanningRegion", ArgumentSemantic.Assign)]
        CGRect ScanningRegion { get; set; }

        // @property (assign, nonatomic) BOOL autorotateOverlay;
        [Export("autorotateOverlay")]
        bool AutorotateOverlay { get; set; }

        // @property (assign, nonatomic) BOOL showStatusBar;
        [Export("showStatusBar")]
        bool ShowStatusBar { get; set; }

        // @property (assign, nonatomic) NSUInteger supportedOrientations;
        [Export("supportedOrientations")]
        nuint SupportedOrientations { get; set; }

        // -(void)reconfigureRecognizers:(MBRecognizerCollection * _Nonnull)recognizerCollection;
        [Export("reconfigureRecognizers:")]
        void ReconfigureRecognizers(MBRecognizerCollection recognizerCollection);
    }

    // @interface MBRecognizerCollection : NSObject <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(NSObject))]
	[DisableDefaultCtor]
	interface MBRecognizerCollection : INSCopying
	{
		// -(instancetype _Nonnull)initWithRecognizers:(NSArray<MBRecognizer *> * _Nonnull)recognizers __attribute__((objc_designated_initializer));
		[Export ("initWithRecognizers:")]
		[DesignatedInitializer]
		IntPtr Constructor (MBRecognizer[] recognizers);

		// @property (nonatomic, strong) NSArray<MBRecognizer *> * _Nonnull recognizerList;
		[Export ("recognizerList", ArgumentSemantic.Strong)]
		MBRecognizer[] RecognizerList { get; set; }

		// @property (nonatomic) BOOL allowMultipleResults;
		[Export ("allowMultipleResults")]
		bool AllowMultipleResults { get; set; }

		// @property (nonatomic) NSTimeInterval partialRecognitionTimeout;
		[Export ("partialRecognitionTimeout")]
		double PartialRecognitionTimeout { get; set; }

		// @property (nonatomic) MBRecognitionMode recognitionMode;
		[Export ("recognitionMode", ArgumentSemantic.Assign)]
		MBRecognitionMode RecognitionMode { get; set; }

		// @property (nonatomic) MBFrameQualityEstimationMode frameQualityEstimationMode;
		[Export ("frameQualityEstimationMode", ArgumentSemantic.Assign)]
		MBFrameQualityEstimationMode FrameQualityEstimationMode { get; set; }
	}

    // @interface MBBaseOverlayViewController : MBOverlayViewController
	[iOS (8,0)]
	[BaseType (typeof(MBOverlayViewController))]
	interface MBBaseOverlayViewController
	{
		// -(void)reconfigureRecognizers:(MBRecognizerCollection * _Nonnull)recognizerCollection;
		[Export ("reconfigureRecognizers:")]
		void ReconfigureRecognizers (MBRecognizerCollection recognizerCollection);
	}


    // @interface MBSubview : UIView
    
    [BaseType(typeof(UIView))]
    interface MBSubview
    {
        [Wrap("WeakDelegate")]
        [NullAllowed]
        MBSubviewDelegate Delegate { get; set; }

        // @property (nonatomic, weak) id<MBSubviewDelegate> _Nullable delegate;
        [NullAllowed, Export("delegate", ArgumentSemantic.Weak)]
        NSObject WeakDelegate { get; set; }
    }

    // @protocol MBSubviewDelegate <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBSubviewDelegate
    {
        // @required -(void)subviewAnimationDidStart:(MBSubview * _Nonnull)subview;
        [Abstract]
        [Export("subviewAnimationDidStart:")]
        void SubviewAnimationDidStart(MBSubview subview);

        // @required -(void)subviewAnimationDidFinish:(MBSubview * _Nonnull)subview;
        [Abstract]
        [Export("subviewAnimationDidFinish:")]
        void SubviewAnimationDidFinish(MBSubview subview);
    }

    // @interface MBDisplayableObject : NSObject
    
    [BaseType(typeof(NSObject))]
    interface MBDisplayableObject
    {
        // @property (assign, nonatomic) CGAffineTransform transform;
        [Export("transform", ArgumentSemantic.Assign)]
        CGAffineTransform Transform { get; set; }
    }

    // @interface MBDisplayableDetection : MBDisplayableObject
    
    [BaseType(typeof(MBDisplayableObject))]
    [DisableDefaultCtor]
    interface MBDisplayableDetection
    {
        // -(instancetype _Nonnull)initWithDetectionStatus:(MBDetectionStatus)status __attribute__((objc_designated_initializer));
        [Export("initWithDetectionStatus:")]
        [DesignatedInitializer]
        IntPtr Constructor(MBDetectionStatus status);

        // @property (readonly, assign, nonatomic) MBDetectionStatus detectionStatus;
        [Export("detectionStatus", ArgumentSemantic.Assign)]
        MBDetectionStatus DetectionStatus { get; }
    }

    // @interface MBDisplayablePointsDetection : MBDisplayableDetection
    
    [BaseType(typeof(MBDisplayableDetection))]
    interface MBDisplayablePointsDetection
    {
        // @property (nonatomic) NSArray * _Nonnull points;
        [Export("points", ArgumentSemantic.Assign)]
        NSValue[] Points { get; set; }
    }

    // @protocol MBPointDetectorSubview <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IMBPointDetectorSubview
    {
        // @required -(void)detectionFinishedWithDisplayablePoints:(MBDisplayablePointsDetection *)displayablePointsDetection;
        [Abstract]
        [Export("detectionFinishedWithDisplayablePoints:")]
        void DetectionFinishedWithDisplayablePoints(MBDisplayablePointsDetection displayablePointsDetection);
    }

    // @interface MBDotsSubview : MBSubview <MBPointDetectorSubview>
    
    [BaseType(typeof(MBSubview))]
    interface MBDotsSubview : IMBPointDetectorSubview
    {
        // @property (nonatomic, strong) CAShapeLayer * _Nonnull dotsLayer;
        [Export("dotsLayer", ArgumentSemantic.Strong)]
        CAShapeLayer DotsLayer { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull dotsColor;
        [Export("dotsColor", ArgumentSemantic.Strong)]
        UIColor DotsColor { get; set; }

        // @property (assign, nonatomic) CGFloat dotsStrokeWidth;
        [Export("dotsStrokeWidth")]
        nfloat DotsStrokeWidth { get; set; }

        // @property (assign, nonatomic) CGFloat dotsRadius;
        [Export("dotsRadius")]
        nfloat DotsRadius { get; set; }

        // @property (assign, nonatomic) CGFloat animationDuration;
        [Export("animationDuration")]
        nfloat AnimationDuration { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);
    }

    // @interface MBDotsResultSubview : MBSubview <MBPointDetectorSubview, MBOcrLayoutSubview>
    
    [BaseType(typeof(MBSubview))]
    interface MBDotsResultSubview : IMBPointDetectorSubview
    {
        // @property (nonatomic, strong) UIColor * _Nonnull foregroundColor;
        [Export("foregroundColor", ArgumentSemantic.Strong)]
        UIColor ForegroundColor { get; set; }

        // @property (nonatomic, strong) UIColor * _Nonnull tintColor;
        [Export("tintColor", ArgumentSemantic.Strong)]
        UIColor TintColor { get; set; }

        // @property (assign, nonatomic) BOOL shouldIgnoreFastResults;
        [Export("shouldIgnoreFastResults")]
        bool ShouldIgnoreFastResults { get; set; }

        // @property (assign, nonatomic) CGFloat charFadeInDuration;
        [Export("charFadeInDuration")]
        nfloat CharFadeInDuration { get; set; }

        // @property (assign, nonatomic) NSUInteger dotCount;
        [Export("dotCount")]
        nuint DotCount { get; set; }
    }

    // @interface MBDisplayableQuadDetection : MBDisplayableDetection
    
    [BaseType(typeof(MBDisplayableDetection))]
    interface MBDisplayableQuadDetection
    {
        // @property (nonatomic, strong) MBQuadrangle * _Nonnull detectionLocation;
        [Export("detectionLocation", ArgumentSemantic.Strong)]
        MBQuadrangle DetectionLocation { get; set; }
    }

    // @interface MBTapToFocusSubview : MBSubview
    
    [BaseType(typeof(MBSubview))]
    interface MBTapToFocusSubview
    {
        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);

        // -(void)willFocusAtPoint:(CGPoint)point;
        [Export("willFocusAtPoint:")]
        void WillFocusAtPoint(CGPoint point);
    }

    // @protocol MBResultSubview <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface MBResultSubview
    {
        // @required -(void)scanningFinishedWithState:(MBRecognizerResultState)state;
        [Abstract]
        [Export("scanningFinishedWithState:")]
        void ScanningFinishedWithState(MBRecognizerResultState state);
    }

    // @interface MBGlareStatusSubview : MBSubview
    
    [BaseType(typeof(MBSubview))]
    [DisableDefaultCtor]
    interface MBGlareStatusSubview
    {
        // @property (nonatomic) UILabel * _Nonnull label;
        [Export("label", ArgumentSemantic.Assign)]
        UILabel Label { get; set; }

        // -(instancetype _Nonnull)initWithFrame:(CGRect)frame __attribute__((objc_designated_initializer));
        [Export("initWithFrame:")]
        [DesignatedInitializer]
        IntPtr Constructor(CGRect frame);

        // -(void)glareDetectionFinishedWithResult:(BOOL)glareFound;
        [Export("glareDetectionFinishedWithResult:")]
        void GlareDetectionFinishedWithResult(bool glareFound);
    }

    // @interface MBBaseOcrOverlaySettings : MBBaseOverlaySettings
    
    [BaseType(typeof(MBBaseOverlaySettings))]
    interface MBBaseOcrOverlaySettings
    {
        // @property (nonatomic) BOOL showOcrDots;
        [Export("showOcrDots")]
        bool ShowOcrDots { get; set; }
    }

    // @interface MBDocumentOverlaySettings : MBBaseOcrOverlaySettings
    
    [BaseType(typeof(MBBaseOcrOverlaySettings))]
    interface MBDocumentOverlaySettings
    {
        // @property (nonatomic, strong) NSString * _Nonnull tooltipText;
        [Export("tooltipText", ArgumentSemantic.Strong)]
        string TooltipText { get; set; }

        // @property (assign, nonatomic) BOOL showTooltip;
        [Export("showTooltip")]
        bool ShowTooltip { get; set; }
    }

    // @interface MBDocumentCaptureOverlayViewController : MBBaseOverlayViewController
	[iOS (8,0)]
	[BaseType (typeof(MBBaseOverlayViewController))]
	interface MBDocumentCaptureOverlayViewController
	{
		// @property (readonly, nonatomic) MBDocumentCaptureOverlaySettings * _Nonnull settings;
		[Export ("settings")]
		MBDocumentCaptureOverlaySettings Settings { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		MBDocumentCaptureOverlayViewControllerDelegate Delegate { get; }

		// @property (readonly, nonatomic, weak) id<MBDocumentCaptureOverlayViewControllerDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; }

		// -(instancetype _Nonnull)initWithSettings:(MBDocumentCaptureOverlaySettings * _Nonnull)settings recognizer:(MBDocumentCaptureRecognizer * _Nonnull)documentCaptureRecognizer delegate:(id<MBDocumentCaptureOverlayViewControllerDelegate> _Nonnull)delegate;
		[Export ("initWithSettings:recognizer:delegate:")]
		IntPtr Constructor (MBDocumentCaptureOverlaySettings settings, MBDocumentCaptureRecognizer documentCaptureRecognizer, MBDocumentCaptureOverlayViewControllerDelegate @delegate);
	}

    // @protocol MBQuadDetectorSubview <NSObject>
    [Protocol, Model]
    [BaseType(typeof(NSObject))]
    interface IMBQuadDetectorSubview
    {
        // @required -(void)detectionFinishedWithDisplayableQuad:(MBDisplayableQuadDetection *)displayableQuadDetection;
        [Abstract]
        [Export("detectionFinishedWithDisplayableQuad:")]
        void DetectionFinishedWithDisplayableQuad(MBDisplayableQuadDetection displayableQuadDetection);
    }

	// @interface MBDocumentCaptureOverlaySettings : MBBaseOverlaySettings
	[iOS (8,0)]
	[BaseType (typeof(MBBaseOverlaySettings))]
	interface MBDocumentCaptureOverlaySettings
	{
		// @property (nonatomic, strong) UIColor * _Nonnull backgroundColor;
		[Export ("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull borderColor;
		[Export ("borderColor", ArgumentSemantic.Strong)]
		UIColor BorderColor { get; set; }

		// @property (assign, nonatomic) CGFloat alphaOpacity;
		[Export ("alphaOpacity")]
		nfloat AlphaOpacity { get; set; }
	}

	// @interface MBDocumentCaptureSubview : MBSubview <MBQuadDetectorSubview>
	[iOS (8,0)]
	[BaseType (typeof(MBSubview))]
	interface MBDocumentCaptureSubview : IMBQuadDetectorSubview
	{
		// -(void)resetPositions;
		[Export ("resetPositions")]
		void ResetPositions ();

		// @property (nonatomic, strong) UIColor * _Nonnull backgroundColor;
		[Export ("backgroundColor", ArgumentSemantic.Strong)]
		UIColor BackgroundColor { get; set; }

		// @property (nonatomic, strong) UIColor * _Nonnull borderColor;
		[Export ("borderColor", ArgumentSemantic.Strong)]
		UIColor BorderColor { get; set; }

		// @property (assign, nonatomic) CGFloat alphaOpacity;
		[Export ("alphaOpacity")]
		nfloat AlphaOpacity { get; set; }
	}

	// @protocol MBDocumentCaptureOverlayViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MBDocumentCaptureOverlayViewControllerDelegate
	{
		// @required -(void)documentCaptureOverlayViewControllerDidFinishScanning:(MBDocumentCaptureOverlayViewController * _Nonnull)documentCaptureOverlayViewController state:(MBRecognizerResultState)state;
		[Abstract]
		[Export ("documentCaptureOverlayViewControllerDidFinishScanning:state:")]
		void DocumentCaptureOverlayViewControllerDidFinishScanning (MBDocumentCaptureOverlayViewController documentCaptureOverlayViewController, MBRecognizerResultState state);

		// @required -(void)documentCaptureOverlayViewControllerDidTapClose:(MBDocumentCaptureOverlayViewController * _Nonnull)documentCaptureOverlayViewController;
		[Abstract]
		[Export ("documentCaptureOverlayViewControllerDidTapClose:")]
		void DocumentCaptureOverlayViewControllerDidTapClose (MBDocumentCaptureOverlayViewController documentCaptureOverlayViewController);

		// @required -(void)documentCaptureOverlayViewControllerDidCaptureHighResolutionImage:(MBDocumentCaptureOverlayViewController * _Nonnull)documentCaptureOverlayViewController highResImage:(MBImage * _Nonnull)highResImage state:(MBRecognizerResultState)state;
		[Abstract]
		[Export ("documentCaptureOverlayViewControllerDidCaptureHighResolutionImage:highResImage:state:")]
		void DocumentCaptureOverlayViewControllerDidCaptureHighResolutionImage (MBDocumentCaptureOverlayViewController documentCaptureOverlayViewController, MBImage highResImage, MBRecognizerResultState state);
	}

    	// @interface MBDocumentCaptureRecognizerResult : MBRecognizerResult <NSCopying, MBFullDocumentImageResult, MBEncodedFullDocumentImageResult>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizerResult))]
	[DisableDefaultCtor]
	interface MBDocumentCaptureRecognizerResult : INSCopying, IMBFullDocumentImageResult, IMBEncodedFullDocumentImageResult
	{
		// @property (readonly, nonatomic) MBQuadrangle * _Nonnull detectionLocation;
		[Export ("detectionLocation")]
		MBQuadrangle DetectionLocation { get; }
	}

    	// @interface MBDocumentCaptureRecognizer : MBRecognizer <NSCopying, MBFullDocumentImage, MBEncodeFullDocumentImage, MBFullDocumentImageExtensionFactors>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizer))]
	interface MBDocumentCaptureRecognizer : INSCopying, IMBFullDocumentImage, IMBEncodeFullDocumentImage, IMBFullDocumentImageExtensionFactors
	{
		// @property (readonly, nonatomic, strong) MBDocumentCaptureRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBDocumentCaptureRecognizerResult Result { get; }

		// @property (assign, nonatomic) NSUInteger numStableDetectionsThreshold;
		[Export ("numStableDetectionsThreshold")]
		nuint NumStableDetectionsThreshold { get; set; }

		// @property (assign, nonatomic) CGFloat minDocumentScale;
		[Export ("minDocumentScale")]
		nfloat MinDocumentScale { get; set; }
	}

    // @protocol MBEncodedFullDocumentImageResult
    [Protocol]
    interface IMBEncodedFullDocumentImageResult
    {
        // @required @property (readonly, nonatomic) NSData * _Nullable encodedFullDocumentImage;
        [Abstract]
        [NullAllowed, Export("encodedFullDocumentImage")]
        NSData EncodedFullDocumentImage { get; }
    }

    // @protocol MBEncodeFullDocumentImage
    [Protocol]
    interface IMBEncodeFullDocumentImage
    {
        // @required @property (assign, nonatomic) BOOL encodeFullDocumentImage;
        [Abstract]
        [Export("encodeFullDocumentImage")]
        bool EncodeFullDocumentImage { get; set; }
    }

    // @protocol MBFullDocumentImageExtensionFactors
    [Protocol]
    interface IMBFullDocumentImageExtensionFactors
    {
        // @required @property (assign, nonatomic) MBImageExtensionFactors fullDocumentImageExtensionFactors;
        [Abstract]
        [Export("fullDocumentImageExtensionFactors", ArgumentSemantic.Assign)]
        MBImageExtensionFactors FullDocumentImageExtensionFactors { get; set; }
    }

    // @interface MBPdf417RecognizerResult : MBRecognizerResult <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizerResult))]
	[DisableDefaultCtor]
	interface MBPdf417RecognizerResult : INSCopying
	{
		// @property (readonly, nonatomic, strong) NSData * _Nullable rawData;
		[NullAllowed, Export ("rawData", ArgumentSemantic.Strong)]
		NSData RawData { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable stringData;
		[NullAllowed, Export ("stringData", ArgumentSemantic.Strong)]
		string StringData { get; }

		// @property (readonly, assign, nonatomic) BOOL uncertain;
		[Export ("uncertain")]
		bool Uncertain { get; }

		// @property (readonly, assign, nonatomic) MBBarcodeType barcodeType;
		[Export ("barcodeType", ArgumentSemantic.Assign)]
		MBBarcodeType BarcodeType { get; }
	}

	// @interface MBPdf417Recognizer : MBRecognizer <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizer))]
	interface MBPdf417Recognizer : INSCopying
	{
		// @property (readonly, nonatomic, strong) MBPdf417RecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBPdf417RecognizerResult Result { get; }

		// @property (assign, nonatomic) BOOL scanUncertain;
		[Export ("scanUncertain")]
		bool ScanUncertain { get; set; }

		// @property (assign, nonatomic) BOOL nullQuietZoneAllowed;
		[Export ("nullQuietZoneAllowed")]
		bool NullQuietZoneAllowed { get; set; }

		// @property (assign, nonatomic) BOOL scanInverse;
		[Export ("scanInverse")]
		bool ScanInverse { get; set; }
	}

	// @interface MBSimNumberRecognizerResult : MBRecognizerResult <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizerResult))]
	[DisableDefaultCtor]
	interface MBSimNumberRecognizerResult : INSCopying
	{
		// @property (readonly, nonatomic, strong) NSString * _Nullable simNumber;
		[NullAllowed, Export ("simNumber", ArgumentSemantic.Strong)]
		string SimNumber { get; }
	}

	// @interface MBSimNumberRecognizer : MBRecognizer <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizer))]
	interface MBSimNumberRecognizer : INSCopying
	{
		// @property (readonly, nonatomic, strong) MBSimNumberRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBSimNumberRecognizerResult Result { get; }
	}

	// @interface MBBarcodeRecognizerResult : MBRecognizerResult <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizerResult))]
	[DisableDefaultCtor]
	interface MBBarcodeRecognizerResult : INSCopying
	{
		// @property (readonly, nonatomic, strong) NSData * _Nullable rawData;
		[NullAllowed, Export ("rawData", ArgumentSemantic.Strong)]
		NSData RawData { get; }

		// @property (readonly, nonatomic, strong) NSString * _Nullable stringData;
		[NullAllowed, Export ("stringData", ArgumentSemantic.Strong)]
		string StringData { get; }

		// @property (readonly, assign, nonatomic) BOOL uncertain;
		[Export ("uncertain")]
		bool Uncertain { get; }

		// +(NSString * _Nonnull)toTypeName:(MBBarcodeType)type;
		[Static]
		[Export ("toTypeName:")]
		string ToTypeName (MBBarcodeType type);

		// @property (readonly, assign, nonatomic) MBBarcodeType barcodeType;
		[Export ("barcodeType", ArgumentSemantic.Assign)]
		MBBarcodeType BarcodeType { get; }
	}

	// @interface MBBarcodeRecognizer : MBRecognizer <NSCopying>
	[iOS (8,0)]
	[BaseType (typeof(MBRecognizer))]
	interface MBBarcodeRecognizer : INSCopying
	{
		// @property (readonly, nonatomic, strong) MBBarcodeRecognizerResult * _Nonnull result;
		[Export ("result", ArgumentSemantic.Strong)]
		MBBarcodeRecognizerResult Result { get; }

		// @property (assign, nonatomic) BOOL scanAztecCode;
		[Export ("scanAztecCode")]
		bool ScanAztecCode { get; set; }

		// @property (assign, nonatomic) BOOL scanCode128;
		[Export ("scanCode128")]
		bool ScanCode128 { get; set; }

		// @property (assign, nonatomic) BOOL scanCode39;
		[Export ("scanCode39")]
		bool ScanCode39 { get; set; }

		// @property (assign, nonatomic) BOOL scanDataMatrix;
		[Export ("scanDataMatrix")]
		bool ScanDataMatrix { get; set; }

		// @property (assign, nonatomic) BOOL scanEan13;
		[Export ("scanEan13")]
		bool ScanEan13 { get; set; }

		// @property (assign, nonatomic) BOOL scanEan8;
		[Export ("scanEan8")]
		bool ScanEan8 { get; set; }

		// @property (assign, nonatomic) BOOL scanItf;
		[Export ("scanItf")]
		bool ScanItf { get; set; }

		// @property (assign, nonatomic) BOOL scanQrCode;
		[Export ("scanQrCode")]
		bool ScanQrCode { get; set; }

		// @property (assign, nonatomic) BOOL scanUpca;
		[Export ("scanUpca")]
		bool ScanUpca { get; set; }

		// @property (assign, nonatomic) BOOL scanUpce;
		[Export ("scanUpce")]
		bool ScanUpce { get; set; }

		// @property (assign, nonatomic) BOOL scanPdf417;
		[Export ("scanPdf417")]
		bool ScanPdf417 { get; set; }

		// @property (assign, nonatomic) BOOL slowerThoroughScan;
		[Export ("slowerThoroughScan")]
		bool SlowerThoroughScan { get; set; }

		// @property (assign, nonatomic) BOOL autoScaleDetection;
		[Export ("autoScaleDetection")]
		bool AutoScaleDetection { get; set; }

		// @property (assign, nonatomic) BOOL readCode39AsExtendedData;
		[Export ("readCode39AsExtendedData")]
		bool ReadCode39AsExtendedData { get; set; }

		// @property (assign, nonatomic) BOOL scanInverse;
		[Export ("scanInverse")]
		bool ScanInverse { get; set; }

		// @property (assign, nonatomic) BOOL scanUncertain;
		[Export ("scanUncertain")]
		bool ScanUncertain { get; set; }

		// @property (assign, nonatomic) BOOL nullQuietZoneAllowed;
		[Export ("nullQuietZoneAllowed")]
		bool NullQuietZoneAllowed { get; set; }
	}

// @interface MBBarcodeOverlaySettings : MBBaseOverlaySettings
	[iOS (8,0)]
	[BaseType (typeof(MBBaseOverlaySettings))]
	interface MBBarcodeOverlaySettings
	{
		// @property (assign, nonatomic) BOOL displayBarcodeDots;
		[Export ("displayBarcodeDots")]
		bool DisplayBarcodeDots { get; set; }

		// @property (assign, nonatomic) BOOL displayViewfinder;
		[Export ("displayViewfinder")]
		bool DisplayViewfinder { get; set; }
	}

	// @interface MBBarcodeOverlayViewController : MBBaseOverlayViewController
	[iOS (8,0)]
	[BaseType (typeof(MBBaseOverlayViewController))]
	interface MBBarcodeOverlayViewController
	{
		// @property (readonly, nonatomic, strong) MBBarcodeOverlaySettings * _Nonnull settings;
		[Export ("settings", ArgumentSemantic.Strong)]
		MBBarcodeOverlaySettings Settings { get; }

		[Wrap ("WeakDelegate")]
		[NullAllowed]
		MBBarcodeOverlayViewControllerDelegate Delegate { get; }

		// @property (readonly, nonatomic, weak) id<MBBarcodeOverlayViewControllerDelegate> _Nullable delegate;
		[NullAllowed, Export ("delegate", ArgumentSemantic.Weak)]
		NSObject WeakDelegate { get; }

		// -(instancetype _Nonnull)initWithSettings:(MBBarcodeOverlaySettings * _Nonnull)settings recognizerCollection:(MBRecognizerCollection * _Nonnull)recognizerCollection delegate:(id<MBBarcodeOverlayViewControllerDelegate> _Nonnull)delegate;
		[Export ("initWithSettings:recognizerCollection:delegate:")]
		IntPtr Constructor (MBBarcodeOverlaySettings settings, MBRecognizerCollection recognizerCollection, MBBarcodeOverlayViewControllerDelegate @delegate);
	}

	// @protocol MBBarcodeOverlayViewControllerDelegate <NSObject>
	[Protocol, Model]
	[BaseType (typeof(NSObject))]
	interface MBBarcodeOverlayViewControllerDelegate
	{
		// @required -(void)barcodeOverlayViewControllerDidFinishScanning:(MBBarcodeOverlayViewController * _Nonnull)barcodeOverlayViewController state:(MBRecognizerResultState)state;
		[Abstract]
		[Export ("barcodeOverlayViewControllerDidFinishScanning:state:")]
		void BarcodeOverlayViewControllerDidFinishScanning (MBBarcodeOverlayViewController barcodeOverlayViewController, MBRecognizerResultState state);

		// @required -(void)barcodeOverlayViewControllerDidTapClose:(MBBarcodeOverlayViewController * _Nonnull)barcodeOverlayViewController;
		[Abstract]
		[Export ("barcodeOverlayViewControllerDidTapClose:")]
		void BarcodeOverlayViewControllerDidTapClose (MBBarcodeOverlayViewController barcodeOverlayViewController);
	}

}

#pragma clang diagnostic ignored "-Wdeprecated-declarations"
#pragma clang diagnostic ignored "-Wtypedef-redefinition"
#pragma clang diagnostic ignored "-Wobjc-designated-initializers"
#define DEBUG 1
#include <stdarg.h>
#include <objc/objc.h>
#include <objc/runtime.h>
#include <objc/message.h>
#import <Foundation/Foundation.h>
#import <StoreKit/StoreKit.h>
#import <UIKit/UIKit.h>
#import <MediaPlayer/MediaPlayer.h>
#import <CoreMotion/CoreMotion.h>
#import <QuartzCore/QuartzCore.h>
#import <AVFoundation/AVFoundation.h>
#import <CoreGraphics/CoreGraphics.h>

@class SKPaymentTransactionObserver;
@class UIApplicationDelegate;
@class UIKit_UIControlEventProxy;
@class UITextFieldDelegate;
@class Foundation_InternalNSNotificationHandler;
@class Foundation_NSDispatcher;
@class __MonoMac_NSActionDispatcher;
@class __MonoMac_NSSynchronizationContextDispatcher;
@class __Xamarin_NSTimerActionDispatcher;
@class Foundation_NSAsyncDispatcher;
@class __MonoMac_NSAsyncActionDispatcher;
@class __MonoMac_NSAsyncSynchronizationContextDispatcher;
@class CC_Mobile_Purchases_CustomPaymentObserver;
@class AppDelegate;
@class ViewController;
@class UIKit_UIAlertView__UIAlertViewDelegate;
@class UIKit_UIView_UIViewAppearance;
@class __NSObject_Disposer;
@class OpenTK_Platform_iPhoneOS_iPhoneOSGameView;
@class CCGameView;
@class CocosSharp_IMEKeyboardImpl_HiddenInputDelegate;
@class CocosSharp_IMEKeyboardImpl_HiddenInput;
@class Microsoft_Xna_Framework_iOSGameViewController;
@class iOSGameView;
@class OpenTK_Platform_iPhoneOS_CADisplayLinkTimeSource;
@class GADNativeAd;
@class GADNativeCustomTemplateAd;
@class GADRequest;
@class GADRequestError;
@class GADAdLoader;
@protocol GADAdLoaderDelegate;
@class GADAdLoaderDelegate;
@class GADAdLoaderOptions;
@protocol GADAdNetworkExtras;
@class GADAdNetworkExtras;
@class GADAdReward;
@protocol GADAdSizeDelegate;
struct trampoline_struct_ffi {
	float v0;
	float v4;
	int v8;
};
@class GADAdSizeDelegate;
@protocol GADAppEventDelegate;
@class GADAppEventDelegate;
@protocol GADAudioVideoManagerDelegate;
@class GADAudioVideoManagerDelegate;
@protocol GADBannerViewDelegate;
@class GADBannerViewDelegate;
@class GADCorrelator;
@class GADCorrelatorAdLoaderOptions;
@protocol GADCustomEventBanner;
@protocol GADCustomEventBannerDelegate;
@class GADCustomEventBannerDelegate;
@class GADCustomEventExtras;
@protocol GADCustomEventInterstitial;
@protocol GADCustomEventInterstitialDelegate;
@class GADCustomEventInterstitialDelegate;
@protocol GADCustomEventNativeAd;
@class GADCustomEventNativeAd;
@protocol GADCustomEventNativeAdDelegate;
@class GADCustomEventNativeAdDelegate;
@class GADCustomEventRequest;
@class GADDebugOptionsViewController;
@protocol GADDebugOptionsViewControllerDelegate;
@class GADDebugOptionsViewControllerDelegate;
@class GADDefaultInAppPurchase;
@protocol GADDefaultInAppPurchaseDelegate;
@class GADDefaultInAppPurchaseDelegate;
@class GADDynamicHeightSearchRequest;
@class GADExtras;
@class GADInAppPurchase;
@protocol GADInAppPurchaseDelegate;
@class GADInAppPurchaseDelegate;
@protocol GADInterstitialDelegate;
@class GADInterstitialDelegate;
@protocol Google_MobileAds_MediatedNativeAd;
@class Google_MobileAds_MediatedNativeAd;
@protocol GADMediatedNativeAdDelegate;
@class GADMediatedNativeAdDelegate;
@class GADMediatedNativeAdNotificationSource;
@protocol GADMediatedNativeAppInstallAd;
@class GADMediatedNativeAppInstallAd;
@protocol GADMediatedNativeContentAd;
@class GADMediatedNativeContentAd;
@class GADMediaView;
@class GADMobileAds;
@class GADMultipleAdsAdLoaderOptions;
@protocol GADNativeAdDelegate;
@class GADNativeAdDelegate;
@class GADNativeAdImage;
@class GADNativeAdImageAdLoaderOptions;
@class GADNativeAdViewAdOptions;
@class GADNativeAppInstallAd;
@protocol GADNativeAppInstallAdLoaderDelegate;
@class GADNativeAppInstallAdLoaderDelegate;
@class GADNativeContentAd;
@protocol GADNativeContentAdLoaderDelegate;
@class GADNativeContentAdLoaderDelegate;
@protocol GADNativeCustomTemplateAdLoaderDelegate;
@class GADNativeCustomTemplateAdLoaderDelegate;
@protocol GADNativeExpressAdViewDelegate;
@class GADNativeExpressAdViewDelegate;
@protocol GADRewardBasedVideoAdDelegate;
@class GADRewardBasedVideoAdDelegate;
@class GADSearchRequest;
@protocol GADSwipeableBannerViewDelegate;
@class GADSwipeableBannerViewDelegate;
@protocol GADVideoControllerDelegate;
@class GADVideoControllerDelegate;
@class GADVideoOptions;
@protocol DFPBannerAdLoaderDelegate;
@class DFPBannerAdLoaderDelegate;
@class DFPBannerViewOptions;
@class DFPCustomRenderedAd;
@protocol DFPCustomRenderedBannerViewDelegate;
@class DFPCustomRenderedBannerViewDelegate;
@protocol DFPCustomRenderedInterstitialDelegate;
@class DFPCustomRenderedInterstitialDelegate;
@class DFPRequest;
@class Google_MobileAds_RewardBasedVideoAd__RewardBasedVideoAdDelegate;
@class GADRewardBasedVideoAd;
@class Google_MobileAds_AdChoicesView_AdChoicesViewAppearance;
@class GADAdChoicesView;
@class Google_MobileAds_AudioVideoManager__AudioVideoManagerDelegate;
@class GADAudioVideoManager;
@class Google_MobileAds_BannerView__BannerViewDelegate;
@class Google_MobileAds_BannerView__AdSizeDelegate;
@class Google_MobileAds_BannerView_BannerViewAppearance;
@class GADBannerView;
@class Google_MobileAds_Interstitial__InterstitialDelegate;
@class GADInterstitial;
@class Google_MobileAds_NativeAd__NativeAdDelegate;
@class Google_MobileAds_NativeAppInstallAdView_NativeAppInstallAdViewAppearance;
@class GADNativeAppInstallAdView;
@class Google_MobileAds_NativeContentAdView_NativeContentAdViewAppearance;
@class GADNativeContentAdView;
@class Google_MobileAds_NativeExpressAdView__NativeExpressAdViewDelegate;
@class Google_MobileAds_NativeExpressAdView_NativeExpressAdViewAppearance;
@class GADNativeExpressAdView;
@class Google_MobileAds_SearchBannerView_SearchBannerViewAppearance;
@class GADSearchBannerView;
@class Google_MobileAds_VideoController__VideoControllerDelegate;
@class GADVideoController;
@class Google_MobileAds_DoubleClick_BannerView__AdSizeDelegate;
@class Google_MobileAds_DoubleClick_BannerView_BannerViewAppearance;
@class DFPBannerView;
@class Google_MobileAds_DoubleClick_Interstitial__CustomRenderedInterstitialDelegate;
@class DFPInterstitial;
@protocol MSPushDelegate;
@class MSPushDelegate;
@class Microsoft_AppCenter_Push_iOS_PushDelegate;
@class MSPush;
@class MSPushNotification;
@protocol MSCrashesDelegate;
@class MSCrashesDelegate;
@class Microsoft_AppCenter_Crashes_Crashes_CrashesDelegate;
@class MSCrashes;
@protocol MSCrashHandlerSetupDelegate;
@class MSCrashHandlerSetupDelegate;
@class MSErrorAttachmentLog;
@class MSErrorReport;
@class MSException;
@class MSStackFrame;
@class MSWrapperCrashesHelper;
@class MSWrapperException;
@class MSWrapperExceptionManager;
@class Microsoft_AppCenter_Crashes_iOS_Bindings_CrashesInitializationDelegate;
@class MSAppCenter;
@class MSCustomProperties;
@class MSWrapperSdk;
@class MSDevice;
@class MSLogger;
@protocol MSService;
@class MSService;
@class MSServiceAbstract;
@class MSWrapperLogger;
@class MSAnalytics;
@protocol MSAnalyticsDelegate;
@class MSAnalyticsDelegate;
@class MSLogWithProperties;
@class MSEventLog;
@class MSPageLog;

@interface SKPaymentTransactionObserver : NSObject<SKPaymentTransactionObserver> {
}
	-(id) init;
@end

@interface UIApplicationDelegate : NSObject<UIApplicationDelegate> {
}
	-(id) init;
@end

@interface UITextFieldDelegate : NSObject<UITextFieldDelegate> {
}
	-(id) init;
@end

@interface AppDelegate : NSObject<UIApplicationDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(UIWindow *) window;
	-(void) setWindow:(UIWindow *)p0;
	-(BOOL) application:(UIApplication *)p0 didFinishLaunchingWithOptions:(NSDictionary *)p1;
	-(void) application:(UIApplication *)p0 didRegisterForRemoteNotificationsWithDeviceToken:(NSData *)p1;
	-(void) application:(UIApplication *)p0 didFailToRegisterForRemoteNotificationsWithError:(NSError *)p1;
	-(void) application:(UIApplication *)p0 didReceiveRemoteNotification:(NSDictionary *)p1 fetchCompletionHandler:(id)p2;
	-(void) applicationWillResignActive:(UIApplication *)p0;
	-(void) applicationDidEnterBackground:(UIApplication *)p0;
	-(void) applicationWillEnterForeground:(UIApplication *)p0;
	-(void) applicationDidBecomeActive:(UIApplication *)p0;
	-(void) applicationWillTerminate:(UIApplication *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface ViewController : UIViewController {
}
	@property (nonatomic, assign) id GameView;
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(id) GameView;
	-(void) setGameView:(id)p0;
	-(void) viewDidLoad;
	-(void) viewWillDisappear:(BOOL)p0;
	-(void) viewDidAppear:(BOOL)p0;
	-(void) didReceiveMemoryWarning;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface UIKit_UIView_UIViewAppearance : NSObject {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(BOOL) conformsToProtocol:(void *)p0;
@end

@interface OpenTK_Platform_iPhoneOS_iPhoneOSGameView : UIView {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	+(Class) layerClass;
	-(void) layoutSubviews;
	-(void) willMoveToWindow:(UIWindow *)p0;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) initWithCoder:(NSCoder *)p0;
	-(id) initWithFrame:(CGRect)p0;
@end

@interface CCGameView : OpenTK_Platform_iPhoneOS_iPhoneOSGameView {
}
	-(void) layoutSubviews;
	-(void) touchesBegan:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesEnded:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesMoved:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(void) touchesCancelled:(NSSet *)p0 withEvent:(UIEvent *)p1;
	-(id) initWithCoder:(NSCoder *)p0;
@end

@interface CocosSharp_IMEKeyboardImpl_HiddenInputDelegate : NSObject<UITextFieldDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(BOOL) textField:(UITextField *)p0 shouldChangeCharactersInRange:(NSRange)p1 replacementString:(NSString *)p2;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface GADNativeAd : NSObject {
}
	-(NSString *) adNetworkClassName;
	-(id) delegate;
	-(void) setDelegate:(id)p0;
	-(NSDictionary *) extraAssets;
	-(UIViewController *) rootViewController;
	-(void) setRootViewController:(UIViewController *)p0;
	-(id) init;
@end

@interface GADNativeCustomTemplateAd : GADNativeAd {
}
	-(id) imageForKey:(NSString *)p0;
	-(void) performClickOnAssetWithKey:(NSString *)p0;
	-(void) performClickOnAssetWithKey:(NSString *)p0 customClickHandler:(id)p1;
	-(void) recordImpression;
	-(NSString *) stringForKey:(NSString *)p0;
	-(NSArray *) availableAssetKeys;
	-(id) customClickHandler;
	-(id) mediaView;
	-(NSString *) templateID;
	-(id) videoController;
	-(id) init;
@end

@interface GADRequest : NSObject {
}
	-(id) adNetworkExtrasFor:(Class)p0;
	-(NSObject *) copyWithZone:(id)p0;
	-(void) registerAdNetworkExtras:(id)p0;
	-(void) removeAdNetworkExtrasFor:(Class)p0;
	-(void) setBirthdayWithMonth:(NSInteger)p0 day:(NSInteger)p1 year:(NSInteger)p2;
	-(void) setLocationWithLatitude:(CGFloat)p0 longitude:(CGFloat)p1 accuracy:(CGFloat)p2;
	-(void) setLocationWithDescription:(NSString *)p0;
	-(void) tagForChildDirectedTreatment:(BOOL)p0;
	-(NSDate *) birthday;
	-(void) setBirthday:(NSDate *)p0;
	-(NSString *) contentURL;
	-(void) setContentURL:(NSString *)p0;
	-(NSInteger) gender;
	-(void) setGender:(NSInteger)p0;
	-(NSArray *) keywords;
	-(void) setKeywords:(NSArray *)p0;
	-(NSString *) requestAgent;
	-(void) setRequestAgent:(NSString *)p0;
	-(NSArray *) testDevices;
	-(void) setTestDevices:(NSArray *)p0;
@end

@interface GADRequestError : NSError {
}
	-(id) initWithCoder:(NSCoder *)p0;
	-(id) initWithDomain:(NSString *)p0 code:(NSInteger)p1 userInfo:(NSDictionary *)p2;
@end

@interface GADAdLoader : NSObject {
}
	-(void) loadRequest:(id)p0;
	-(NSString *) adUnitID;
	-(id) delegate;
	-(void) setDelegate:(id)p0;
	-(BOOL) isLoading;
	-(id) initWithAdUnitID:(NSString *)p0 rootViewController:(UIViewController *)p1 adTypes:(NSArray *)p2 options:(NSArray *)p3;
@end

@protocol GADAdLoaderDelegate
	@required -(void) adLoader:(id)p0 didFailToReceiveAdWithError:(id)p1;
	@optional -(void) adLoaderDidFinishLoading:(id)p0;
@end

@interface GADAdLoaderDelegate : NSObject<GADAdLoaderDelegate> {
}
	-(id) init;
@end

@interface GADAdLoaderOptions : NSObject {
}
	-(id) init;
@end

@protocol GADAdNetworkExtras
@end

@interface GADAdNetworkExtras : NSObject<GADAdNetworkExtras> {
}
	-(id) init;
@end

@interface GADAdReward : NSObject {
}
	-(NSDecimalNumber *) amount;
	-(NSString *) type;
	-(id) initWithRewardType:(NSString *)p0 rewardAmount:(NSDecimalNumber *)p1;
@end

@protocol GADAdSizeDelegate
	@required -(void) adView:(id)p0 willChangeAdSizeTo:(struct trampoline_struct_ffi)p1;
@end

@interface GADAdSizeDelegate : NSObject<GADAdSizeDelegate> {
}
	-(id) init;
@end

@protocol GADAppEventDelegate
	@optional -(void) adView:(id)p0 didReceiveAppEvent:(NSString *)p1 withInfo:(NSString *)p2;
	@optional -(void) interstitial:(id)p0 didReceiveAppEvent:(NSString *)p1 withInfo:(NSString *)p2;
@end

@interface GADAppEventDelegate : NSObject<GADAppEventDelegate> {
}
	-(id) init;
@end

@protocol GADAudioVideoManagerDelegate
	@optional -(void) audioVideoManagerDidStopPlayingAudio:(id)p0;
	@optional -(void) audioVideoManagerWillPlayVideo:(id)p0;
	@optional -(void) audioVideoManagerDidPauseAllVideo:(id)p0;
	@optional -(void) audioVideoManagerWillPlayAudio:(id)p0;
@end

@interface GADAudioVideoManagerDelegate : NSObject<GADAudioVideoManagerDelegate> {
}
	-(id) init;
@end

@protocol GADBannerViewDelegate
	@optional -(void) adViewWillLeaveApplication:(id)p0;
	@optional -(void) adViewDidDismissScreen:(id)p0;
	@optional -(void) adViewWillDismissScreen:(id)p0;
	@optional -(void) adViewWillPresentScreen:(id)p0;
	@optional -(void) adViewDidReceiveAd:(id)p0;
	@optional -(void) adView:(id)p0 didFailToReceiveAdWithError:(id)p1;
@end

@interface GADBannerViewDelegate : NSObject<GADBannerViewDelegate> {
}
	-(id) init;
@end

@interface GADCorrelator : NSObject {
}
	-(void) reset;
	-(id) init;
@end

@interface GADCorrelatorAdLoaderOptions : GADAdLoaderOptions {
}
	-(id) correlator;
	-(void) setCorrelator:(id)p0;
	-(id) init;
@end

@protocol GADCustomEventBanner
	@required -(void) setDelegate:(id)p0;
	@required -(id) delegate;
	@required -(void) requestBannerAd:(struct trampoline_struct_ffi)p0 parameter:(NSString *)p1 label:(NSString *)p2 request:(id)p3;
@end

@protocol GADCustomEventBannerDelegate
	@required -(void) customEventBanner:(id)p0 didReceiveAd:(UIView *)p1;
	@required -(UIViewController *) viewControllerForPresentingModalView;
	@required -(void) customEventBannerWillPresentModal:(id)p0;
	@required -(void) customEventBannerWillDismissModal:(id)p0;
	@required -(void) customEventBannerDidDismissModal:(id)p0;
	@required -(void) customEventBannerWillLeaveApplication:(id)p0;
	@required -(void) customEventBanner:(id)p0 didFailAd:(NSError *)p1;
	@required -(void) customEventBannerWasClicked:(id)p0;
@end

@interface GADCustomEventBannerDelegate : NSObject<GADCustomEventBannerDelegate> {
}
	-(id) init;
@end

@interface GADCustomEventExtras : NSObject {
}
	-(NSDictionary *) extrasForLabel:(NSString *)p0;
	-(void) removeAllExtras;
	-(void) setExtras:(NSDictionary *)p0 forLabel:(NSString *)p1;
	-(NSDictionary *) allExtras;
	-(id) init;
@end

@protocol GADCustomEventInterstitial
	@required -(id) delegate;
	@required -(void) setDelegate:(id)p0;
	@required -(void) requestInterstitialAdWithParameter:(NSString *)p0 label:(NSString *)p1 request:(id)p2;
	@required -(void) presentFromRootViewController:(UIViewController *)p0;
@end

@protocol GADCustomEventInterstitialDelegate
	@optional -(void) customEventInterstitialWillLeaveApplication:(id)p0;
	@optional -(void) customEventInterstitialDidReceiveAd:(id)p0;
	@optional -(void) customEventInterstitialWillDismiss:(id)p0;
	@optional -(void) customEventInterstitialWillPresent:(id)p0;
	@optional -(void) customEventInterstitialWasClicked:(id)p0;
	@optional -(void) customEventInterstitial:(id)p0 didFailAd:(NSError *)p1;
	@optional -(void) customEventInterstitialDidDismiss:(id)p0;
@end

@interface GADCustomEventInterstitialDelegate : NSObject<GADCustomEventInterstitialDelegate> {
}
	-(id) init;
@end

@protocol GADCustomEventNativeAd
	@required -(void) setDelegate:(id)p0;
	@required -(BOOL) handlesUserImpressions;
	@required -(void) requestNativeAdWithParameter:(NSString *)p0 request:(id)p1 adTypes:(NSArray *)p2 options:(NSArray *)p3 rootViewController:(UIViewController *)p4;
	@required -(BOOL) handlesUserClicks;
	@required -(id) delegate;
@end

@interface GADCustomEventNativeAd : NSObject<GADCustomEventNativeAd> {
}
	-(id) init;
@end

@protocol GADCustomEventNativeAdDelegate
	@required -(void) customEventNativeAd:(id)p0 didReceiveMediatedNativeAd:(id)p1;
	@required -(void) customEventNativeAd:(id)p0 didFailToLoadWithError:(NSError *)p1;
@end

@interface GADCustomEventNativeAdDelegate : NSObject<GADCustomEventNativeAdDelegate> {
}
	-(id) init;
@end

@interface GADCustomEventRequest : NSObject {
}
	-(NSDictionary *) additionalParameters;
	-(BOOL) isTesting;
	-(NSDate *) userBirthday;
	-(NSInteger) userGender;
	-(BOOL) userHasLocation;
	-(NSArray *) userKeywords;
	-(CGFloat) userLatitude;
	-(CGFloat) userLocationAccuracyInMeters;
	-(NSString *) userLocationDescription;
	-(CGFloat) userLongitude;
	-(id) init;
@end

@interface GADDebugOptionsViewController : UIViewController {
}
	-(id) delegate;
	-(void) setDelegate:(id)p0;
	-(id) initWithCoder:(NSCoder *)p0;
@end

@protocol GADDebugOptionsViewControllerDelegate
	@required -(void) debugOptionsViewControllerDidDismiss:(id)p0;
@end

@interface GADDebugOptionsViewControllerDelegate : NSObject<GADDebugOptionsViewControllerDelegate> {
}
	-(id) init;
@end

@interface GADDefaultInAppPurchase : NSObject {
}
	-(void) finishTransaction;
	-(SKPaymentTransaction *) paymentTransaction;
	-(NSString *) productID;
	-(NSInteger) quantity;
	-(id) init;
@end

@protocol GADDefaultInAppPurchaseDelegate
	@required -(void) userDidPayForPurchase:(id)p0;
	@optional -(void) shouldStartPurchaseForProductID:(NSString *)p0 quantity:(NSInteger)p1;
@end

@interface GADDefaultInAppPurchaseDelegate : NSObject<GADDefaultInAppPurchaseDelegate> {
}
	-(id) init;
@end

@interface GADDynamicHeightSearchRequest : GADRequest {
}
	-(void) setAdvancedOptionValue:(NSObject *)p0 forKey:(NSString *)p1;
	-(NSString *) adBorderColor;
	-(void) setAdBorderColor:(NSString *)p0;
	-(NSString *) adBorderCSSSelections;
	-(void) setAdBorderCSSSelections:(NSString *)p0;
	-(NSInteger) adPage;
	-(void) setAdPage:(NSInteger)p0;
	-(NSString *) adSeparatorColor;
	-(void) setAdSeparatorColor:(NSString *)p0;
	-(BOOL) adTestEnabled;
	-(void) setAdTestEnabled:(BOOL)p0;
	-(CGFloat) adjustableLineHeight;
	-(void) setAdjustableLineHeight:(CGFloat)p0;
	-(CGFloat) annotationFontSize;
	-(void) setAnnotationFontSize:(CGFloat)p0;
	-(NSString *) annotationTextColor;
	-(void) setAnnotationTextColor:(NSString *)p0;
	-(CGFloat) attributionBottomSpacing;
	-(void) setAttributionBottomSpacing:(CGFloat)p0;
	-(NSString *) attributionFontFamily;
	-(void) setAttributionFontFamily:(NSString *)p0;
	-(CGFloat) attributionFontSize;
	-(void) setAttributionFontSize:(CGFloat)p0;
	-(NSString *) attributionTextColor;
	-(void) setAttributionTextColor:(NSString *)p0;
	-(NSString *) backgroundColor;
	-(void) setBackgroundColor:(NSString *)p0;
	-(BOOL) boldTitleEnabled;
	-(void) setBoldTitleEnabled:(BOOL)p0;
	-(NSString *) borderColor;
	-(void) setBorderColor:(NSString *)p0;
	-(NSString *) borderCSSSelections;
	-(void) setBorderCSSSelections:(NSString *)p0;
	-(NSString *) channel;
	-(void) setChannel:(NSString *)p0;
	-(BOOL) clickToCallExtensionEnabled;
	-(void) setClickToCallExtensionEnabled:(BOOL)p0;
	-(NSString *) CSSWidth;
	-(void) setCSSWidth:(NSString *)p0;
	-(CGFloat) descriptionFontSize;
	-(void) setDescriptionFontSize:(CGFloat)p0;
	-(BOOL) detailedAttributionExtensionEnabled;
	-(void) setDetailedAttributionExtensionEnabled:(BOOL)p0;
	-(NSString *) domainLinkColor;
	-(void) setDomainLinkColor:(NSString *)p0;
	-(CGFloat) domainLinkFontSize;
	-(void) setDomainLinkFontSize:(CGFloat)p0;
	-(NSString *) fontFamily;
	-(void) setFontFamily:(NSString *)p0;
	-(NSString *) hostLanguage;
	-(void) setHostLanguage:(NSString *)p0;
	-(BOOL) locationExtensionEnabled;
	-(void) setLocationExtensionEnabled:(BOOL)p0;
	-(CGFloat) locationExtensionFontSize;
	-(void) setLocationExtensionFontSize:(CGFloat)p0;
	-(NSString *) locationExtensionTextColor;
	-(void) setLocationExtensionTextColor:(NSString *)p0;
	-(BOOL) longerHeadlinesExtensionEnabled;
	-(void) setLongerHeadlinesExtensionEnabled:(BOOL)p0;
	-(NSInteger) numberOfAds;
	-(void) setNumberOfAds:(NSInteger)p0;
	-(BOOL) plusOnesExtensionEnabled;
	-(void) setPlusOnesExtensionEnabled:(BOOL)p0;
	-(NSString *) query;
	-(void) setQuery:(NSString *)p0;
	-(BOOL) sellerRatingsExtensionEnabled;
	-(void) setSellerRatingsExtensionEnabled:(BOOL)p0;
	-(BOOL) siteLinksExtensionEnabled;
	-(void) setSiteLinksExtensionEnabled:(BOOL)p0;
	-(NSString *) textColor;
	-(void) setTextColor:(NSString *)p0;
	-(CGFloat) titleFontSize;
	-(void) setTitleFontSize:(CGFloat)p0;
	-(NSString *) titleLinkColor;
	-(void) setTitleLinkColor:(NSString *)p0;
	-(BOOL) titleUnderlineHidden;
	-(void) setTitleUnderlineHidden:(BOOL)p0;
	-(CGFloat) verticalSpacing;
	-(void) setVerticalSpacing:(CGFloat)p0;
	-(id) init;
@end

@interface GADExtras : NSObject {
}
	-(NSDictionary *) additionalParameters;
	-(void) setAdditionalParameters:(NSDictionary *)p0;
	-(id) init;
@end

@interface GADInAppPurchase : NSObject {
}
	-(void) reportPurchaseStatus:(NSInteger)p0;
	-(NSString *) productID;
	-(NSInteger) quantity;
	-(id) init;
@end

@protocol GADInAppPurchaseDelegate
	@optional -(void) didReceiveInAppPurchase:(id)p0;
@end

@interface GADInAppPurchaseDelegate : NSObject<GADInAppPurchaseDelegate> {
}
	-(id) init;
@end

@protocol GADInterstitialDelegate
	@optional -(void) interstitialDidFailToPresentScreen:(id)p0;
	@optional -(void) interstitialWillPresentScreen:(id)p0;
	@optional -(void) interstitial:(id)p0 didFailToReceiveAdWithError:(id)p1;
	@optional -(void) interstitialDidReceiveAd:(id)p0;
	@optional -(void) interstitialWillDismissScreen:(id)p0;
	@optional -(void) interstitialWillLeaveApplication:(id)p0;
	@optional -(void) interstitialDidDismissScreen:(id)p0;
@end

@interface GADInterstitialDelegate : NSObject<GADInterstitialDelegate> {
}
	-(id) init;
@end

@protocol Google_MobileAds_MediatedNativeAd
	@required -(id) mediatedNativeAdDelegate;
	@required -(NSDictionary *) extraAssets;
@end

@interface Google_MobileAds_MediatedNativeAd : NSObject<Google_MobileAds_MediatedNativeAd> {
}
	-(id) init;
@end

@protocol GADMediatedNativeAdDelegate
	@optional -(void) mediatedNativeAdDidRecordImpression:(id)p0;
	@optional -(void) mediatedNativeAd:(id)p0 didUntrackView:(UIView *)p1;
	@optional -(void) mediatedNativeAd:(id)p0 didRecordClickOnAssetWithName:(NSString *)p1 view:(UIView *)p2 viewController:(UIViewController *)p3;
	@optional -(void) mediatedNativeAd:(id)p0 didRenderInView:(UIView *)p1 viewController:(UIViewController *)p2;
@end

@interface GADMediatedNativeAdDelegate : NSObject<GADMediatedNativeAdDelegate> {
}
	-(id) init;
@end

@interface GADMediatedNativeAdNotificationSource : NSObject {
}
@end

@protocol GADMediatedNativeAppInstallAd
	@required -(NSDecimalNumber *) starRating;
	@required -(NSString *) body;
	@required -(id) icon;
	@required -(NSString *) callToAction;
	@required -(NSArray *) images;
	@optional -(UIView *) mediaView;
	@required -(NSString *) headline;
	@required -(NSString *) price;
	@optional -(UIView *) adChoicesView;
	@optional -(BOOL) hasVideoContent;
	@required -(NSString *) store;
@end

@interface GADMediatedNativeAppInstallAd : NSObject<GADMediatedNativeAppInstallAd> {
}
	-(id) init;
@end

@protocol GADMediatedNativeContentAd
	@required -(NSString *) body;
	@required -(NSArray *) images;
	@required -(id) logo;
	@required -(NSString *) callToAction;
	@required -(NSString *) advertiser;
	@optional -(UIView *) adChoicesView;
	@optional -(BOOL) hasVideoContent;
	@required -(NSString *) headline;
	@optional -(UIView *) mediaView;
@end

@interface GADMediatedNativeContentAd : NSObject<GADMediatedNativeContentAd> {
}
	-(id) init;
@end

@interface GADMediaView : NSObject {
}
	-(id) init;
@end

@interface GADMobileAds : NSObject {
}
	-(void) isSDKVersionAtLeastMajor:(NSInteger)p0 minor:(NSInteger)p1 patch:(NSInteger)p2;
	-(BOOL) applicationMuted;
	-(void) setApplicationMuted:(BOOL)p0;
	-(float) applicationVolume;
	-(void) setApplicationVolume:(float)p0;
	-(id) audioVideoManager;
@end

@interface GADMultipleAdsAdLoaderOptions : GADAdLoaderOptions {
}
	-(NSInteger) numberOfAds;
	-(void) setNumberOfAds:(NSInteger)p0;
	-(id) init;
@end

@protocol GADNativeAdDelegate
	@optional -(void) nativeAdDidRecordImpression:(id)p0;
	@optional -(void) nativeAdDidRecordClick:(id)p0;
	@optional -(void) nativeAdWillPresentScreen:(id)p0;
	@optional -(void) nativeAdWillDismissScreen:(id)p0;
	@optional -(void) nativeAdDidDismissScreen:(id)p0;
	@optional -(void) nativeAdWillLeaveApplication:(id)p0;
@end

@interface GADNativeAdDelegate : NSObject<GADNativeAdDelegate> {
}
	-(id) init;
@end

@interface GADNativeAdImage : NSObject {
}
	-(UIImage *) image;
	-(NSURL *) imageURL;
	-(CGFloat) scale;
	-(id) initWithImage:(UIImage *)p0;
	-(id) initWithURL:(NSURL *)p0 scale:(CGFloat)p1;
@end

@interface GADNativeAdImageAdLoaderOptions : GADAdLoaderOptions {
}
	-(BOOL) disableImageLoading;
	-(void) setDisableImageLoading:(BOOL)p0;
	-(NSInteger) preferredImageOrientation;
	-(void) setPreferredImageOrientation:(NSInteger)p0;
	-(BOOL) shouldRequestMultipleImages;
	-(void) setShouldRequestMultipleImages:(BOOL)p0;
	-(id) init;
@end

@interface GADNativeAdViewAdOptions : GADAdLoaderOptions {
}
	-(NSInteger) preferredAdChoicesPosition;
	-(void) setPreferredAdChoicesPosition:(NSInteger)p0;
	-(id) init;
@end

@interface GADNativeAppInstallAd : GADNativeAd {
}
	-(void) registerAdView:(UIView *)p0 assetViews:(NSDictionary <NSString *, UIView *>*)p1;
	-(void) registerAdView:(UIView *)p0 clickableAssetViews:(NSDictionary <NSString *, UIView *>*)p1 nonclickableAssetViews:(NSDictionary <NSString *, UIView *>*)p2;
	-(void) unregisterAdView;
	-(NSString *) body;
	-(NSString *) callToAction;
	-(NSString *) headline;
	-(id) icon;
	-(NSArray *) images;
	-(NSString *) price;
	-(NSDecimalNumber *) starRating;
	-(NSString *) store;
	-(id) videoController;
	-(id) init;
@end

@protocol GADNativeAppInstallAdLoaderDelegate
	@required -(void) adLoader:(id)p0 didReceiveNativeAppInstallAd:(id)p1;
@end

@interface GADNativeAppInstallAdLoaderDelegate : NSObject<GADNativeAppInstallAdLoaderDelegate> {
}
	-(id) init;
@end

@interface GADNativeContentAd : GADNativeAd {
}
	-(void) registerAdView:(UIView *)p0 assetViews:(NSDictionary <NSString *, UIView *>*)p1;
	-(void) registerAdView:(UIView *)p0 clickableAssetViews:(NSDictionary <NSString *, UIView *>*)p1 nonclickableAssetViews:(NSDictionary <NSString *, UIView *>*)p2;
	-(void) unregisterAdView;
	-(NSString *) advertiser;
	-(NSString *) body;
	-(NSString *) callToAction;
	-(NSString *) headline;
	-(NSArray *) images;
	-(id) logo;
	-(id) videoController;
	-(id) init;
@end

@protocol GADNativeContentAdLoaderDelegate
	@required -(void) adLoader:(id)p0 didReceiveNativeContentAd:(id)p1;
@end

@interface GADNativeContentAdLoaderDelegate : NSObject<GADNativeContentAdLoaderDelegate> {
}
	-(id) init;
@end

@protocol GADNativeCustomTemplateAdLoaderDelegate
	@required -(NSArray *) nativeCustomTemplateIDsForAdLoader:(id)p0;
	@required -(void) adLoader:(id)p0 didReceiveNativeCustomTemplateAd:(id)p1;
@end

@interface GADNativeCustomTemplateAdLoaderDelegate : NSObject<GADNativeCustomTemplateAdLoaderDelegate> {
}
	-(id) init;
@end

@protocol GADNativeExpressAdViewDelegate
	@optional -(void) nativeExpressAdViewWillLeaveApplication:(id)p0;
	@optional -(void) nativeExpressAdViewDidReceiveAd:(id)p0;
	@optional -(void) nativeExpressAdView:(id)p0 didFailToReceiveAdWithError:(id)p1;
	@optional -(void) nativeExpressAdViewWillPresentScreen:(id)p0;
	@optional -(void) nativeExpressAdViewWillDismissScreen:(id)p0;
	@optional -(void) nativeExpressAdViewDidDismissScreen:(id)p0;
@end

@interface GADNativeExpressAdViewDelegate : NSObject<GADNativeExpressAdViewDelegate> {
}
	-(id) init;
@end

@protocol GADRewardBasedVideoAdDelegate
	@optional -(void) rewardBasedVideoAd:(id)p0 didFailToLoadWithError:(NSError *)p1;
	@required -(void) rewardBasedVideoAd:(id)p0 didRewardUserWithReward:(id)p1;
	@optional -(void) rewardBasedVideoAdDidReceiveAd:(id)p0;
	@optional -(void) rewardBasedVideoAdDidOpen:(id)p0;
	@optional -(void) rewardBasedVideoAdWillLeaveApplication:(id)p0;
	@optional -(void) rewardBasedVideoAdDidClose:(id)p0;
	@optional -(void) rewardBasedVideoAdDidStartPlaying:(id)p0;
@end

@interface GADRewardBasedVideoAdDelegate : NSObject<GADRewardBasedVideoAdDelegate> {
}
	-(id) init;
@end

@interface GADSearchRequest : GADRequest {
}
	-(void) setBackgroundGradientFrom:(UIColor *)p0 toColor:(UIColor *)p1;
	-(void) setBackgroundSolid:(UIColor *)p0;
	-(UIColor *) anchorTextColor;
	-(void) setAnchorTextColor:(UIColor *)p0;
	-(UIColor *) backgroundColor;
	-(UIColor *) borderColor;
	-(void) setBorderColor:(UIColor *)p0;
	-(NSUInteger) borderThickness;
	-(void) setBorderThickness:(NSUInteger)p0;
	-(NSUInteger) borderType;
	-(void) setBorderType:(NSUInteger)p0;
	-(NSUInteger) callButtonColor;
	-(void) setCallButtonColor:(NSUInteger)p0;
	-(NSString *) customChannels;
	-(void) setCustomChannels:(NSString *)p0;
	-(UIColor *) descriptionTextColor;
	-(void) setDescriptionTextColor:(UIColor *)p0;
	-(NSString *) fontFamily;
	-(void) setFontFamily:(NSString *)p0;
	-(UIColor *) gradientFrom;
	-(UIColor *) gradientTo;
	-(UIColor *) headerColor;
	-(void) setHeaderColor:(UIColor *)p0;
	-(NSUInteger) headerTextSize;
	-(void) setHeaderTextSize:(NSUInteger)p0;
	-(NSString *) query;
	-(void) setQuery:(NSString *)p0;
	-(id) init;
@end

@protocol GADSwipeableBannerViewDelegate
	@optional -(void) adViewDidActivateAd:(id)p0;
	@optional -(void) adViewDidDeactivateAd:(id)p0;
@end

@interface GADSwipeableBannerViewDelegate : NSObject<GADSwipeableBannerViewDelegate> {
}
	-(id) init;
@end

@protocol GADVideoControllerDelegate
	@optional -(void) videoControllerDidPauseVideo:(id)p0;
	@optional -(void) videoControllerDidEndVideoPlayback:(id)p0;
	@optional -(void) videoControllerDidPlayVideo:(id)p0;
	@optional -(void) videoControllerDidUnmuteVideo:(id)p0;
	@optional -(void) videoControllerDidMuteVideo:(id)p0;
@end

@interface GADVideoControllerDelegate : NSObject<GADVideoControllerDelegate> {
}
	-(id) init;
@end

@interface GADVideoOptions : GADAdLoaderOptions {
}
	-(BOOL) clickToExpandRequested;
	-(void) setClickToExpandRequested:(BOOL)p0;
	-(BOOL) customControlsRequested;
	-(void) setCustomControlsRequested:(BOOL)p0;
	-(BOOL) startMuted;
	-(void) setStartMuted:(BOOL)p0;
	-(id) init;
@end

@protocol DFPBannerAdLoaderDelegate
	@required -(NSArray *) adLoader:(id)p0 didReceiveDFPBannerView:(id)p1;
	@required -(NSArray *) validBannerSizesForAdLoader:(id)p0;
@end

@interface DFPBannerAdLoaderDelegate : NSObject<DFPBannerAdLoaderDelegate> {
}
	-(id) init;
@end

@interface DFPBannerViewOptions : GADAdLoaderOptions {
}
	-(id) adSizeDelegate;
	-(void) setAdSizeDelegate:(id)p0;
	-(id) appEventDelegate;
	-(void) setAppEventDelegate:(id)p0;
	-(BOOL) enableManualImpressions;
	-(void) setEnableManualImpressions:(BOOL)p0;
	-(id) init;
@end

@interface DFPCustomRenderedAd : NSObject {
}
	-(void) finishedRenderingAdView:(UIView *)p0;
	-(void) recordClick;
	-(void) recordImpression;
	-(NSURL *) adBaseURL;
	-(NSString *) adHTML;
	-(id) init;
@end

@protocol DFPCustomRenderedBannerViewDelegate
	@required -(void) bannerView:(id)p0 didReceiveCustomRenderedAd:(id)p1;
@end

@interface DFPCustomRenderedBannerViewDelegate : NSObject<DFPCustomRenderedBannerViewDelegate> {
}
	-(id) init;
@end

@protocol DFPCustomRenderedInterstitialDelegate
	@required -(void) interstitial:(id)p0 didReceiveCustomRenderedAd:(id)p1;
@end

@interface DFPCustomRenderedInterstitialDelegate : NSObject<DFPCustomRenderedInterstitialDelegate> {
}
	-(id) init;
@end

@interface DFPRequest : GADRequest {
}
	-(NSArray *) categoryExclusions;
	-(void) setCategoryExclusions:(NSArray *)p0;
	-(NSDictionary *) customTargeting;
	-(void) setCustomTargeting:(NSDictionary *)p0;
	-(NSString *) publisherProvidedID;
	-(void) setPublisherProvidedID:(NSString *)p0;
	-(id) init;
@end

@interface GADRewardBasedVideoAd : NSObject {
}
	-(void) loadRequest:(id)p0 withAdUnitID:(NSString *)p1;
	-(void) presentFromRootViewController:(UIViewController *)p0;
	-(NSString *) adNetworkClassName;
	-(id) delegate;
	-(void) setDelegate:(id)p0;
	-(BOOL) isReady;
	-(NSString *) userIdentifier;
@end

@interface Google_MobileAds_AdChoicesView_AdChoicesViewAppearance : UIKit_UIView_UIViewAppearance {
}
@end

@interface GADAdChoicesView : UIView {
}
	-(id) init;
	-(id) initWithCoder:(NSCoder *)p0;
@end

@interface GADAudioVideoManager : NSObject {
}
	-(BOOL) audioSessionIsApplicationManaged;
	-(void) setAudioSessionIsApplicationManaged:(BOOL)p0;
	-(id) delegate;
	-(void) setDelegate:(id)p0;
	-(id) init;
@end

@interface Google_MobileAds_BannerView_BannerViewAppearance : UIKit_UIView_UIViewAppearance {
}
@end

@interface GADBannerView : UIView {
}
	-(void) loadRequest:(id)p0;
	-(NSString *) adNetworkClassName;
	-(struct trampoline_struct_ffi) adSize;
	-(void) setAdSize:(struct trampoline_struct_ffi)p0;
	-(id) adSizeDelegate;
	-(void) setAdSizeDelegate:(id)p0;
	-(NSString *) adUnitID;
	-(void) setAdUnitID:(NSString *)p0;
	-(BOOL) isAutoloadEnabled;
	-(void) setAutoloadEnabled:(BOOL)p0;
	-(id) delegate;
	-(void) setDelegate:(id)p0;
	-(BOOL) hasAutoRefreshed;
	-(id) inAppPurchaseDelegate;
	-(void) setInAppPurchaseDelegate:(id)p0;
	-(UIView *) mediatedAdView;
	-(UIViewController *) rootViewController;
	-(void) setRootViewController:(UIViewController *)p0;
	-(id) init;
	-(id) initWithCoder:(NSCoder *)p0;
	-(id) initWithFrame:(CGRect)p0;
	-(id) initWithAdSize:(struct trampoline_struct_ffi)p0 origin:(CGPoint)p1;
	-(id) initWithAdSize:(struct trampoline_struct_ffi)p0;
@end

@interface GADInterstitial : NSObject {
}
	-(void) loadRequest:(id)p0;
	-(void) presentFromRootViewController:(UIViewController *)p0;
	-(NSString *) adNetworkClassName;
	-(NSString *) adUnitID;
	-(id) delegate;
	-(void) setDelegate:(id)p0;
	-(BOOL) hasBeenUsed;
	-(id) inAppPurchaseDelegate;
	-(void) setInAppPurchaseDelegate:(id)p0;
	-(BOOL) isReady;
	-(id) initWithAdUnitID:(NSString *)p0;
@end

@interface Google_MobileAds_NativeAppInstallAdView_NativeAppInstallAdViewAppearance : UIKit_UIView_UIViewAppearance {
}
@end

@interface GADNativeAppInstallAdView : UIView {
}
	-(id) adChoicesView;
	-(void) setAdChoicesView:(id)p0;
	-(UIView *) bodyView;
	-(void) setBodyView:(UIView *)p0;
	-(UIView *) callToActionView;
	-(void) setCallToActionView:(UIView *)p0;
	-(UIView *) headlineView;
	-(void) setHeadlineView:(UIView *)p0;
	-(UIView *) iconView;
	-(void) setIconView:(UIView *)p0;
	-(UIView *) imageView;
	-(void) setImageView:(UIView *)p0;
	-(UIView *) mediaView;
	-(void) setMediaView:(UIView *)p0;
	-(id) nativeAppInstallAd;
	-(void) setNativeAppInstallAd:(id)p0;
	-(UIView *) priceView;
	-(void) setPriceView:(UIView *)p0;
	-(UIView *) starRatingView;
	-(void) setStarRatingView:(UIView *)p0;
	-(UIView *) storeView;
	-(void) setStoreView:(UIView *)p0;
	-(id) init;
	-(id) initWithCoder:(NSCoder *)p0;
	-(id) initWithFrame:(CGRect)p0;
@end

@interface Google_MobileAds_NativeContentAdView_NativeContentAdViewAppearance : UIKit_UIView_UIViewAppearance {
}
@end

@interface GADNativeContentAdView : UIView {
}
	-(id) adChoicesView;
	-(void) setAdChoicesView:(id)p0;
	-(UIView *) advertiserView;
	-(void) setAdvertiserView:(UIView *)p0;
	-(UIView *) bodyView;
	-(void) setBodyView:(UIView *)p0;
	-(UIView *) callToActionView;
	-(void) setCallToActionView:(UIView *)p0;
	-(UIView *) headlineView;
	-(void) setHeadlineView:(UIView *)p0;
	-(UIView *) imageView;
	-(void) setImageView:(UIView *)p0;
	-(UIView *) logoView;
	-(void) setLogoView:(UIView *)p0;
	-(id) mediaView;
	-(void) setMediaView:(id)p0;
	-(id) nativeContentAd;
	-(void) setNativeContentAd:(id)p0;
	-(id) init;
	-(id) initWithCoder:(NSCoder *)p0;
	-(id) initWithFrame:(CGRect)p0;
@end

@interface Google_MobileAds_NativeExpressAdView_NativeExpressAdViewAppearance : UIKit_UIView_UIViewAppearance {
}
@end

@interface GADNativeExpressAdView : UIView {
}
	-(void) loadRequest:(id)p0;
	-(void) setAdOptions:(NSArray *)p0;
	-(NSString *) adNetworkClassName;
	-(int) adSize;
	-(void) setAdSize:(int)p0;
	-(NSString *) adUnitID;
	-(void) setAdUnitID:(NSString *)p0;
	-(BOOL) isAutoloadEnabled;
	-(void) setAutoloadEnabled:(BOOL)p0;
	-(id) delegate;
	-(void) setDelegate:(id)p0;
	-(UIViewController *) rootViewController;
	-(void) setRootViewController:(UIViewController *)p0;
	-(id) videoController;
	-(void) setVideoController:(id)p0;
	-(id) initWithCoder:(NSCoder *)p0;
	-(id) initWithAdSize:(struct trampoline_struct_ffi)p0 origin:(CGPoint)p1;
	-(id) initWithAdSize:(struct trampoline_struct_ffi)p0;
@end

@interface Google_MobileAds_SearchBannerView_SearchBannerViewAppearance : Google_MobileAds_BannerView_BannerViewAppearance {
}
@end

@interface GADSearchBannerView : GADBannerView {
}
	-(id) adSizeDelegate;
	-(void) setAdSizeDelegate:(id)p0;
	-(id) init;
	-(id) initWithCoder:(NSCoder *)p0;
	-(id) initWithFrame:(CGRect)p0;
	-(id) initWithAdSize:(struct trampoline_struct_ffi)p0 origin:(CGPoint)p1;
	-(id) initWithAdSize:(struct trampoline_struct_ffi)p0;
@end

@interface GADVideoController : NSObject {
}
	-(BOOL) hasVideoContent;
	-(void) pause;
	-(void) play;
	-(void) setMute:(BOOL)p0;
	-(double) aspectRatio;
	-(id) delegate;
	-(void) setDelegate:(id)p0;
	-(BOOL) clickToExpandEnabled;
	-(BOOL) customControlsEnabled;
	-(id) init;
@end

@interface Google_MobileAds_DoubleClick_BannerView_BannerViewAppearance : Google_MobileAds_BannerView_BannerViewAppearance {
}
@end

@interface DFPBannerView : GADBannerView {
}
	-(void) recordImpression;
	-(void) resize:(struct trampoline_struct_ffi)p0;
	-(void) setAdOptions:(NSArray *)p0;
	-(void) setValidAdSizesWithSizes:(struct trampoline_struct_ffi)p0, ...;
	-(id) adSizeDelegate;
	-(void) setAdSizeDelegate:(id)p0;
	-(NSString *) adUnitID;
	-(void) setAdUnitID:(NSString *)p0;
	-(id) appEventDelegate;
	-(void) setAppEventDelegate:(id)p0;
	-(id) correlator;
	-(void) setCorrelator:(id)p0;
	-(id) customRenderedBannerViewDelegate;
	-(void) setCustomRenderedBannerViewDelegate:(id)p0;
	-(BOOL) enableManualImpressions;
	-(void) setEnableManualImpressions:(BOOL)p0;
	-(NSArray *) validAdSizes;
	-(void) setValidAdSizes:(NSArray *)p0;
	-(id) videoController;
	-(id) init;
	-(id) initWithCoder:(NSCoder *)p0;
	-(id) initWithFrame:(CGRect)p0;
	-(id) initWithAdSize:(struct trampoline_struct_ffi)p0 origin:(CGPoint)p1;
	-(id) initWithAdSize:(struct trampoline_struct_ffi)p0;
@end

@interface DFPInterstitial : GADInterstitial {
}
	-(NSString *) adUnitID;
	-(id) appEventDelegate;
	-(void) setAppEventDelegate:(id)p0;
	-(id) correlator;
	-(void) setCorrelator:(id)p0;
	-(id) customRenderedInterstitialDelegate;
	-(void) setCustomRenderedInterstitialDelegate:(id)p0;
	-(id) initWithAdUnitID:(NSString *)p0;
@end

@protocol MSPushDelegate
	@optional -(void) push:(id)p0 didReceivePushNotification:(id)p1;
@end

@interface MSPushDelegate : NSObject<MSPushDelegate> {
}
	-(id) init;
@end

@interface Microsoft_AppCenter_Push_iOS_PushDelegate : NSObject<MSPushDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) push:(id)p0 didReceivePushNotification:(id)p1;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface MSPush : NSObject {
}
	-(id) init;
@end

@interface MSPushNotification : NSObject {
}
	-(NSDictionary *) customData;
	-(NSString *) message;
	-(NSString *) title;
	-(id) init;
@end

@protocol MSCrashesDelegate
	@optional -(BOOL) crashes:(id)p0 shouldProcessErrorReport:(id)p1;
	@optional -(NSArray *) attachmentsWithCrashes:(id)p0 forErrorReport:(id)p1;
	@optional -(void) crashes:(id)p0 willSendErrorReport:(id)p1;
	@optional -(void) crashes:(id)p0 didSucceedSendingErrorReport:(id)p1;
	@optional -(void) crashes:(id)p0 didFailSendingErrorReport:(id)p1 withError:(NSError *)p2;
@end

@interface MSCrashesDelegate : NSObject<MSCrashesDelegate> {
}
	-(id) init;
@end

@interface MSCrashes : NSObject {
}
	-(id) init;
@end

@protocol MSCrashHandlerSetupDelegate
	@optional -(void) willSetUpCrashHandlers;
	@optional -(void) didSetUpCrashHandlers;
	@optional -(BOOL) shouldEnableUncaughtExceptionHandler;
@end

@interface MSCrashHandlerSetupDelegate : NSObject<MSCrashHandlerSetupDelegate> {
}
	-(id) init;
@end

@interface MSErrorAttachmentLog : NSObject {
}
	-(id) init;
@end

@interface MSErrorReport : NSObject {
}
	-(NSDate *) appErrorTime;
	-(NSUInteger) appProcessIdentifier;
	-(NSDate *) appStartTime;
	-(id) device;
	-(NSString *) exceptionName;
	-(NSString *) exceptionReason;
	-(NSString *) incidentIdentifier;
	-(BOOL) isAppKill;
	-(NSString *) reporterKey;
	-(NSString *) signal;
	-(id) init;
@end

@interface MSException : NSObject {
}
	-(BOOL) isEqual:(id)p0;
	-(NSArray *) frames;
	-(void) setFrames:(NSArray *)p0;
	-(NSArray *) innerExceptions;
	-(void) setInnerExceptions:(NSArray *)p0;
	-(NSString *) message;
	-(void) setMessage:(NSString *)p0;
	-(NSString *) stackTrace;
	-(void) setStackTrace:(NSString *)p0;
	-(NSString *) type;
	-(void) setType:(NSString *)p0;
	-(NSString *) wrapperSdkName;
	-(void) setWrapperSdkName:(NSString *)p0;
	-(id) init;
@end

@interface MSStackFrame : NSObject {
}
	-(BOOL) isEqual:(id)p0;
	-(NSString *) address;
	-(void) setAddress:(NSString *)p0;
	-(NSString *) className;
	-(void) setClassName:(NSString *)p0;
	-(NSString *) code;
	-(void) setCode:(NSString *)p0;
	-(NSString *) fileName;
	-(void) setFileName:(NSString *)p0;
	-(NSNumber *) lineNumber;
	-(void) setLineNumber:(NSNumber *)p0;
	-(NSString *) methodName;
	-(void) setMethodName:(NSString *)p0;
	-(id) init;
@end

@interface MSWrapperCrashesHelper : NSObject {
}
	-(id) init;
@end

@interface MSWrapperException : NSObject {
}
	-(id) modelException;
	-(void) setModelException:(id)p0;
	-(NSData *) exceptionData;
	-(void) setExceptionData:(NSData *)p0;
	-(NSNumber *) processId;
	-(void) setProcessId:(NSNumber *)p0;
	-(id) init;
@end

@interface MSWrapperExceptionManager : NSObject {
}
	-(id) init;
@end

@interface Microsoft_AppCenter_Crashes_iOS_Bindings_CrashesInitializationDelegate : NSObject<MSCrashHandlerSetupDelegate> {
}
	-(void) release;
	-(id) retain;
	-(int) xamarinGetGCHandle;
	-(void) xamarinSetGCHandle: (int) gchandle;
	-(void) willSetUpCrashHandlers;
	-(void) didSetUpCrashHandlers;
	-(BOOL) shouldEnableUncaughtExceptionHandler;
	-(BOOL) conformsToProtocol:(void *)p0;
	-(id) init;
@end

@interface MSAppCenter : NSObject {
}
	-(id) init;
@end

@interface MSCustomProperties : NSObject {
}
	-(void) clearPropertyForKey:(NSString *)p0;
	-(void) setString:(NSString *)p0 forKey:(NSString *)p1;
	-(void) setNumber:(NSNumber *)p0 forKey:(NSString *)p1;
	-(void) setBool:(BOOL)p0 forKey:(NSString *)p1;
	-(void) setDate:(NSDate *)p0 forKey:(NSString *)p1;
	-(id) init;
@end

@interface MSWrapperSdk : NSObject {
}
	-(BOOL) isEqual:(id)p0;
	-(NSString *) liveUpdateDeploymentKey;
	-(NSString *) liveUpdatePackageHash;
	-(NSString *) liveUpdateReleaseLabel;
	-(NSString *) wrapperRuntimeVersion;
	-(NSString *) wrapperSdkName;
	-(NSString *) wrapperSdkVersion;
	-(id) init;
	-(id) initWithWrapperSdkVersion:(NSString *)p0 wrapperSdkName:(NSString *)p1 wrapperRuntimeVersion:(NSString *)p2 liveUpdateReleaseLabel:(NSString *)p3 liveUpdateDeploymentKey:(NSString *)p4 liveUpdatePackageHash:(NSString *)p5;
@end

@interface MSDevice : MSWrapperSdk {
}
	-(BOOL) isEqual:(id)p0;
	-(NSString *) appBuild;
	-(NSString *) appNamespace;
	-(NSString *) appVersion;
	-(NSString *) carrierCountry;
	-(NSString *) carrierName;
	-(NSString *) locale;
	-(NSString *) model;
	-(NSString *) oemName;
	-(NSNumber *) osApiLevel;
	-(NSString *) osBuild;
	-(NSString *) osName;
	-(NSString *) osVersion;
	-(NSString *) screenSize;
	-(NSString *) sdkName;
	-(NSString *) sdkVersion;
	-(NSNumber *) timeZoneOffset;
	-(id) init;
@end

@interface MSLogger : NSObject {
}
	-(id) init;
@end

@protocol MSService
	@optional +(BOOL) isEnabled;
	@optional +(void) setEnabled:(BOOL)p0;
@end

@interface MSService : NSObject<MSService> {
}
	-(id) init;
@end

@interface MSServiceAbstract : NSObject {
}
	-(id) init;
@end

@interface MSWrapperLogger : NSObject {
}
	-(id) init;
@end

@interface MSAnalytics : NSObject {
}
	-(id) init;
@end

@protocol MSAnalyticsDelegate
	@optional -(void) analytics:(id)p0 willSendEventLog:(id)p1;
	@optional -(void) analytics:(id)p0 didSucceedSendingEventLog:(id)p1;
	@optional -(void) analytics:(id)p0 didFailSendingEventLog:(id)p1 withError:(NSError *)p2;
@end

@interface MSAnalyticsDelegate : NSObject<MSAnalyticsDelegate> {
}
	-(id) init;
@end

@interface MSLogWithProperties : NSObject {
}
	-(NSDictionary <NSString *, NSString *>*) properties;
	-(void) setProperties:(NSDictionary <NSString *, NSString *>*)p0;
	-(id) init;
@end

@interface MSEventLog : MSLogWithProperties {
}
	-(NSString *) eventId;
	-(void) setEventId:(NSString *)p0;
	-(NSString *) name;
	-(void) setName:(NSString *)p0;
	-(NSDictionary <NSString *, NSString *>*) properties;
	-(void) setProperties:(NSDictionary <NSString *, NSString *>*)p0;
	-(id) init;
@end

@interface MSPageLog : MSLogWithProperties {
}
	-(NSString *) name;
	-(void) setName:(NSString *)p0;
	-(NSDictionary <NSString *, NSString *>*) properties;
	-(void) setProperties:(NSDictionary <NSString *, NSString *>*)p0;
	-(id) init;
@end



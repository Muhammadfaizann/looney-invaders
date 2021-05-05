-ignorewarnings
-keep class org.apache.** { *; }
-keep class com.init.looney_invaders.MainApplication.** { *; }

-keepnames class android.support.multidex.MultiDex

-dontwarn com.microsoft.appcenter.push.FirebaseUtils.*






-dontnote io.presage.**
-keep class io.presage.** { *; }
-keepclassmembers class io.presage.** { *; }

-dontnote com.ogury.**
-keep class com.ogury.** { *; }
-keepclassmembers class com.ogury.** { *; }

-dontwarn io.presage.R$raw

-dontwarn io.presage.R$drawable

-dontwarn io.presage.R$layout

-dontwarn io.presage.R$string

-keep class com.moat.** { *; }
-dontwarn com.moat.**

-keep class com.iab.** { *; }
-dontwarn com.iab.**

-dontnote io.presage.**
-keep class io.presage.** { *; }
-keepclassmembers class io.presage.** { *; }

-dontnote com.ogury.**
-keep class com.ogury.** { *; }
-keepclassmembers class com.ogury.** { *; }

-dontwarn io.presage.R$raw

-dontwarn io.presage.R$drawable

-dontwarn io.presage.R$layout

-dontwarn io.presage.R$string

-keep class com.moat.** { *; }
-dontwarn com.moat.**

-keep class com.iab.** { *; }
-dontwarn com.iab.**

-dontnote com.ogury.consent.**
-keep class com.ogury.consent.** { *; }
-keepclassmembers class com.ogury.consent.** { *; }

-dontnote com.ogury.cm.**
-keep class com.ogury.cm.** { *; }
-keepclassmembers class com.ogury.cm.** { *; }

-dontwarn com.ogury.consent.R$raw

-dontwarn com.ogury.consent.R$drawable

-dontwarn com.ogury.consent.R$layout

-dontwarn com.ogury.consent.R$string

-keep class com.google.android.finsky.billing.**
-keep class com.android.vending.** { *; }
-keep class com.android.billingclient.api.** { *; }
# Add project specific ProGuard rules here.
# You can control the set of applied configuration files using the
# proguardFiles setting in build.gradle.
#
# For more details, see
#   http://developer.android.com/guide/developing/tools/proguard.html

# If your project uses WebView with JS, uncomment the following
# and specify the fully qualified class name to the JavaScript interface
# class:
#-keepclassmembers class fqcn.of.javascript.interface.for.webview {
#   public *;
#}

# Uncomment this to preserve the line number information for
# debugging stack traces.
#-keepattributes SourceFile,LineNumberTable

# If you keep the line number information, uncomment this to
# hide the original source file name.
#-renamesourcefileattribute SourceFile


-keep class io.presage.core.** { *; }
-dontwarn io.presage.core.**



-keep public class com.smaato.sdk.** {
    public protected <fields>;
    public protected <methods>;
}

-keep public interface com.smaato.sdk.** {
    public protected <fields>;
    public protected <methods>;
}





# Do not warn about unknown referenced methods if compiling against older Android veresions or Google Play Services Identifier APIs without reflection
-dontwarn com.applovin.**
-dontusemixedcaseclassnames
-printmapping proguard.map
-keepattributes Signature,InnerClasses,Exceptions,*Annotation*
-keep public class com.applovin.sdk.AppLovinSdk { *; }
-keep public class com.applovin.sdk.AppLovin* { public protected *; }
-keep public class com.applovin.nativeAds.AppLovin* { public protected *; }
-keep public class com.applovin.adview.* { public protected *; }
-keep public class com.applovin.mediation.* { public protected *; }
-keep public class com.applovin.mediation.ads.* { public protected *; }
-keep public class com.applovin.communicator.* { public protected *; }
-keep public class com.applovin.impl.sdk.utils.BundleUtils { public protected *; }
-keep public class com.applovin.impl.sdk.utils.AppKilledService { *; }
-keep public class com.applovin.impl.**.AppLovin* { public protected *; }
-keep public class com.applovin.impl.**.*Impl { public protected *; }
-keep public class com.applovin.impl.adview.AppLovinOrientationAwareInterstitialActivity { *; }
-keepclassmembers class com.applovin.sdk.AppLovinSdkSettings { private java.util.Map localSettings; }
-keep class com.applovin.mediation.adapters.** { *; }
-keep class com.applovin.mediation.adapter.** { *; }
-keep class com.google.android.gms.ads.identifier.** { *; }
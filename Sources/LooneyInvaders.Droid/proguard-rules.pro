-ignorewarnings
-keep class org.apache.** { *; }
-keep class com.init.looney_invaders.MainApplication.** { *; }

-keepnames class android.support.multidex.MultiDex

-dontwarn com.microsoft.appcenter.push.FirebaseUtils.*

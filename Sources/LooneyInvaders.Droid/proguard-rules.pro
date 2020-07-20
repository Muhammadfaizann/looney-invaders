-ignorewarnings
-keep class org.apache.** { *; }

-keep class com.google.android.gms.** { *; }
-keep class com.google.firebase.** { *; }
-keep class com.mobvista.msdk.** { *; }
-keep class com.google.android.exoplayer2.** { *; }
-keep class com.flurry.android.** { *; }
-keep class io.presage.IADHandler

-keep class com.init.looney_invaders.MainApplication.** { *; }

-dontwarn com.microsoft.appcenter.push.FirebaseUtils.*
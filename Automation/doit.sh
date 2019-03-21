rm ./com.init.looney_invaders_old.apk
rm ./com.init.looney_invaders.apk
cp ../Sources/LooneyInvaders.Droid/bin/Android/Release/com.init.looney_invaders.apk ./com.init.looney_invaders_old.apk 
jarsigner -verbose -sigalg SHA1withRSA -digestalg SHA1 -keystore ./tpetrovic_INIT/tpetrovic_INIT.keystore ./com.init.looney_invaders_old.apk tpetrovic_INIT
~/Library/Developer/Xamarin/android-sdk-macosx/build-tools/27.0.3/zipalign -f -v 4 ./com.init.looney_invaders_old.apk ./com.init.looney_invaders.apk
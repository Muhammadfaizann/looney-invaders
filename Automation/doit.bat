"c:\Program Files (x86)\Java\jdk1.7.0_55\bin\jarsigner.exe" -verbose -sigalg SHA1withRSA -digestalg SHA1 -keystore "C:\temp\tpetrovic_INIT\tpetrovic_INIT.keystore" c:\temp\com.init.looney_invaders_old.apk tpetrovic_INIT

"C:\Program Files (x86)\Android\android-sdk\build-tools\19.1.0\zipalign.exe" -f -v 4 c:\temp\com.init.looney_invaders_old.apk c:\temp\com.init.looney_invaders.apk
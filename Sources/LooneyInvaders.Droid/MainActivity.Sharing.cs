using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.Hardware;
using Android.Widget;
//using Com.Appodeal.Ads;
using Debug = System.Diagnostics.Debug;
using FileProvider = Android.Support.V4.Content.FileProvider;
using JavaFile = Java.IO.File;
using LooneyInvaders.Services.App42;

namespace LooneyInvaders.Droid
{
    public partial class MainActivity : Activity, ISensorEventListener, IApp42ServiceInitialization
    {
        private static JavaFile StoreScreenShot(Bitmap picture)
        {
            var folder = $"{Android.OS.Environment.ExternalStorageDirectory}{JavaFile.Separator}LooneyInvaders";
            var extFileName = $"{folder}{JavaFile.Separator}looney_invaders_{ DateTime.Now.ToString("yyyy-MM-dd_HH-mm-ss")}.jpeg";
            try
            {
                if (!Directory.Exists(folder))
                {
                    Directory.CreateDirectory(folder);
                }
                var file = new JavaFile(extFileName);
                using (var fs = new FileStream(extFileName, FileMode.OpenOrCreate))
                {
                    try
                    {
                        picture.Compress(Bitmap.CompressFormat.Jpeg, 96, fs);
                    }
                    finally
                    {
                        fs.Flush();
                        fs.Close();
                    }
                }

                return file;
            }
            catch (UnauthorizedAccessException ex)
            {
                Debug.WriteLine("ERROR: " + ex.Message);
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine("ERROR: " + ex.Message);
                return null;
            }
        }

        public void ShareOnSocialNetworkHandler(string network, Stream stream)
        {
            stream.Position = 0;

            var drawable = Android.Graphics.Drawables.Drawable.CreateFromStream(stream, "looney");
            var bitmap = ((Android.Graphics.Drawables.BitmapDrawable)drawable).Bitmap;
            using var file = StoreScreenShot(bitmap);

            if (file != null)
            {
                ShareOnSocialNetwork(network, file);
            }
        }

        public void ShareOnSocialNetwork<TFile>(string network, TFile file) where TFile : JavaFile
        {
            try
            {
                //https://forums.xamarin.com/discussion/151985/xamarin-fileprovider-cant-open-files-in-android
                var uri = FileProvider.GetUriForFile(this, Application.Context.PackageName + ".fileprovider", file);
                var i = new Intent(Intent.ActionSend);

                // if (network == "facebook") i.SetPackage("com.facebook.katana");
                // else if (network == "twitter") i.SetPackage("com.twitter.android");
                // else return;
                i.AddFlags(ActivityFlags.GrantReadUriPermission);
                i.PutExtra(Intent.ExtraSubject, "Looney Invaders score");
                i.PutExtra(Intent.ExtraText, "Looney Invaders score");
                i.PutExtra(Intent.ExtraStream, uri);
                i.SetType("image/*");

                StartActivity(Intent.CreateChooser(i, "Looney Invaders score"));
            }
            catch (ActivityNotFoundException)
            {
                Toast.MakeText(this, "No App Available", ToastLength.Long).Show();
            }
            catch (Exception ex)
            {
                var mess = ex.Message;
                Debug.WriteLine($"Exception taken in {nameof(ShareOnSocialNetwork)}: {mess}");
                Debug.WriteLine(ex.StackTrace);
            }
        }
    }
}

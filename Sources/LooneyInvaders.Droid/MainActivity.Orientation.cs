using System;
using Android.App;
using Android.Content.PM;
using Android.Hardware;
using Android.Views;
using Com.Appodeal.Ads;
using LooneyInvaders.Services.App42;

namespace LooneyInvaders.Droid
{
    public partial class MainActivity : Activity, ISensorEventListener, IApp42ServiceInitialization, IInterstitialCallbacks, IBannerCallbacks
    {
        private SensorManager _sensorManager;

        private const float Yaw = 0;
        private const float Tilt = 0;
        private float _pitch;

        protected float[] GravSensorVals;
        protected float[] MagSensorVals;

        private ScreenOrientation GetScreenOrientation()
        {
            CheckGamePauseState?.Invoke();

            ScreenOrientation orientation;
            var rotation = WindowManager?.DefaultDisplay?.Rotation;

            var dm = new Android.Util.DisplayMetrics();
            WindowManager?.DefaultDisplay?.GetMetrics(dm);

            if ((rotation == SurfaceOrientation.Rotation0 || rotation == SurfaceOrientation.Rotation180) && dm.HeightPixels > dm.WidthPixels
                || (rotation == SurfaceOrientation.Rotation90 || rotation == SurfaceOrientation.Rotation270) && dm.WidthPixels > dm.HeightPixels)
            {   // The device's natural orientation is portrait
                switch (rotation)
                {
                    case SurfaceOrientation.Rotation0:
                        orientation = ScreenOrientation.Portrait;
                        break;
                    case SurfaceOrientation.Rotation90:
                        orientation = ScreenOrientation.Landscape;
                        break;
                    case SurfaceOrientation.Rotation180:
                        orientation = ScreenOrientation.ReversePortrait;
                        break;
                    case SurfaceOrientation.Rotation270:
                        orientation = ScreenOrientation.ReverseLandscape;
                        break;
                    default:
                        orientation = ScreenOrientation.Portrait;
                        break;
                }
            }
            else
            {   // The device's natural orientation is landscape or if the device is square
                switch (rotation)
                {
                    case SurfaceOrientation.Rotation0:
                        orientation = ScreenOrientation.Landscape;
                        break;
                    case SurfaceOrientation.Rotation90:
                        orientation = ScreenOrientation.Portrait;
                        break;
                    case SurfaceOrientation.Rotation180:
                        orientation = ScreenOrientation.ReverseLandscape;
                        break;
                    case SurfaceOrientation.Rotation270:
                        orientation = ScreenOrientation.ReversePortrait;
                        break;
                    default:
                        orientation = ScreenOrientation.Landscape;
                        break;
                }
            }

            return orientation;
        }

        protected float[] LowPass(float[] input, float[] output)
        {
            if (input == null) { return null; }
            if (output == null) { return input; }

            for (var i = 0; i < input.Length; i++)
            {
                output[i] = output[i] + 0.2f * (input[i] - output[i]);
            }

            return output;
        }

        private void GetGyro(out float yaw, out float tilt, out float pitch)
        {
            yaw = Yaw;
            tilt = Tilt;
            pitch = (float)Math.Round(_pitch, 3);
        }

        void ISensorEventListener.OnSensorChanged(SensorEvent e)
        {
            if (e == null || e.Sensor == null) { return; }

            var vals = new float[e.Values.Count];
            var i = 0;
            foreach (var f in e.Values)
            {
                vals[i++] = f;
            }

            if (e.Sensor.Type == SensorType.Accelerometer)
            {
                GravSensorVals = LowPass(vals, GravSensorVals);
            }
            else if (e.Sensor.Type == SensorType.MagneticField)
            {
                MagSensorVals = LowPass(vals, MagSensorVals);
            }
            if (GravSensorVals != null && MagSensorVals != null)
            {
                var r = new float[9];
                var I = new float[9];
                var success = SensorManager.GetRotationMatrix(r, I, GravSensorVals, MagSensorVals);
                if (success)
                {
                    var orientationData = new float[3];
                    SensorManager.GetOrientation(r, orientationData);
                    if (GetScreenOrientation() == ScreenOrientation.ReverseLandscape)
                    {
                        //azimuth = orientationData[0];
                        _pitch = (float)(orientationData[1] * 180 / Math.PI) + 180;
                        //roll = orientationData[2];
                    }
                    else
                    {
                        //azimuth = orientationData[0];
                        _pitch = (float)(orientationData[1] * 180 / Math.PI);
                        //roll = orientationData[2];
                    }
                }

            } //fallback if no mag sensor to work just with gravity
            else if (e.Sensor.Type == SensorType.Accelerometer)
            {
                var y = e.Values[1];
                if (y > 10) y = 10;
                if (y < -10) y = -10;
                if (GetScreenOrientation() == ScreenOrientation.ReverseLandscape)
                {
                    _pitch = (float)(Math.Asin(y / 10) * 180 / Math.PI);
                }
                else
                {
                    _pitch = -(float)(Math.Asin(y / 10) * 180 / Math.PI);
                }
            }
        }

        void ISensorEventListener.OnAccuracyChanged(Sensor sensor, SensorStatus accuracy) { }
    }
}

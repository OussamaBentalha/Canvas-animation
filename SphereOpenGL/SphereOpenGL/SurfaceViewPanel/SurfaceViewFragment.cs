
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Hardware;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace SphereOpenGL.SurfaceViewPanel
{
    public class SurfaceViewFragment : Fragment, ISensorEventListener
    {
        BubblePanel bubblePanel = null;

        SensorManager mSensorManager;
        Sensor mAccelerometer;

        public override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            /*DisplayMetrics dm = Resources.DisplayMetrics;
            Constants.SCREEN_WIDTH = dm.WidthPixels;
            Constants.SCREEN_HEIGHT = dm.HeightPixels;*/

            mSensorManager = (SensorManager) Context.GetSystemService(Context.SensorService);
            mAccelerometer = mSensorManager.GetDefaultSensor(SensorType.Accelerometer);
        }

        public override void OnViewCreated(View view, Bundle savedInstanceState)
        {
            base.OnViewCreated(view, savedInstanceState);
            bubblePanel = (BubblePanel)View.FindViewById(Resource.Id.bubblePanel);
        }

        public override void OnResume()
        {
            base.OnResume();
            mSensorManager.RegisterListener(this, mAccelerometer, SensorDelay.Game);
        }

        public override void OnPause()
        {
            base.OnPause();
            mSensorManager.UnregisterListener(this);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            // Use this to return your custom view for this Fragment 
            return inflater.Inflate(Resource.Layout.SurfaceViewFragmentLayout, container, false);
        }

        public void OnSensorChanged(SensorEvent e)
        {
            if (e.Sensor.Type == SensorType.Accelerometer)
            {
                bubblePanel.OnSensorEvent(e);
            }
        }

        public void OnAccuracyChanged(Sensor sensor, [GeneratedEnum] SensorStatus accuracy)
        {
        }
    }
}

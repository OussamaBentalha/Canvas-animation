
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Opengl;
using Android.OS;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace SphereOpenGL
{
    public class OpenGLES20Fragment : Fragment
    {

        public override void OnCreate(Bundle savedInstanceState)
        {
            Console.Write(" ---------------- OnCreate");
            base.OnCreate(savedInstanceState);
        }

        public override View OnCreateView(LayoutInflater inflater, ViewGroup container, Bundle savedInstanceState)
        {
            Console.Write(" ---------------- OnCreateView");

            // Use this to retrive our GLSurfaceView (OPENGL)
            View view = inflater.Inflate(Resource.Layout.OpenGLES20FragmentLayout, container, false);


            return view;
        }

    }
}

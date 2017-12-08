using Android.App;
using Android.Widget;
using Android.OS;
using SphereOpenGL.CanvasDrawable;
using SphereOpenGL.SurfaceViewPanel;

namespace SphereOpenGL
{
    [Activity(Label = "SphereOpenGL", MainLauncher = true, Icon = "@mipmap/icon", ScreenOrientation = Android.Content.PM.ScreenOrientation.Portrait)]
    public class MainActivity : Activity
    {
        
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);




            //OpenGLES20Fragment openGLFragment = new OpenGLES20Fragment();

            //BubbleFragment bubbleFragment = new BubbleFragment();

            SurfaceViewFragment surfaceFragment = new SurfaceViewFragment();

            FragmentManager.BeginTransaction().Add(Resource.Id.frameLayout1, surfaceFragment).Commit();
        }
    }
}


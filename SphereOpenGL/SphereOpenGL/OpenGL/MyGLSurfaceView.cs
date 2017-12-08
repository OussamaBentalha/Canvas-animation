using System;
using Android.Content;
using Android.Opengl;
using Android.Runtime;
using Android.Util;

namespace SphereOpenGL
{
    [Register("com.eyes.SphereOpenGL.MyGLSurfaceView")]
    public class MyGLSurfaceView : GLSurfaceView
    {
        private MyGLRenderer mRenderer;

        protected MyGLSurfaceView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public MyGLSurfaceView(Context context) : base (context)
        {
            // Create an OpenGL ES 2.0 context.
            SetEGLContextClientVersion(2);

            // Set the Renderer for drawing on the GLSurfaceView
            mRenderer = new MyGLRenderer();
            SetRenderer(mRenderer);
            // Render the view only when there is a change in the drawing data
            this.RenderMode = Rendermode.WhenDirty;
        }

        public MyGLSurfaceView(Context context, IAttributeSet attributes) : base(context, attributes)
        {
            // Create an OpenGL ES 2.0 context.
            SetEGLContextClientVersion(2);

            // Set the Renderer for drawing on the GLSurfaceView
            mRenderer = new MyGLRenderer();
            SetRenderer(mRenderer);

            // Render the view only when there is a change in the drawing data
            this.RenderMode = Rendermode.WhenDirty;
        }

    }
}

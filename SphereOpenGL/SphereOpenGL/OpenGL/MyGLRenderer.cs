using System;
using Android.Opengl;
using Android.Runtime;
using Javax.Microedition.Khronos.Egl;
using Javax.Microedition.Khronos.Opengles;

namespace SphereOpenGL
{
    public class MyGLRenderer : Java.Lang.Object, GLSurfaceView.IRenderer
    {

        private Triangle mTriangle;

        public MyGLRenderer()
        {
        }

		public void OnSurfaceCreated(IGL10 gl, Javax.Microedition.Khronos.Egl.EGLConfig config)
		{
            // Set the background frame color
            GLES20.GlClearColor(1.0f, 1.0f, 1.0f, 1.0f);

            mTriangle = new Triangle();
		}

        public void OnDrawFrame(IGL10 gl)
        {
            // Redraw background color
            GLES20.GlClear(GLES20.GlColorBufferBit);

            mTriangle.draw();
        }

        public void OnSurfaceChanged(IGL10 gl, int width, int height)
        {
            GLES20.GlViewport(0, 0, width, height);
        }

        public static int LoadShader(int type, String shaderCode)
        {

            // create a vertex shader type (GLES20.GL_VERTEX_SHADER)
            // or a fragment shader type (GLES20.GL_FRAGMENT_SHADER)
            int shader = GLES20.GlCreateShader(type);

            // add the source code to the shader and compile it
            GLES20.GlShaderSource(shader, shaderCode);
            GLES20.GlCompileShader(shader);

            return shader;
        }
    }
}

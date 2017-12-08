using System;
using Android.Opengl;
using Java.Nio;

namespace SphereOpenGL
{
    public class Triangle
    {

        private FloatBuffer vertexBuffer;

        private int mPositionHandle;
        private int mColorHandle;

        private readonly int vertexCount = triangleCoords.Length / COORDS_PER_VERTEX;
        private readonly int vertexStride = COORDS_PER_VERTEX * 4; // 4 bytes per vertex

        // number of coordinates per vertex in this array
        static readonly int COORDS_PER_VERTEX = 3;

        static float[] triangleCoords = {   // in counterclockwise order:
             0.0f,  0.622008459f, 0.0f, // top
            -0.5f, -0.311004243f, 0.0f, // bottom left
             0.5f, -0.311004243f, 0.0f  // bottom right
        };

        // Set color with red, green, blue and alpha (opacity) values
        float[] color = { 0.63671875f, 0.76953125f, 0.22265625f, 1.0f };

        private readonly String vertexShaderCode =
            "attribute vec4 vPosition;" +
            "void main() {" +
            "  gl_Position = vPosition;" +
            "}";

        private readonly String fragmentShaderCode =
            "precision mediump float;" +
            "uniform vec4 vColor;" +
            "void main() {" +
            "  gl_FragColor = vColor;" +
            "}";

        private readonly int mProgram;

        public Triangle()
        {
            // initialize vertex byte buffer for shape coordinates
            ByteBuffer bb = ByteBuffer.AllocateDirect(
                    // (number of coordinate values * 4 bytes per float)
                    triangleCoords.Length * 4);
            // use the device hardware's native byte order
            bb.Order(ByteOrder.NativeOrder());

            // create a floating point buffer from the ByteBuffer
            vertexBuffer = bb.AsFloatBuffer();
            // add the coordinates to the FloatBuffer
            vertexBuffer.Put(triangleCoords);
            // set the buffer to read the first coordinate
            vertexBuffer.Position(0);

            int vertexShader = MyGLRenderer.LoadShader(GLES20.GlVertexShader,
                                        vertexShaderCode);
            int fragmentShader = MyGLRenderer.LoadShader(GLES20.GlFragmentShader,
                                            fragmentShaderCode);

            // create empty OpenGL ES Program
            mProgram = GLES20.GlCreateProgram();

            // add the vertex shader to program
            GLES20.GlAttachShader(mProgram, vertexShader);

            // add the fragment shader to program
            GLES20.GlAttachShader(mProgram, fragmentShader);

            // creates OpenGL ES program executables
            GLES20.GlLinkProgram(mProgram);
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

        public void draw()
        {
            // Add program to OpenGL ES environment
            GLES20.GlUseProgram(mProgram);

            // get handle to vertex shader's vPosition member
            mPositionHandle = GLES20.GlGetAttribLocation(mProgram, "vPosition");

            // Enable a handle to the triangle vertices
            GLES20.GlEnableVertexAttribArray(mPositionHandle);

            // Prepare the triangle coordinate data
            GLES20.GlVertexAttribPointer(mPositionHandle, COORDS_PER_VERTEX,
                                         GLES20.GlFloat, false,
                                         vertexStride, vertexBuffer);

            // get handle to fragment shader's vColor member
            mColorHandle = GLES20.GlGetUniformLocation(mProgram, "vColor");

            // Set color for drawing the triangle
            GLES20.GlUniform4fv(mColorHandle, 1, color, 0);

            // Draw the triangle
            GLES20.GlDrawArrays(GLES20.GlTriangles, 0, vertexCount);

            // Disable vertex array
            GLES20.GlDisableVertexAttribArray(mPositionHandle);
        }
    }
}

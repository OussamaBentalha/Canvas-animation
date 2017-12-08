using System;
using Java.Lang;
using Android.Views;
using Android.Graphics;
using Android.Util;

namespace SphereOpenGL.SurfaceViewPanel
{
    public class BubbleThread : Thread
    {
        public static int MAX_FPS = 30;
        private double averageFPS;
        private ISurfaceHolder surfaceHolder;
        private BubblePanel bubblePanel;
        public bool running { get; set; }
        public static Canvas canvas;


        public BubbleThread(ISurfaceHolder surfaceHolder, BubblePanel bubblePanel) : base()
        {
            this.surfaceHolder = surfaceHolder;
            this.bubblePanel = bubblePanel;
        }

        public override void Run()
        {
            //base.Run();

            long startTime, waitTime;
            long timeMillis = 1000 / MAX_FPS;
            int frameCount = 0;
            long totalTime = 0;
            long targetTime = 1000 / MAX_FPS;

            while(running)
            {
                startTime = JavaSystem.NanoTime();
                canvas = null;

                try
                {
                    bubblePanel.Update();

                    canvas = surfaceHolder.LockCanvas();
                    lock (surfaceHolder)
                    {
                        bubblePanel.Draw(canvas);
                    }
                } catch (Java.Lang.Exception ex)
                {
                    ex.PrintStackTrace();
                } finally 
                {
                    if(canvas != null)
                    {
                        surfaceHolder.UnlockCanvasAndPost(canvas);
                    }
                }
                timeMillis = (JavaSystem.NanoTime() - startTime) / 1000000;
                waitTime = targetTime - timeMillis;
                try
                {
                    if(waitTime > 0)
                    {
                        //Sleep(waitTime);
                    }
                } catch (Java.Lang.Exception ex)
                {
                    ex.PrintStackTrace();
                }

                totalTime += JavaSystem.NanoTime() - startTime;
                frameCount++;
                if (frameCount == MAX_FPS)
                {
                    averageFPS = 1000 / ((totalTime / frameCount) / 1000000);
                    frameCount = 0;
                    totalTime = 0;
                    Log.Info("Bubble Thread", "Average FPS : "+averageFPS);
                }
            }
        }
    }
}

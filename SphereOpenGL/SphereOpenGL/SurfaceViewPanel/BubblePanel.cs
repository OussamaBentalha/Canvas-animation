using System;
using Android.Content;
using Android.Graphics;
using Android.Hardware;
using Android.Runtime;
using Android.Util;
using Android.Views;

namespace SphereOpenGL.SurfaceViewPanel
{
    [Register("com.eyes.SphereOpenGL.BubblePanel")]
    public class BubblePanel : SurfaceView, ISurfaceHolderCallback
    {
        BubbleThread thread;

        RectPlayer player;
        Point playerPoint;
        //ObstacleManager obstacleManager;
        BubblePlayer bubble;

        BubbleManager bManager;

        //MOTIONEVENT
        float mDownX;
        float mDownY;
        bool isOnClick;
        float SCROLL_THRESHOLD = 2;

        bool movingPlayer= false;

        public BubblePanel(IntPtr ptr, JniHandleOwnership transfer) : base(ptr, transfer)
        {
        }

        public BubblePanel(Context context) : this(context, null)
        {
        }

        public BubblePanel(Context context, IAttributeSet attrs) : base(context, attrs)
        {
            Holder.AddCallback(this);
            thread = new BubbleThread(Holder, this);

            player = new RectPlayer(new Rect(100, 100, 200, 200), Color.Yellow);
            playerPoint = new Point(Constants.SCREEN_WIDTH/2, 3*Constants.SCREEN_HEIGHT/4);

            bubble = new BubblePlayer();

            bManager = new BubbleManager();

            //obstacleManager = new ObstacleManager(200, 350, 75, Color.Black);

            //this.SetBackgroundResource(Resource.Drawable.dubai);
            Focusable = true;
        }

        public void Reset()
        {
            
        }

        public void SurfaceChanged(ISurfaceHolder holder, [GeneratedEnum] Format format, int width, int height)
        {
            //throw new NotImplementedException();
        }

        public void SurfaceCreated(ISurfaceHolder holder)
        {
            Constants.SCREEN_WIDTH = Width;
            Constants.SCREEN_HEIGHT = Height;

            thread = new BubbleThread(Holder, this);
            thread.running = true; 
            thread.Start();
        }

        public void SurfaceDestroyed(ISurfaceHolder holder)
        {
            bool retry = true;
            while(retry)
            {
                try
                {
                    thread.running = false;
                    thread.Join();
                } catch(Java.Lang.Exception ex)
                {
                    ex.PrintStackTrace();
                }
                retry = false;
            }
        }

        public override void Draw(Canvas canvas)
        {
            base.Draw(canvas);

            canvas.DrawColor(Color.White);
            //canvas.DrawRect(0, 0, Width, Height, new Paint{ Color = Color.Blue});

            //player.Draw(canvas);
            //obstacleManager.draw(canvas);
            //bubble.Draw(canvas);

            bManager.Draw(canvas);
        }

        public override bool OnTouchEvent(MotionEvent e)
        {
            switch(e.Action)
            {
                case MotionEventActions.Down:
                    mDownX = e.GetX();
                    mDownY = e.GetY();
                    isOnClick = true;
                    //TODO Check Select Bubble
                    Log.Info("MOTION EVENT", "------ DOWN -------");
                    bManager.OnSelect(e);

                    /*if(player.Rectangle.Contains((int)e.GetX(), (int)e.GetY())){
						movingPlayer = true;
                    }*/
                    break;
                case MotionEventActions.Move:
                    if (isOnClick && Math.Abs(mDownX - e.GetX()) > SCROLL_THRESHOLD || Math.Abs(mDownY - e.GetY()) > SCROLL_THRESHOLD)
                    {
                        //TODO Moving bubble
                        Log.Info("MOTION EVENT", "------ MOVE -------");
                        bManager.OnMove(e);
                        isOnClick = false;
                    }
                    /*if(movingPlayer){
						//playerPoint.Set((int)e.GetX(), (int)e.GetY());
                        //bubble.playerPoint.Set((int)e.GetX(), (int)e.GetY());
                    }*/
                    break;
                case MotionEventActions.Up:
                    if (isOnClick)
                    {
                        //TODO onClick code
                        Log.Info("MOTION EVENT", "------ CLICK -------");
                        bManager.OnClick(e);
                    }
                    bManager.ResetSelectedBubble();
                    break;
            }
            return true;
            //return base.OnTouchEvent(e);
        }

        public void Update()  
        {
            //player.Update(playerPoint);
            //bubble.Update();
            bManager.Update();
        }

        public void OnSensorEvent(SensorEvent e) 
        {
            /*var alpha = 0.8;


            // Isolate the force of gravity with the low-pass filter.
            var gravityX = alpha * playerPoint.X + (1 - alpha) * e.Values[0];
            var gravityY = alpha * playerPoint.Y+ (1 - alpha) * e.Values [1];

            // Remove the gravity contribution with the high-pass filter.
            var linear_acceleration0 = e.Values [0] - gravityX;
            var linear_acceleration1 = e.Values [1] - gravityY;

            playerPoint.Set((int)linear_acceleration0, (int)linear_acceleration1);*/
            /*var x = playerPoint.X;
            var y = playerPoint.Y;


            x = x - (int) e.Values[0];
            y = y + (int) e.Values[1];

            //BUBBLE
            var bx = bubble.playerPoint.X;
            var by = bubble.playerPoint.Y;

            bx = bx - (int)e.Values[0];
            by = by + (int)e.Values[1];

            bubble.playerPoint.Set(bx, by);

            playerPoint.Set(x, y);*/

            bManager.OnSensorEvent(e);
        }

    }
}

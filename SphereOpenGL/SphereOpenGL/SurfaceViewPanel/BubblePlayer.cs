using System;
using System.Collections.Generic;
using Android.App;
using Android.Content.Res;
using Android.Graphics;
using Android.Views;

namespace SphereOpenGL.SurfaceViewPanel
{
    public class BubblePlayer : IGameObject
    {
        public Bitmap mBitmap;
        public Rect Rectangle { get; }
        public Point playerPoint;
        public int radius = 100;
        public bool Selected = false;


        public BubblePlayer()
        {
            Rectangle = new Rect(100, 100, 200, 200);
            //TODO WIDTH BUBBLE PLACEMENT
            playerPoint = new Point(new Random().Next(radius, 1000), radius);
            mBitmap = BitmapFactory.DecodeResource(Application.Context.Resources, Resource.Drawable.plain_instagram);
        }

        public void Draw(Canvas canvas)
        {
            canvas.DrawBitmap(mBitmap, null, Rectangle, null);
        }

        public void Update()
        {
            ControlEgdes();

            Rectangle.Set(playerPoint.X - radius,
                          playerPoint.Y - radius,
                          playerPoint.X + radius,
                          playerPoint.Y + radius);
        }

        public void ControlEgdes(){
            if (playerPoint.X < radius)
            {
                playerPoint.X = radius;
            }
            if (playerPoint.X > Constants.SCREEN_WIDTH - radius)
            {
                playerPoint.X = Constants.SCREEN_WIDTH - radius;
            }

            if (playerPoint.Y < radius)
            {
                playerPoint.Y = radius;
            }
            if (playerPoint.Y > Constants.SCREEN_HEIGHT - radius)
            {
                playerPoint.Y = Constants.SCREEN_HEIGHT - radius;
            }
        }

        public bool CheckCollision(BubblePlayer bubble)
        {
            if(Rect.Intersects(Rectangle, bubble.Rectangle))
            {
                return true;
            }
            return false;
        }

    }
}

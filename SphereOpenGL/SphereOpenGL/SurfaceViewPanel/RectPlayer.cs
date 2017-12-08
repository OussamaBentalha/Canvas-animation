using System;
using Android.Graphics;
using Android.Util;

namespace SphereOpenGL.SurfaceViewPanel
{
    public class RectPlayer : IGameObject
    {
        public Rect Rectangle { get; }
        Color color;

        public RectPlayer(Rect rectangle, Color color)
        {
            Rectangle = rectangle;
            this.color = color;
        }

        public RectPlayer()
        {
        }

        public void Draw(Canvas canvas)
        {
            Paint paint = new Paint
            {
                Color = color
            };
            canvas.DrawRect(Rectangle, paint);
        }

        public void Update()
        {
            //throw new NotImplementedException();
        }

        public void Update(Point point)
        {
            //TODO EDGE CONTROL + REBOUND
            Log.Info("POINT COORDINATE -->", "(" + point.X + ";" + point.Y + ")");

            if (point.X < Rectangle.Width() / 2)
            {
                point.X = Rectangle.Width() /2;
            }
            if (point.X > Constants.SCREEN_WIDTH - Rectangle.Width() / 2)
            {
                point.X = Constants.SCREEN_WIDTH - Rectangle.Width()/2;
            }

            if (point.Y < Rectangle.Height() / 2)
            {
                point.Y = Rectangle.Height() / 2;
            }
            if (point.Y > Constants.SCREEN_HEIGHT - Rectangle.Width()/2)
            {
                point.Y = Constants.SCREEN_HEIGHT - Rectangle.Width()/2;
            }

            var halfWidth = 50;
            var halfHeight = 50;

            Log.Info("POINT COORDINATE MODIFIER -->", "(" + point.X + ";" + point.Y + ")   HALF RECT["+halfWidth + ";" + halfHeight + "]");


            Rectangle.Set(point.X - halfWidth,
                          point.Y - halfWidth,
                          point.X + halfWidth,
                          point.Y + halfWidth);

            var left = point.X - halfWidth;
            var top = point.Y - halfWidth;
            var right = point.X + halfWidth;
            var bottom = point.Y + halfWidth;

            Log.Info("RECTANGLE COORDINATE -->", "(" + left + ";" + top + ";" + right + ";" + bottom + ")");
        }
    }
}

using System;
using Android.Graphics;

namespace SphereOpenGL.SurfaceViewPanel
{
    public class Obstacle : IGameObject
    {
        public Rect Rectangle { get; }
        public Rect Rectangle2;
        Color color;
        int startX;
        int playerGap;

        public void IncrementY(float y)
        {
            Rectangle.Top += (int)y;
            Rectangle.Bottom += (int)y;
            Rectangle2.Top += (int)y;
            Rectangle2.Bottom += (int)y;
        }

        public Obstacle(int rectHeight, Color color, int startX, int startY, int playerGap)
        {
            this.color = color;
            Rectangle = new Rect(0, startY, startX, startY + rectHeight);
            Rectangle2 = new Rect(startX + playerGap, startY, Constants.SCREEN_WIDTH, startY + rectHeight);
        }

        public bool PlayerCollide(RectPlayer player)
        {
            return Rect.Intersects(Rectangle, player.Rectangle) || Rect.Intersects(Rectangle2, player.Rectangle); 
            //if(Rectangle.Contains(player.Rectangle))
            /*if (Rectangle.Contains(player.Rectangle.Left, player.Rectangle.Top)
                || Rectangle.Contains(player.Rectangle.Right, player.Rectangle.Top)
                || Rectangle.Contains(player.Rectangle.Left, player.Rectangle.Bottom)
                || Rectangle.Contains(player.Rectangle.Right, player.Rectangle.Bottom))
                return true;
            return false;*/
        }

        public void Draw(Canvas canvas)
        {
            Paint paint = new Paint
            {
                Color = color
            };
            canvas.DrawRect(Rectangle, paint);
            canvas.DrawRect(Rectangle2, paint);
        }

        public void Update()
        {
            
        }
    }
}

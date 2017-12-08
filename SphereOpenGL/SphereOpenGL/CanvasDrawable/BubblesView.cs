using System;
using Android.Animation;
using Android.Content;
using Android.Graphics;
using Android.Graphics.Drawables;
using Android.Graphics.Drawables.Shapes;
using Android.Runtime;
using Android.Util;
using Android.Views;
using Android.Widget;

namespace SphereOpenGL.CanvasDrawable
{
    [Register("com.eyes.SphereOpenGL.BubblesView")]
    public class BubblesView : View
    {
        private Bitmap mBitmap = null;

        int bitmapX = 1;
        int bitmapY = 1;
        float rotation = 0;

        public BubblesView(Context context) : this(context, null)
        {
        }

        public BubblesView(Context context, IAttributeSet attrs) : base (context, attrs)
        {
            this.SetBackgroundResource(Resource.Drawable.dubai);

            Init();
        }

        protected BubblesView(IntPtr javaReference, JniHandleOwnership transfer) : base(javaReference, transfer)
        {
        }

        public void Init()
        {
            mBitmap = BitmapFactory.DecodeResource(Resources, Resource.Drawable.plain_snapchat);     
        }

        protected override void OnDraw(Canvas canvas)
        {
            base.OnDraw(canvas);

            if(bitmapX != 0){
                Matrix matrix = new Matrix();

                matrix.PostRotate(rotation);

                bitmapX += 1;
                bitmapY += 1;
                rotation += 1;

                Bitmap rotatedBitmap = Bitmap.CreateBitmap(mBitmap, 0, 0, mBitmap.Width, mBitmap.Height, matrix, true);
                canvas.DrawBitmap(rotatedBitmap, bitmapX, bitmapY, null);

                Invalidate();
            } else {
                Matrix matrix = new Matrix();

                matrix.PostRotate(rotation);

                bitmapX -= 1;
                bitmapY -= 1;
                rotation -= 1;

                Bitmap rotatedBitmap = Bitmap.CreateBitmap(mBitmap, 0, 0, mBitmap.Width, mBitmap.Height, matrix, true);
                canvas.DrawBitmap(rotatedBitmap, bitmapX, bitmapY, null);

                Invalidate();
            }

        }

        protected override void OnMeasure(int widthMeasureSpec, int heightMeasureSpec)
        {
            base.OnMeasure(widthMeasureSpec, heightMeasureSpec);
        }

    }
}

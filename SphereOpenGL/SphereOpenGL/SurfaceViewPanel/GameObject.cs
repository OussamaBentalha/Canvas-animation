using System;
using Android.Graphics;

namespace SphereOpenGL.SurfaceViewPanel
{
    public interface IGameObject
    {
        void Draw(Canvas canvas);
        void Update();
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using Android.Graphics;
using Android.Hardware;
using Android.Util;
using Android.Views;

namespace SphereOpenGL.SurfaceViewPanel
{
    public class BubbleManager
    {
        List<BubblePlayer> bubbles;
        public BubblePlayer selectedBubble;

        SensorEvent mLastSensorEvent;

        public BubbleManager()
        {
            bubbles = new List<BubblePlayer>();
            PopulateBubbles();
        }

        private void PopulateBubbles()
        {
            for (int i = 0; i < 4; i++){
                BubblePlayer bubble = new BubblePlayer();
                bubbles.Add(bubble);
            }
        }

        public void CheckCollisions()
        {
            Log.Info("Check Collision", "BEGIN");
            for (int i = 0; i < bubbles.Count-1; i++)
            {
                for (int j = i + 1; j < bubbles.Count; j++)
                {
                    Log.Info("Check Collision", "["+i+"-"+j+"]");
                    if(bubbles.ElementAt(i).CheckCollision(bubbles.ElementAt(j)))
                    {
                        var bubble1 = bubbles.ElementAt(i);
                        if(!bubble1.Selected)
                        {
                            //FREEZE
							//bubble1.playerPoint.Set(bubble1.Rectangle.CenterX(), bubble1.Rectangle.CenterY());

                            var bx = bubble1.Rectangle.CenterX();
                            var by = bubble1.Rectangle.CenterY();

                            bx = bx + (int)mLastSensorEvent.Values[0];
                            by = by - (int)mLastSensorEvent.Values[1];

                            bubble1.playerPoint.Set(bx, by);
                        }

                        /*var bubble2 =  bubbles.ElementAt(j);
                        if(!bubble2.Selected)
                            bubble2.playerPoint.Set(bubble2.Rectangle.CenterX(), bubble2.Rectangle.CenterY());*/
                    }
                }
            }
            Log.Info("Check Collision", "END");
        }

        public void Update()
        {
            CheckCollisions();
            foreach(var bubble in bubbles)
            {
                bubble.Update();
            }
        }

        public void Draw(Canvas canvas)
        {
            foreach (var bubble in bubbles)
            {
                bubble.Draw(canvas);
            }
        }

        public void OnSensorEvent(SensorEvent e)
        {
            mLastSensorEvent = e;
            foreach(var bubble in bubbles)
            {
                if(!bubble.Selected)
                {
                    var bx = bubble.playerPoint.X;
                    var by = bubble.playerPoint.Y;

                    bx = bx - (int)e.Values[0];
                    by = by + (int)e.Values[1];

                    bubble.playerPoint.Set(bx, by);
                }
            }
        }

        /*public void OnSelect(MotionEvent e)
        {
            Log.Info("ON SELECT", "------ RETRIVE BUBBLE -------");
            if(selectedBubble == null)
            {
				foreach (var bubble in bubbles)
				{
					if(bubble.Rectangle.Contains((int)e.GetX(), (int)e.GetY()))
					{
						Log.Info("ON SELECT", "------ BUBBLE SELECTED -------");
                        SelectBubble(bubble);
					}
				}
            }
        }*/

        public void OnSelect(MotionEvent e)
        {
            Log.Info("ON SELECT", "------ RETRIVE BUBBLE -------");
            if (selectedBubble == null)
            {
                //BOUCLE INVERSE POUR SELECTIONNER LA BULLE EN AVANT PLAN
                for (int i = bubbles.Count() - 1; i >= 0; i--)
                {
                    if (bubbles.ElementAt(i).Rectangle.Contains((int)e.GetX(), (int)e.GetY()))
                    {
                        Log.Info("ON SELECT", "------ BUBBLE SELECTED -------");
                        SelectBubble(bubbles.ElementAt(i));
                        break;
                    }
                }
            }
        }

        public void OnMove(MotionEvent e)
        {
            if(selectedBubble != null)
            {
                Log.Info("ON MOVE", "------ BUBBLE MOVE TO -------");
                //bubbles.ElementAt(selectedBubble).playerPoint.Set((int)e.GetX(), (int)e.GetY());
                selectedBubble.playerPoint.Set((int)e.GetX(), (int)e.GetY());
            }
        }

        public void OnClick(MotionEvent e)
        {
            if(selectedBubble != null){
                // TODO Clicked bubbled
                Log.Info("ON CLICK", "------ BUBBLE CLICKED -------");
            }
        }

        public void SelectBubble(BubblePlayer bubble)
        {
            if(bubble != null)
            {
				selectedBubble = bubble;
                selectedBubble.Selected = true;
            }
        }

        public void ResetSelectedBubble()
        {
            if(selectedBubble != null)
            {
                selectedBubble.Selected = false;
                selectedBubble = null;
            }
        }
    }
}

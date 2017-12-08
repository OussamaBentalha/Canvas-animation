using System;
using System.Collections.Generic;
using System.Linq;
using Android.Graphics;
using Java.Lang;

namespace SphereOpenGL.SurfaceViewPanel
{
    public class ObstacleManager
    {
        List<Obstacle> obstacles;
        int playerGap;
        int obstacleGap;
        int obstacleHeight;
        Color color;

        long startTime;

        public ObstacleManager(int playerGap, int obstacleGap, int obstacleHeight, Color color)
        {
            this.playerGap = playerGap;
            this.obstacleGap = obstacleGap;
            this.obstacleHeight = obstacleHeight;
            this.color = color;

            startTime = JavaSystem.CurrentTimeMillis();

            obstacles = new List<Obstacle>();

            populateObstacles();
        }

        public bool PlayerCollide(RectPlayer player)
        {
            foreach(var obstacle in obstacles)
            {
                if (obstacle.PlayerCollide(player))
                    return true;
            }
            return false;
        }

        private void populateObstacles()
        {
            int currY = -5 * Constants.SCREEN_HEIGHT / 4;
            while(currY < 0)
            {
                int xStart = new Random().Next(0, Constants.SCREEN_WIDTH - playerGap);
                obstacles.Add(new Obstacle(obstacleHeight, color, xStart, currY, playerGap));
                currY += obstacleHeight + obstacleGap;
            }
        }

        public void Update()
        {
            int elapseTime = (int)((int)JavaSystem.CurrentTimeMillis() - startTime);
            startTime = JavaSystem.CurrentTimeMillis();;
            float speed = Constants.SCREEN_HEIGHT / 10000.0f;
            foreach(var obstacle in obstacles)
            {
                obstacle.IncrementY((speed * elapseTime));
            }
            if(obstacles.ElementAt(obstacles.Count() - 1).Rectangle.Top >= Constants.SCREEN_HEIGHT)
            {
                int xStart = new Random().Next(0, Constants.SCREEN_WIDTH - playerGap);
                obstacles.Insert(0, new Obstacle(obstacleHeight, color, xStart, obstacles.ElementAt(0).Rectangle.Top - obstacleHeight - obstacleGap, playerGap));
                obstacles.RemoveAt(obstacles.Count() - 1);
            }
        }

        public void draw(Canvas canvas)
        {
            foreach(var obstacle in obstacles)
            {
                obstacle.Draw(canvas);
            }
        }
    }
}

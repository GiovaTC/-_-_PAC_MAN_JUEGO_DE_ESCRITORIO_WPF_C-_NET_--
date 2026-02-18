using System;
using System.Drawing;

namespace pacman_game
{
    public class Ghost
    {
        static Random rnd = new Random();
        public int X, Y;
        Brush brush;

        public Ghost(int x, int y, Color color)
        {
            X = x;
            Y = y;
            brush = new SolidBrush(color);
        }

        public void Move(Map map)
        {
            int dir = rnd.Next(4);
            int nx = X, ny = Y;

            if (dir == 0) nx++;
            if (dir == 1) nx--;
            if (dir == 2) ny++;
            if (dir == 3) ny--;

            if (!map.IsWall(nx, ny))
            {
                X = nx;
                Y = ny;
            }
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(
                brush,
                X * 40,
                Y * 40,
                40,
                40
            );
        }
    }
}

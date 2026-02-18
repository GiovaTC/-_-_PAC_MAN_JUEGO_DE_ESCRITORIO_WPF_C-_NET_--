using System.Drawing;
using System.Windows.Forms;


namespace pacman_game
{
    public class Pacman
    {
        public int X = 1;
        public int Y = 1;
        public Direction Dir = Direction.Right;
        public bool Alive = true;

        public Pacman()
        {
        }

        public void ChangeDirection(Keys key)
        {
            if ( key == Keys.Left) Dir = Direction.Left;
            if ( key == Keys.Right) Dir = Direction.Right;
            if ( key == Keys.Up) Dir = Direction.Up;
            if ( key == Keys.Down) Dir = Direction.Down;
        }

        public void Move(Map map)
        {
            int nx = X, ny = Y;

            if (Dir == Direction.Left) nx--;
            if (Dir == Direction.Right) nx++;
            if (Dir == Direction.Up) ny--;
            if (Dir == Direction.Down) ny++;

            if (!map.IsWall(nx, ny))
            {
                X = nx;
                Y = ny;
            }
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(
                Brushes.Yellow, 
                X * 40, 
                Y * 40, 
                40,
                40
             );
        }
    }
}
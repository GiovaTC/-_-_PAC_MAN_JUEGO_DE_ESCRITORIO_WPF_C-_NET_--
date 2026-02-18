using System.Drawing;
using System.Windows.Forms;

namespace pacman_game.Core
{
    public class Pacman
    {
        public int X { get; private set; }
        public int Y { get; private set; }

        private int dx;
        private int dy;

        public bool Alive { get; set; } = true;

        public Pacman(int startX, int startY)
        {
            X = startX;
            Y = startY;
        }

        public void ChangeDirection(Keys key)
        {
            switch (key)
            {
                case Keys.Up:
                    dx = 0; dy = -1;
                    break;
                case Keys.Down:
                    dx = 0; dy = 1;
                    break;
                case Keys.Left:
                    dx = -1; dy = 0;
                    break;
                case Keys.Right:
                    dx = 1; dy = 0;
                    break;
            }
        }

        public void Move(Map map)
        {
            int nextX = X + dx;
            int nextY = Y + dy;

            if (!map.IsWall(nextX, nextY))
            {
                X = nextX;
                Y = nextY;
            }
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(
                Brushes.Yellow,
                X * Map.TileSize,
                Y * Map.TileSize,
                Map.TileSize,
                Map.TileSize
            );
        }
    }
}

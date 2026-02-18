using System.Windows.Forms;

namespace pacman_game.Core
{
    public class Pacman : Sprite
    {
        private int dx;
        private int dy;

        public int Score { get; private set; }
        public bool Alive { get; set; } = true;

        public Pacman(int startX, int startY)
            : base("Assets/pacman.png", Map.TileSize)
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

                // 🍒 Comer píldora
                if (map.TryEatPellet(X, Y))
                {
                    EatPellet();
                }
            }
        }

        private void EatPellet()
        {
            Score += 10;
        }
    }
}

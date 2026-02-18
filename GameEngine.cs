using pacman_game.Core;
using System.Drawing;
using System.Windows.Forms;

namespace pacman_game
{
    public class GameEngine
    {
        private readonly Map map;
        private readonly Pacman pacman;
        private readonly Ghost[] ghosts;

        public int MapWidthInPixels => map.Width * Map.TileSize;
        public int MapHeightInPixels => map.Height * Map.TileSize;

        public GameEngine()
        {
            int[,] level1 =
            {
                {1,1,1,1,1,1,1,1,1,1,1,1},
                {1,2,2,2,2,2,2,2,2,2,2,1},
                {1,2,1,1,2,1,1,2,1,1,2,1},
                {1,2,2,2,2,2,2,2,2,2,2,1},
                {1,1,1,1,1,1,1,1,1,1,1,1},
            };

            map = new Map(level1);
            pacman = new Pacman(1, 1);

            ghosts = new Ghost[]
            {
                new Ghost(9, 3, Color.Red),
                new Ghost(10, 3, Color.Pink)
            };
        }

        public void HandleInput(Keys key)
        {
            pacman.ChangeDirection(key);
        }

        public void Update()
        {
            if (!pacman.Alive) return;

            // 1️⃣ Mover Pac-Man
            pacman.Move(map);

            // 2️⃣ Comer píldora y sumar puntos
            if (map.TryEatPellet(pacman.X, pacman.Y))
            {
                pacman.EatPellet();
            }

            // 3️⃣ Mover fantasmas y detectar colisiones
            foreach (var g in ghosts)
            {
                g.Move(map);

                if (g.X == pacman.X && g.Y == pacman.Y)
                {
                    pacman.Alive = false;
                }
            }
        }


        public void Draw(Graphics g)
        {
            map.Draw(g);
            pacman.Draw(g);

            foreach (var ghost in ghosts)
                ghost.Draw(g);

            if (!pacman.Alive)
            {
                g.DrawString(
                    "GAME OVER",
                    new Font("Arial", 32, FontStyle.Bold),
                    Brushes.Red,
                    180, 300
                );
            }
        }
    }
}

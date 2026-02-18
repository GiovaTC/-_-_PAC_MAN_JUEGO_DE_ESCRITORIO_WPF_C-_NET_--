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

            pacman.Move(map);

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

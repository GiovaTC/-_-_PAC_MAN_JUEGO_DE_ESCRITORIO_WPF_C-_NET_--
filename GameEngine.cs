using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace pacman_game
{
    public class GameEngine
    {
        Map map = new Map();
        Pacman pacman = new Pacman();
        Ghost[] ghosts =
        {
            new Ghost(9, 9, Color.Red),
            new Ghost(10, 9, Color.Pink)
        };

        public void HandleInput(Keys key)
        {
            pacman.ChangeDirection(key);
        }

        public void Update()
        {
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
                    new Font("Arial", 32),
                    Brushes.Red,
                    180, 300
                );
            }
        }
    }
}
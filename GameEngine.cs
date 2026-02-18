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

        private const int HudHeight = 40;

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
                new Ghost(9, 3, "Assets/pacman.png"),
                new Ghost(10, 3, "Assets/ghost.png"),
                // new Ghost(8, 3, "Assets/ghost_blue.png")
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

            foreach (var ghost in ghosts)
            {
                ghost.Move(map);

                if (ghost.X == pacman.X && ghost.Y == pacman.Y)
                {
                    pacman.Alive = false;
                    break;
                }
            }
        }

        public void Draw(Graphics g, Size viewport)
        {
            g.Clear(Color.Black);

            DrawHUD(g);

            if (!pacman.Alive)
            {
                DrawGameOver(g, viewport);
                return;
            }

            // 🧠 CENTRADO DEL MAPA
            int offsetX = (viewport.Width - MapWidthInPixels) / 2;
            int offsetY = HudHeight + (viewport.Height - HudHeight - MapHeightInPixels) / 2;

            // 🟦 Fondo azul del área de juego
            g.FillRectangle(
                Brushes.DarkBlue,
                0,
                HudHeight,
                viewport.Width,
                viewport.Height - HudHeight
            );

            g.TranslateTransform(offsetX, offsetY);

            map.Draw(g);
            pacman.Draw(g);

            foreach (var ghost in ghosts)
                ghost.Draw(g);

            g.ResetTransform();
        }

        private void DrawHUD(Graphics g)
        {
            using Font font = new Font("Arial", 14, FontStyle.Bold);

            g.DrawString(
                $"Score: {pacman.Score}",
                font,
                Brushes.White,
                10,
                10
            );
        }

        private void DrawGameOver(Graphics g, Size viewport)
        {
            string text = "GAME OVER";

            using Font font = new Font("Arial", 48, FontStyle.Bold);
            SizeF size = g.MeasureString(text, font);

            float x = (viewport.Width - size.Width) / 2;
            float y = (viewport.Height - size.Height) / 2;

            g.DrawString(text, font, Brushes.Red, x, y);
        }
    }
}

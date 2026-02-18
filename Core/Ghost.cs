using System;

namespace pacman_game.Core
{
    public class Ghost : Sprite
    {
        private static readonly Random rnd = new Random();

        private int dx;
        private int dy;

        public Ghost(int startX, int startY, string assetPath)
            : base(assetPath, Map.TileSize)
        {
            X = startX;
            Y = startY;
            ChooseRandomDirection();
        }

        public void Move(Map map)
        {
            int nextX = X + dx;
            int nextY = Y + dy;

            if (map.IsWall(nextX, nextY))
            {
                ChooseRandomDirection();
                return;
            }

            X = nextX;
            Y = nextY;

            // Ocasionalmente cambia dirección
            if (rnd.NextDouble() < 0.15)
            {
                ChooseRandomDirection();
            }
        }

        private void ChooseRandomDirection()
        {
            int dir = rnd.Next(4);

            switch (dir)
            {
                case 0: dx = 1; dy = 0; break;   // Right
                case 1: dx = -1; dy = 0; break;  // Left
                case 2: dx = 0; dy = 1; break;   // Down
                case 3: dx = 0; dy = -1; break;  // Up
            }
        }
    }
}

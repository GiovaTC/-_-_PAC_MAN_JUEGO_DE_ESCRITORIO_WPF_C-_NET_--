using System.Drawing;

namespace pacman_game
{
    public class Map
    {
        public int[,] Grid =
        {
            {1,1,1,1,1,1,1,1,1,1,1},
            {1,0,0,0,0,0,0,0,0,0,1},
            {1,0,1,1,0,1,0,1,1,0,1},
            {1,0,0,0,0,0,0,0,0,0,1},
            {1,1,1,1,1,1,1,1,1,1,1}
        };

        public const int TileSize = 40;

        public int Width => Grid.GetLength(1);
        public int Height => Grid.GetLength(0);

        /// <summary>
        /// Devuelve true si la celda es pared o está fuera del mapa
        /// </summary>
        public bool IsWall(int x, int y)
        {
            // Fuera de límites = pared
            if (x < 0 || y < 0 || x >= Width || y >= Height)
                return true;

            return Grid[y, x] == 1;
        }

        public void Draw(Graphics g)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    if (Grid[y, x] == 1)
                    {
                        g.FillRectangle(
                            Brushes.DarkBlue,
                            x * TileSize,
                            y * TileSize,
                            TileSize,
                            TileSize
                        );
                    }
                }
            }
        }
    }
}

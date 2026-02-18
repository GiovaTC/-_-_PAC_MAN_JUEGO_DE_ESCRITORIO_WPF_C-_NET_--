
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

        public int TileSize = 40;

        public bool IsWall(int x, int y)
        {
            return Grid[y, x] == 1;
        }

        public void Draw(Graphics g)
        {
            for (int y = 0; y < Grid.GetLength(0); y++)
            {
                for (int x = 0; x < Grid.GetLength(1); x++)
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
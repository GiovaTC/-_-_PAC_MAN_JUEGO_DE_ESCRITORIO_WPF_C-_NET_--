using System.Drawing;

namespace pacman_game.Core
{
    public class Map
    {
        private readonly TileType[,] grid;

        public const int TileSize = 40;

        public int Width => grid.GetLength(1);
        public int Height => grid.GetLength(0);

        public Map(int[,] rawMap)
        {
            int rows = rawMap.GetLength(0);
            int cols = rawMap.GetLength(1);

            grid = new TileType[rows, cols];

            for (int y = 0; y < rows; y++)
            {
                for (int x = 0; x < cols; x++)
                {
                    grid[y, x] = (TileType)rawMap[y, x];
                }
            }
        }

        // 🔍 Obtiene el tipo de celda
        public TileType GetTile(int x, int y)
        {
            if (!IsInsideBounds(x, y))
                return TileType.Wall;

            return grid[y, x];
        }

        // ❌ Cambia una celda (ej. eliminar píldora)
        public void SetTile(int x, int y, TileType type)
        {
            if (IsInsideBounds(x, y))
            {
                grid[y, x] = type;
            }
        }

        // 🍒 Intenta consumir una píldora
        public bool TryEatPellet(int x, int y)
        {
            if (GetTile(x, y) == TileType.Pellet)
            {
                SetTile(x, y, TileType.Empty);
                return true;
            }
            return false;
        }

        // 🚧 Verifica colisiones
        public bool IsWall(int x, int y)
        {
            return GetTile(x, y) == TileType.Wall;
        }

        // 📐 Límites del mapa
        private bool IsInsideBounds(int x, int y)
        {
            return x >= 0 && x < Width &&
                   y >= 0 && y < Height;
        }

        // 🎨 Render del mapa
        public void Draw(Graphics g)
        {
            for (int y = 0; y < Height; y++)
            {
                for (int x = 0; x < Width; x++)
                {
                    TileType tile = grid[y, x];

                    if (tile == TileType.Wall)
                    {
                        g.FillRectangle(
                            Brushes.DarkBlue,
                            x * TileSize,
                            y * TileSize,
                            TileSize,
                            TileSize
                        );
                    }
                    else if (tile == TileType.Pellet)
                    {
                        g.FillEllipse(
                            Brushes.Gold,
                            x * TileSize + TileSize / 4,
                            y * TileSize + TileSize / 4,
                            TileSize / 2,
                            TileSize / 2
                        );
                    }
                }
            }
        }
    }
}

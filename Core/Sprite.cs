using System.Drawing;
using System.IO;

namespace pacman_game.Core
{
    public abstract class Sprite
    {
        protected Image image;
        protected int size;

        public int X { get; set; }
        public int Y { get; set; }

        protected Sprite(string imagePath, int tileSize)
        {
            size = tileSize;

            if (!File.Exists(imagePath))
                throw new FileNotFoundException($"No se encontró el asset: {imagePath}");

            image = Image.FromFile(imagePath);
        }

        public virtual void Draw(Graphics g)
        {
            g.DrawImage(
                image,
                X * size,
                Y * size,
                size,
                size
            );
        }
    }
}

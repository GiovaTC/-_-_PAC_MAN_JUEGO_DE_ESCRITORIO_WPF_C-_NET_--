using System.Drawing;

namespace pacman_game.Core
{
    public abstract class Sprite
    {
        protected Image image;
        protected int size;

        public int X { get; protected set; }
        public int Y { get; protected set; }

        protected Sprite(string imagePath, int tileSize)
        {
            image = Image.FromFile(imagePath);
            size = tileSize;
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

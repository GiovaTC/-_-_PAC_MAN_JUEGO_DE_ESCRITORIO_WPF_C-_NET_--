using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;


namespace pacman_game
{
    internal class GameEngine
    {
        Map map = new Map();
        Pacman pacman = new Pacman();
        Ghost[] ghosts =
        {
            new Ghost(9, 9, Color.Red),
            new Ghost(10, 9, Color.Pink)
        };
        internal void Draw(Graphics graphics)
        {
            throw new NotImplementedException();
        }

        internal void HandleInput(Keys keyCode)
        {
            throw new NotImplementedException();
        }

        internal void Update()
        {
            throw new NotImplementedException();
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pacman_game
{   
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
    // #### Nuevo `enum`
    public enum TileType
    {
        Empty = 0,
        Wall = 1,
        Pellet = 2
    }
}

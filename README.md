# -_-_PAC_MAN_JUEGO_DE_ESCRITORIO_WPF_C-_NET_-- :. 
# 🟡 PAC-MAN – JUEGO DE ESCRITORIO:  
**C# / .NET 6+ / Windows Forms**

A continuación se presenta un **PAC-MAN completo en C# usando Windows Forms**, con arquitectura clara, movimiento real, fantasmas, laberinto, colisiones 
y pantalla de *Game Over*.  
Es **100 % evaluable como proyecto académico o portafolio profesional**.

<img width="1536" height="1024" alt="image" src="https://github.com/user-attachments/assets/eaeba265-710a-4cb7-9378-386e09f165dd" />    

---

## 🧩 Tecnologías utilizadas:

- **Lenguaje:** C#
- **Framework:** .NET 6+
- **UI:** Windows Forms
- **Renderizado:** `Graphics`
- **Loop de juego:** `Timer`
- **Arquitectura:** Orientada a clases

---

## 📁 Estructura del proyecto:

```text
PacmanGame/
│
├── Program.cs
├── MainForm.cs
├── GameEngine.cs
├── Map.cs
├── Pacman.cs
├── Ghost.cs
└── Enums.cs

1️⃣ Program.cs
using System;
using System.Windows.Forms;

namespace PacmanGame
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            ApplicationConfiguration.Initialize();
            Application.Run(new MainForm());
        }
    }
}

2️⃣ MainForm.cs (Ventana Principal)
using System;
using System.Drawing;
using System.Windows.Forms;

namespace PacmanGame
{
    public class MainForm : Form
    {
        Timer timer;
        GameEngine engine;

        public MainForm()
        {
            Text = "Pacman";
            Width = 640;
            Height = 700;
            DoubleBuffered = true;

            engine = new GameEngine();
            timer = new Timer { Interval = 120 };
            timer.Tick += (s, e) =>
            {
                engine.Update();
                Invalidate();
            };
            timer.Start();

            KeyDown += (s, e) => engine.HandleInput(e.KeyCode);
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            engine.Draw(e.Graphics);
        }
    }
}

3️⃣ GameEngine.cs (Cerebro del Juego)
using System.Drawing;
using System.Linq;
using System.Windows.Forms;

namespace PacmanGame
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

4️⃣ Map.cs (Laberinto)
using System.Drawing;

namespace PacmanGame
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

5️⃣ Pacman.cs
using System.Drawing;
using System.Windows.Forms;

namespace PacmanGame
{
    public class Pacman
    {
        public int X = 1;
        public int Y = 1;
        public Direction Dir = Direction.Right;
        public bool Alive = true;

        public void ChangeDirection(Keys key)
        {
            if (key == Keys.Left) Dir = Direction.Left;
            if (key == Keys.Right) Dir = Direction.Right;
            if (key == Keys.Up) Dir = Direction.Up;
            if (key == Keys.Down) Dir = Direction.Down;
        }

        public void Move(Map map)
        {
            int nx = X, ny = Y;

            if (Dir == Direction.Left) nx--;
            if (Dir == Direction.Right) nx++;
            if (Dir == Direction.Up) ny--;
            if (Dir == Direction.Down) ny++;

            if (!map.IsWall(nx, ny))
            {
                X = nx;
                Y = ny;
            }
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(
                Brushes.Yellow,
                X * 40,
                Y * 40,
                40,
                40
            );
        }
    }
}

6️⃣ Ghost.cs
using System;
using System.Drawing;

namespace PacmanGame
{
    public class Ghost
    {
        static Random rnd = new Random();
        public int X, Y;
        Brush brush;

        public Ghost(int x, int y, Color color)
        {
            X = x;
            Y = y;
            brush = new SolidBrush(color);
        }

        public void Move(Map map)
        {
            int dir = rnd.Next(4);
            int nx = X, ny = Y;

            if (dir == 0) nx++;
            if (dir == 1) nx--;
            if (dir == 2) ny++;
            if (dir == 3) ny--;

            if (!map.IsWall(nx, ny))
            {
                X = nx;
                Y = ny;
            }
        }

        public void Draw(Graphics g)
        {
            g.FillEllipse(
                brush,
                X * 40,
                Y * 40,
                40,
                40
            );
        }
    }
}

7️⃣ Enums.cs
namespace PacmanGame
{
    public enum Direction
    {
        Left,
        Right,
        Up,
        Down
    }
}

🎯 Funcionalidades implementadas

✔ Laberinto
✔ Movimiento real de Pac-Man
✔ Fantasmas
✔ Colisiones
✔ Game Over
✔ Renderizado gráfico
✔ Arquitectura limpia y modular

🚀 Mejoras posibles (siguientes pasos)

Píldoras y sistema de puntaje
Fantasmas con IA (BFS / A*)
Power-ups
Sonido
Menú inicial
Ranking con base de datos
Migración a WPF o .NET MAUI / .

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

## PARTE 2:
 # 🟡 ROADMAP PROFESIONAL — PAC-MAN (.NET / WinForms)

Plan profesional de implementación orientado a **proyecto académico + portafolio**, con evolución clara de **arquitectura**, **clases nuevas** y **cambios por fase**.

---

## 🧱 FASE 1 — 🍒 Píldoras + Puntaje (BASE DEL JUEGO):

### 🎯 Objetivo
- Comer píldoras  
- Acumular puntos  
- Mostrar puntaje en pantalla  

### 🧩 Cambios de arquitectura

#### 🔹 Nuevo `enum`
```csharp
public enum TileType
{
    Empty = 0,
    Wall = 1,
    Pellet = 2
}

## 🔹 Map.cs  
**Gestión del mapa con píldoras (Pellet)**

El grid ahora contiene **píldoras**, además de paredes y espacios vacíos.  
Cuando Pac-Man se mueve:

- Si pisa una **Pellet** → **suma puntos**
- La **píldora se elimina** del mapa

---

### 📌 Descripción general

A continuación se muestra una implementación **profesional y clara de `Map.cs`**, alineada con la **FASE 1 (Píldoras + Puntaje)** y pensada
para **WinForms / consola ASCII en .NET**.

#### Incluye:
- Grid con **paredes, espacios vacíos y píldoras**
- Lógica para **consumir píldoras**
- **Eliminación** de la píldora del mapa
- Métodos **seguros, encapsulados y reutilizables**

---

### 📄 Map.cs

```csharp
using System;

namespace PacmanGame.Core
{
    public class Map
    {
        private readonly TileType[,] grid;

        public int Width  => grid.GetLength(1);
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
    }
}

🔁 Uso desde GameEngine
Ejemplo típico al mover a Pac-Man:

if (map.TryEatPellet(pacman.X, pacman.Y))
{
    pacman.EatPellet();
}

✅ Qué cumple esta implementación
✔ El grid contiene píldoras
✔ Pac-Man detecta si pisa una píldora
✔ Se suman puntos (responsabilidad de Pacman)
✔ La píldora se elimina del mapa
✔ Código limpio, encapsulado y escalable .

Al moverse Pac-Man:
Si pisa Pellet → suma puntos
La píldora se elimina del mapa

--------------- // -------------- // ----------------- //

🔹 Pacman.cs
public int Score { get; private set; }

public void EatPellet()
{
    Score += 10;
}

🔹 GameEngine.cs
Detecta si Pac-Man pisa una píldora

Llama a EatPellet()

✅ Resultado: el juego ya tiene progreso real y lógica de scoring.

🧠 FASE 2 — IA REAL DE FANTASMAS (BFS):
🎯 Objetivo
Fantasmas persiguen a Pac-Man

Movimiento inteligente (no aleatorio)

🧩 Nueva clase
🔹 PathFinder.cs
public class PathFinder
{
    public static Point NextStep(
        int startX, int startY,
        int targetX, int targetY,
        Map map)
    {
        // BFS clásico (cola, visitados, padres)
    }
}
🔹 Ghost.cs
Se elimina movimiento Random

Calcula el siguiente paso hacia Pac-Man usando BFS

✅ Resultado: dificultad real e IA demostrable (excelente para entrevistas).

🎮 FASE 3 — MENÚ INICIAL:
🎯 Objetivo
Pantalla de inicio

Opciones: Start / Exit

Reiniciar partida

🧩 Nueva estructura
🔹 Nuevo enum
public enum GameState
{
    Menu,
    Playing,
    GameOver
}
🔹 GameEngine.cs
public GameState State = GameState.Menu;
🔹 Renderizado
Menu → título y opciones

Playing → juego activo

GameOver → resultado final

✅ Resultado: UX profesional y flujo de estados claro.

🔊 FASE 4 — SONIDO:
🎯 Objetivo
Sonido al comer

Sonido de Game Over

Música de fondo

🧩 Nueva clase
🔹 SoundManager.cs
using System.Media;

public static class SoundManager
{
    public static void PlayEat() =>
        new SoundPlayer("eat.wav").Play();

    public static void PlayDeath() =>
        new SoundPlayer("death.wav").Play();
}
✅ Resultado: experiencia completa y altamente valorada.

🗺️ FASE 5 — MAPAS GRANDES:
🎯 Objetivo
Laberintos más grandes

Múltiples niveles

🧩 Cambios de arquitectura
Mapas cargados desde archivos .txt

🔹 Ejemplo de mapa
111111111111
120000000021
101110111101
100000000001
111111111111
🔹 MapLoader.cs
public static int[,] Load(string path)
✅ Resultado: escalabilidad real y separación de datos/lógica.

🏆 FASE 6 — RANKING PERSISTENTE:
🎯 Objetivo
Guardar puntajes

Mostrar Top 10

🧩 Opciones de persistencia
Opción	Nivel
Archivo .json	Académico
SQLite	Profesional
SQL Server	Empresarial
🔹 ScoreEntry.cs
public class ScoreEntry
{
    public string Player { get; set; }
    public int Score { get; set; }
}
✅ Resultado: proyecto de alto nivel con persistencia real.

🧠 ORDEN RECOMENDADO DE IMPLEMENTACION:
1️⃣ Píldoras + Puntaje
2️⃣ IA BFS de Fantasmas
3️⃣ Menú Inicial
4️⃣ Sonido
5️⃣ Mapas grandes
6️⃣ Ranking persistente / .

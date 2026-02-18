# -_-_PAC_MAN_JUEGO_DE_ESCRITORIO_WPF_C-_NET_-- :. 
# 🟡 PAC-MAN – JUEGO DE ESCRITORIO:  
**C# / .NET 6+ / Windows Forms**

A continuación se presenta un **PAC-MAN completo en C# usando Windows Forms**, con arquitectura clara, movimiento real, fantasmas, laberinto, colisiones 
y pantalla de *Game Over*.  
Es **100 % evaluable como proyecto académico o portafolio profesional**.

<img width="1536" height="1024" alt="image" src="https://github.com/user-attachments/assets/eaeba265-710a-4cb7-9378-386e09f165dd" />    

<img width="1062" height="833" alt="image" src="https://github.com/user-attachments/assets/8858b7fb-05b7-4d6a-931c-6fd06a5aa131" />    

---

🎮 PAC-MAN (.NET / WinForms)

Proyecto académico y de portafolio que implementa Pac-Man en C# / WinForms, con arquitectura orientada a clases, renderizado manual y un roadmap profesional de evolución.

🧩 Tecnologías utilizadas

Lenguaje: C#

Framework: .NET 6+ / .NET 8

UI: Windows Forms

Renderizado: System.Drawing.Graphics

Loop de juego: System.Windows.Forms.Timer

Arquitectura: Orientada a clases (Engine + UI)

Assets: PNG externos (sprites)

📁 Estructura del proyecto
pacman_game/
│
├── Program.cs
├── MainForm.cs
├── MainForm.Designer.cs
├── GameEngine.cs
│
├── Core/
│   ├── Map.cs
│   ├── Sprite.cs
│   ├── Pacman.cs
│   ├── Ghost.cs
│   └── Enums.cs
│
├── Assets/
│   ├── pacman.png
│   ├── ghost_red.png
│   ├── ghost_pink.png
│   └── ghost_blue.png
│
└── README.md


📌 Importante:
Los archivos .png deben tener:

Build Action: Content

Copy to Output Directory: Copy if newer

1️⃣ Program.cs

Punto de entrada de la aplicación WinForms.

using System;
using System.Windows.Forms;

namespace pacman_game
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

2️⃣ MainForm.cs (Ventana principal)

Contiene el loop del juego

Maneja input de teclado

Delegación completa del render a GameEngine

engine.Draw(e.Graphics, gamePanel.ClientSize);


Características:

DoubleBuffered activo

Panel dedicado al render

Repaint controlado con Invalidate()

3️⃣ GameEngine.cs (Cerebro del juego)

Responsabilidades:

Control del estado del juego

Movimiento de entidades

Colisiones

Puntaje

Render centrado + HUD

Funcionalidades actuales

Movimiento de Pac-Man

Consumo de píldoras

Suma de puntaje

Fantasmas

Colisión Pac-Man / Fantasma

Pantalla GAME OVER

HUD (Score)

Render centrado dinámico

4️⃣ Enums.cs
public enum TileType
{
    Empty = 0,
    Wall = 1,
    Pellet = 2
}

5️⃣ Map.cs (Laberinto con píldoras)
Descripción

El mapa ahora soporta:

🟦 Paredes

⬛ Espacios vacíos

🍒 Píldoras (Pellet)

Cuando Pac-Man se mueve:

Si pisa una Pellet → suma puntos

La píldora se elimina del mapa

Implementación clave
public bool TryEatPellet(int x, int y)
{
    if (GetTile(x, y) == TileType.Pellet)
    {
        SetTile(x, y, TileType.Empty);
        return true;
    }
    return false;
}

6️⃣ Sprite.cs (Base gráfica)

Clase base para entidades renderizadas con imágenes.

public abstract class Sprite
{
    protected Image image;
    protected int size;

    public int X { get; set; }
    public int Y { get; set; }

    protected Sprite(string imagePath, int tileSize)
    {
        size = tileSize;
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

7️⃣ Pacman.cs

Hereda de Sprite

Maneja posición, vida y puntaje

public class Pacman : Sprite
{
    public int Score { get; private set; }
    public bool Alive { get; set; } = true;

    public Pacman(int x, int y)
        : base("Assets/pacman.png", Map.TileSize)
    {
        X = x;
        Y = y;
    }

    public void EatPellet()
    {
        Score += 10;
    }
}

8️⃣ Ghost.cs

Hereda de Sprite

Movimiento (actualmente simple / random)

public class Ghost : Sprite
{
    public Ghost(int x, int y, string asset)
        : base(asset, Map.TileSize)
    {
        X = x;
        Y = y;
    }
}

🎯 Funcionalidades implementadas

✔ Render gráfico con sprites
✔ Laberinto centrado
✔ Movimiento de Pac-Man
✔ Píldoras y sistema de puntaje
✔ Fantasmas
✔ Colisiones
✔ Game Over
✔ HUD
✔ Arquitectura limpia y escalable

🟡 ROADMAP PROFESIONAL — PAC-MAN (.NET / WinForms)

Plan de evolución orientado a proyecto académico + portafolio.

🧱 FASE 1 — 🍒 Píldoras + Puntaje (COMPLETADA)

✔ TileType
✔ Map con pellets
✔ Score
✔ HUD
✔ Progreso real del jugador

🧠 FASE 2 — IA REAL DE FANTASMAS (BFS)

🎯 Objetivo:

Fantasmas persiguen a Pac-Man

Movimiento inteligente

Nueva clase
public class PathFinder
{
    public static Point NextStep(
        int startX, int startY,
        int targetX, int targetY,
        Map map)
    {
        // BFS clásico
    }
}


✅ Ideal para entrevistas técnicas.

🎮 FASE 3 — MENÚ INICIAL

Pantalla de inicio

Start / Exit

Reinicio de partida

public enum GameState
{
    Menu,
    Playing,
    GameOver
}

🔊 FASE 4 — SONIDO

Comer píldora

Game Over

Música de fondo

public static class SoundManager
{
    public static void PlayEat() =>
        new SoundPlayer("eat.wav").Play();
}

🗺️ FASE 5 — MAPAS GRANDES

Mapas desde .txt

Múltiples niveles

111111111111
120000000021
101110111101
100000000001
111111111111

🏆 FASE 6 — RANKING PERSISTENTE

Opciones:

Persistencia	Nivel
JSON	Académico
SQLite	Profesional
SQL Server	Empresarial
public class ScoreEntry
{
    public string Player { get; set; }
    public int Score { get; set; }
}

🧠 Orden recomendado de implementación

1️⃣ Píldoras + Puntaje
2️⃣ IA BFS Fantasmas
3️⃣ Menú Inicial
4️⃣ Sonido
5️⃣ Mapas grandes
6️⃣ Ranking persistente

📌 Estado actual del proyecto:
✅ Base sólida
✅ Código limpio
✅ Nivel portafolio profesional / .

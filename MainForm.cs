using System;
using System.Drawing;
using System.Windows.Forms;

namespace pacman_game
{
    public partial class MainForm : Form
    {
        private System.Windows.Forms.Timer timer;
        private GameEngine engine;

        public MainForm()
        {
            InitializeComponent();

            DoubleBuffered = true;
            KeyPreview = true;

            engine = new GameEngine();

            // 🧠 Ajustar tamaño del panel al mapa
            gamePanel.Width = engine.MapWidthInPixels;
            gamePanel.Height = engine.MapHeightInPixels;

            // 🧠 Ajustar ventana al panel
            ClientSize = new Size(
                gamePanel.Width,
                gamePanel.Height + 40   // espacio HUD (score)
            );

            timer = new System.Windows.Forms.Timer { Interval = 120 };
            timer.Tick += (s, e) =>
            {
                engine.Update();
                gamePanel.Invalidate();
            };
            timer.Start();

            KeyDown += (s, e) => engine.HandleInput(e.KeyCode);
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            engine.Draw(e.Graphics);
        }
    }
}

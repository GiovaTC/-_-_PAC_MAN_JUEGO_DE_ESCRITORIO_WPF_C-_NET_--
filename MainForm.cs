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

            // 🧠 El panel ocupa TODO el cliente
            gamePanel.Dock = DockStyle.Fill;
            gamePanel.BackColor = Color.Black;
            gamePanel.Paint += gamePanel_Paint;

            // 🧠 Timer del juego
            timer = new System.Windows.Forms.Timer { Interval = 120 };
            timer.Tick += (s, e) =>
            {
                engine.Update();
                gamePanel.Invalidate(); // 🔁 fuerza repintado
            };
            timer.Start();

            KeyDown += (s, e) => engine.HandleInput(e.KeyCode);
        }

        private void gamePanel_Paint(object sender, PaintEventArgs e)
        {
            // ✅ LLAMADA CORRECTA A DRAW
            engine.Draw(e.Graphics, gamePanel.ClientSize);
        }
    }
}

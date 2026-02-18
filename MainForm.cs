using System;
using System.Drawing;
using System.Windows.Forms;

namespace pacman_game
{
    public partial class MainForm : Form
    {
        System.Windows.Forms.Timer timer;
        GameEngine engine;

        public MainForm()
        {
            InitializeComponent();   // ⚠️ OBLIGATORIO
            DoubleBuffered = true;

            engine = new GameEngine();

            timer = new System.Windows.Forms.Timer { Interval = 120 };
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

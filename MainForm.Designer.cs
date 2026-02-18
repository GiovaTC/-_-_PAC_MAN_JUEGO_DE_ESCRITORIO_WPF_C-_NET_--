namespace pacman_game
{
    partial class MainForm
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Panel gamePanel;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
                components.Dispose();

            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            gamePanel = new System.Windows.Forms.Panel();
            SuspendLayout();

            // 
            // gamePanel
            // 
            gamePanel.Dock = System.Windows.Forms.DockStyle.Fill;
            gamePanel.BackColor = System.Drawing.Color.Black;
            gamePanel.Paint += gamePanel_Paint;

            // 
            // MainForm
            // 
            AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            ClientSize = new System.Drawing.Size(800, 600);
            Controls.Add(gamePanel);
            FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            MaximizeBox = false;
            Name = "MainForm";
            StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            Text = "PAC-MAN";
            ResumeLayout(false);
        }

        #endregion
    }
}

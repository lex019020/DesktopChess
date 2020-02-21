namespace DesktopChess
{
    partial class ChooseFigureForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.QueenPanel = new System.Windows.Forms.Panel();
            this.RookPanel = new System.Windows.Forms.Panel();
            this.BishopPanel = new System.Windows.Forms.Panel();
            this.HorsePanel = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // QueenPanel
            // 
            this.QueenPanel.BackColor = System.Drawing.Color.White;
            this.QueenPanel.BackgroundImage = global::DesktopChess.Properties.Resources.Chess_wq;
            this.QueenPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.QueenPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.QueenPanel.Location = new System.Drawing.Point(12, 12);
            this.QueenPanel.Name = "QueenPanel";
            this.QueenPanel.Size = new System.Drawing.Size(100, 100);
            this.QueenPanel.TabIndex = 0;
            this.QueenPanel.Click += new System.EventHandler(this.QueenPanel_Click);
            // 
            // RookPanel
            // 
            this.RookPanel.BackColor = System.Drawing.Color.White;
            this.RookPanel.BackgroundImage = global::DesktopChess.Properties.Resources.Chess_wr;
            this.RookPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.RookPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.RookPanel.Location = new System.Drawing.Point(128, 12);
            this.RookPanel.Name = "RookPanel";
            this.RookPanel.Size = new System.Drawing.Size(100, 100);
            this.RookPanel.TabIndex = 1;
            this.RookPanel.Click += new System.EventHandler(this.RookPanel_Click);
            // 
            // BishopPanel
            // 
            this.BishopPanel.BackColor = System.Drawing.Color.White;
            this.BishopPanel.BackgroundImage = global::DesktopChess.Properties.Resources.Chess_wb;
            this.BishopPanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.BishopPanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.BishopPanel.Location = new System.Drawing.Point(244, 12);
            this.BishopPanel.Name = "BishopPanel";
            this.BishopPanel.Size = new System.Drawing.Size(100, 100);
            this.BishopPanel.TabIndex = 1;
            this.BishopPanel.Click += new System.EventHandler(this.BishopPanel_Click);
            // 
            // HorsePanel
            // 
            this.HorsePanel.BackColor = System.Drawing.Color.White;
            this.HorsePanel.BackgroundImage = global::DesktopChess.Properties.Resources.Chess_wh;
            this.HorsePanel.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.HorsePanel.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.HorsePanel.Location = new System.Drawing.Point(360, 12);
            this.HorsePanel.Name = "HorsePanel";
            this.HorsePanel.Size = new System.Drawing.Size(100, 100);
            this.HorsePanel.TabIndex = 1;
            this.HorsePanel.Click += new System.EventHandler(this.HorsePanel_Click);
            // 
            // ChooseFigureForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(481, 153);
            this.ControlBox = false;
            this.Controls.Add(this.HorsePanel);
            this.Controls.Add(this.BishopPanel);
            this.Controls.Add(this.RookPanel);
            this.Controls.Add(this.QueenPanel);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Name = "ChooseFigureForm";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.Text = "Выберите фигуру";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel QueenPanel;
        private System.Windows.Forms.Panel RookPanel;
        private System.Windows.Forms.Panel BishopPanel;
        private System.Windows.Forms.Panel HorsePanel;
    }
}
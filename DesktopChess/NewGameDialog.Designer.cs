namespace DesktopChess
{
    partial class NewGameDialog
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.delWbCb = new System.Windows.Forms.CheckBox();
            this.delWhCb = new System.Windows.Forms.CheckBox();
            this.delWrCb = new System.Windows.Forms.CheckBox();
            this.delWqCb = new System.Windows.Forms.CheckBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.radioButton2 = new System.Windows.Forms.RadioButton();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.delBbCb = new System.Windows.Forms.CheckBox();
            this.delBhCb = new System.Windows.Forms.CheckBox();
            this.delBrCb = new System.Windows.Forms.CheckBox();
            this.delBqCb = new System.Windows.Forms.CheckBox();
            this.textBox1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.radioButton3 = new System.Windows.Forms.RadioButton();
            this.radioButton4 = new System.Windows.Forms.RadioButton();
            this.button1 = new System.Windows.Forms.Button();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.delWbCb);
            this.groupBox1.Controls.Add(this.delWhCb);
            this.groupBox1.Controls.Add(this.delWrCb);
            this.groupBox1.Controls.Add(this.delWqCb);
            this.groupBox1.Enabled = false;
            this.groupBox1.Location = new System.Drawing.Point(191, 15);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox1.Size = new System.Drawing.Size(155, 140);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Белые фигуры";
            // 
            // delWbCb
            // 
            this.delWbCb.AutoSize = true;
            this.delWbCb.Location = new System.Drawing.Point(9, 107);
            this.delWbCb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.delWbCb.Name = "delWbCb";
            this.delWbCb.Size = new System.Drawing.Size(120, 21);
            this.delWbCb.TabIndex = 3;
            this.delWbCb.Text = "Убрать слона";
            this.delWbCb.UseVisualStyleBackColor = true;
            this.delWbCb.CheckedChanged += new System.EventHandler(this.delWbCb_CheckedChanged);
            // 
            // delWhCb
            // 
            this.delWhCb.AutoSize = true;
            this.delWhCb.Location = new System.Drawing.Point(9, 79);
            this.delWhCb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.delWhCb.Name = "delWhCb";
            this.delWhCb.Size = new System.Drawing.Size(112, 21);
            this.delWhCb.TabIndex = 2;
            this.delWhCb.Text = "Убрать коня";
            this.delWhCb.UseVisualStyleBackColor = true;
            this.delWhCb.CheckedChanged += new System.EventHandler(this.delWhCb_CheckedChanged);
            // 
            // delWrCb
            // 
            this.delWrCb.AutoSize = true;
            this.delWrCb.Location = new System.Drawing.Point(9, 50);
            this.delWrCb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.delWrCb.Name = "delWrCb";
            this.delWrCb.Size = new System.Drawing.Size(122, 21);
            this.delWrCb.TabIndex = 1;
            this.delWrCb.Text = "Убрать ладью";
            this.delWrCb.UseVisualStyleBackColor = true;
            this.delWrCb.CheckedChanged += new System.EventHandler(this.delWrCb_CheckedChanged);
            // 
            // delWqCb
            // 
            this.delWqCb.AutoSize = true;
            this.delWqCb.Location = new System.Drawing.Point(9, 25);
            this.delWqCb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.delWqCb.Name = "delWqCb";
            this.delWqCb.Size = new System.Drawing.Size(123, 21);
            this.delWqCb.TabIndex = 0;
            this.delWqCb.Text = "Убрать ферзя";
            this.delWqCb.UseVisualStyleBackColor = true;
            this.delWqCb.CheckedChanged += new System.EventHandler(this.delWqCb_CheckedChanged);
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(16, 36);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(162, 21);
            this.radioButton1.TabIndex = 1;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Стандартный набор";
            this.radioButton1.UseVisualStyleBackColor = true;
            this.radioButton1.CheckedChanged += new System.EventHandler(this.radioButton1_CheckedChanged);
            // 
            // radioButton2
            // 
            this.radioButton2.AutoSize = true;
            this.radioButton2.Location = new System.Drawing.Point(16, 65);
            this.radioButton2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton2.Name = "radioButton2";
            this.radioButton2.Size = new System.Drawing.Size(132, 21);
            this.radioButton2.TabIndex = 2;
            this.radioButton2.Text = "Другой набор...";
            this.radioButton2.UseVisualStyleBackColor = true;
            this.radioButton2.CheckedChanged += new System.EventHandler(this.radioButton2_CheckedChanged);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.delBbCb);
            this.groupBox2.Controls.Add(this.delBhCb);
            this.groupBox2.Controls.Add(this.delBrCb);
            this.groupBox2.Controls.Add(this.delBqCb);
            this.groupBox2.Enabled = false;
            this.groupBox2.Location = new System.Drawing.Point(353, 15);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox2.Size = new System.Drawing.Size(155, 140);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Чёрные фигуры";
            // 
            // delBbCb
            // 
            this.delBbCb.AutoSize = true;
            this.delBbCb.Location = new System.Drawing.Point(9, 107);
            this.delBbCb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.delBbCb.Name = "delBbCb";
            this.delBbCb.Size = new System.Drawing.Size(120, 21);
            this.delBbCb.TabIndex = 3;
            this.delBbCb.Text = "Убрать слона";
            this.delBbCb.UseVisualStyleBackColor = true;
            this.delBbCb.CheckedChanged += new System.EventHandler(this.delBbCb_CheckedChanged);
            // 
            // delBhCb
            // 
            this.delBhCb.AutoSize = true;
            this.delBhCb.Location = new System.Drawing.Point(9, 79);
            this.delBhCb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.delBhCb.Name = "delBhCb";
            this.delBhCb.Size = new System.Drawing.Size(112, 21);
            this.delBhCb.TabIndex = 2;
            this.delBhCb.Text = "Убрать коня";
            this.delBhCb.UseVisualStyleBackColor = true;
            this.delBhCb.CheckedChanged += new System.EventHandler(this.delBhCb_CheckedChanged);
            // 
            // delBrCb
            // 
            this.delBrCb.AutoSize = true;
            this.delBrCb.Location = new System.Drawing.Point(9, 50);
            this.delBrCb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.delBrCb.Name = "delBrCb";
            this.delBrCb.Size = new System.Drawing.Size(122, 21);
            this.delBrCb.TabIndex = 1;
            this.delBrCb.Text = "Убрать ладью";
            this.delBrCb.UseVisualStyleBackColor = true;
            this.delBrCb.CheckedChanged += new System.EventHandler(this.delBrCb_CheckedChanged);
            // 
            // delBqCb
            // 
            this.delBqCb.AutoSize = true;
            this.delBqCb.Location = new System.Drawing.Point(9, 25);
            this.delBqCb.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.delBqCb.Name = "delBqCb";
            this.delBqCb.Size = new System.Drawing.Size(123, 21);
            this.delBqCb.TabIndex = 0;
            this.delBqCb.Text = "Убрать ферзя";
            this.delBqCb.UseVisualStyleBackColor = true;
            this.delBqCb.CheckedChanged += new System.EventHandler(this.delBqCb_CheckedChanged);
            // 
            // textBox1
            // 
            this.textBox1.Location = new System.Drawing.Point(373, 162);
            this.textBox1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.textBox1.MaxLength = 5;
            this.textBox1.Name = "textBox1";
            this.textBox1.Size = new System.Drawing.Size(119, 22);
            this.textBox1.TabIndex = 4;
            this.textBox1.Text = "60";
            this.textBox1.TextChanged += new System.EventHandler(this.textBox1_TextChanged);
            this.textBox1.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.textBox1_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(196, 166);
            this.label1.Margin = new System.Windows.Forms.Padding(4, 0, 4, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(151, 17);
            this.label1.TabIndex = 5;
            this.label1.Text = "Время на игрока, мин";
            // 
            // radioButton3
            // 
            this.radioButton3.AutoSize = true;
            this.radioButton3.Checked = true;
            this.radioButton3.Location = new System.Drawing.Point(20, 25);
            this.radioButton3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton3.Name = "radioButton3";
            this.radioButton3.Size = new System.Drawing.Size(72, 21);
            this.radioButton3.TabIndex = 7;
            this.radioButton3.TabStop = true;
            this.radioButton3.Text = "Белые";
            this.radioButton3.UseVisualStyleBackColor = true;
            this.radioButton3.CheckedChanged += new System.EventHandler(this.radioButton3_CheckedChanged);
            // 
            // radioButton4
            // 
            this.radioButton4.AutoSize = true;
            this.radioButton4.Location = new System.Drawing.Point(20, 53);
            this.radioButton4.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.radioButton4.Name = "radioButton4";
            this.radioButton4.Size = new System.Drawing.Size(81, 21);
            this.radioButton4.TabIndex = 8;
            this.radioButton4.Text = "Чёрные";
            this.radioButton4.UseVisualStyleBackColor = true;
            // 
            // button1
            // 
            this.button1.DialogResult = System.Windows.Forms.DialogResult.OK;
            this.button1.Location = new System.Drawing.Point(172, 194);
            this.button1.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(183, 47);
            this.button1.TabIndex = 9;
            this.button1.Text = "Начать";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.radioButton3);
            this.groupBox3.Controls.Add(this.radioButton4);
            this.groupBox3.Location = new System.Drawing.Point(17, 110);
            this.groupBox3.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Padding = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.groupBox3.Size = new System.Drawing.Size(165, 78);
            this.groupBox3.TabIndex = 10;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Первый ход";
            // 
            // NewGameDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(527, 252);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.textBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.radioButton2);
            this.Controls.Add(this.radioButton1);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedDialog;
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "NewGameDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Новая игра";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.NewGameDialog_FormClosing);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.CheckBox delWbCb;
        private System.Windows.Forms.CheckBox delWhCb;
        private System.Windows.Forms.CheckBox delWrCb;
        private System.Windows.Forms.CheckBox delWqCb;
        private System.Windows.Forms.RadioButton radioButton2;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.CheckBox delBbCb;
        private System.Windows.Forms.CheckBox delBhCb;
        private System.Windows.Forms.CheckBox delBrCb;
        private System.Windows.Forms.CheckBox delBqCb;
        private System.Windows.Forms.TextBox textBox1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.RadioButton radioButton3;
        private System.Windows.Forms.RadioButton radioButton4;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}
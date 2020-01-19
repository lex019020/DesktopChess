using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DesktopChess
{
    public partial class NewGameDialog : Form
    {
        public NewGameDialog()
        {
            InitializeComponent();
        }

        public int Time = 60;
        public FigureSide FirstTurn = FigureSide.White;
        public bool DelWq = false, DelWr = false, DelWh = false, DelWb = false, 
                    DelBq = false, DelBr = false, DelBh = false, DelBb = false;

        private void delWqCb_CheckedChanged(object sender, EventArgs e)
        {
            DelWq = delWqCb.Checked;
        }

        private void delWrCb_CheckedChanged(object sender, EventArgs e)
        {
            DelWr = delWrCb.Checked;
        }

        private void delWhCb_CheckedChanged(object sender, EventArgs e)
        {
            DelWh = delWhCb.Checked;
        }

        private void delWbCb_CheckedChanged(object sender, EventArgs e)
        {
            DelWb = delWbCb.Checked;
        }

        private void delBqCb_CheckedChanged(object sender, EventArgs e)
        {
            DelBq = delBqCb.Checked;
        }

        private void delBrCb_CheckedChanged(object sender, EventArgs e)
        {
            DelBr = delBrCb.Checked;
        }

        private void delBhCb_CheckedChanged(object sender, EventArgs e)
        {
            DelBh = delBhCb.Checked;
        }

        private void delBbCb_CheckedChanged(object sender, EventArgs e)
        {
            DelBb = delBbCb.Checked;
        }

        private void radioButton3_CheckedChanged(object sender, EventArgs e)
        {
            FirstTurn = radioButton3.Checked ? FigureSide.White : FigureSide.Black;
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {

        }

        private void NewGameDialog_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (e.CloseReason == CloseReason.UserClosing)
                this.DialogResult = DialogResult.Cancel;
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            Time = textBox1.Text.Length > 0 ? Convert.ToInt32(textBox1.Text) : 1;
        }

        private void textBox1_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!(char.IsDigit(e.KeyChar) || e.KeyChar == (char)8 ))
                e.Handled = true;
        }

        private void radioButton2_CheckedChanged(object sender, EventArgs e)
        {
            groupBox1.Enabled = radioButton2.Checked;
            groupBox2.Enabled = radioButton2.Checked;
            if (radioButton2.Checked) return;
            delBbCb.Checked = false;
            delBqCb.Checked = false;
            delBrCb.Checked = false;
            delBhCb.Checked = false;
            delWbCb.Checked = false;
            delWqCb.Checked = false;
            delWrCb.Checked = false;
            delWhCb.Checked = false;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.OK;

        }
    }
}

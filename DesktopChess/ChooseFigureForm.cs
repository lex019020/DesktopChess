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
    public partial class ChooseFigureForm : Form
    {
        public ChooseFigureForm()
        {
            InitializeComponent();
        }

        public FigureType Fig;

        private void QueenPanel_Click(object sender, EventArgs e)
        {
            Fig = FigureType.Queen;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void RookPanel_Click(object sender, EventArgs e)
        {
            Fig = FigureType.Rook;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BishopPanel_Click(object sender, EventArgs e)
        {
            Fig = FigureType.Bishop;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void HorsePanel_Click(object sender, EventArgs e)
        {
            Fig = FigureType.Horse;
            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}

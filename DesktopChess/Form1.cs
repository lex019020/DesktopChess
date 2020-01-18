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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            var defaultDesk = new Desk();
            label1.Text = defaultDesk.ToString();
            label2.Text = defaultDesk.WhiteKing.IsAtacked(defaultDesk).ToString();
            var list = defaultDesk.FieldOfFigures[4, 6].GetPossibleMoves(defaultDesk);
        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using DesktopChess.Properties;

namespace DesktopChess
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private Panel[,] _panels;
        private Game _game;
        private string _chosenCell;
        private FieldState _state;
        private Color _moveColor;
        private void Form1_Load(object sender, EventArgs e)
        {
            _panels = new[,]
            {
                {cell_a1, cell_a2, cell_a3, cell_a4, cell_a5, cell_a6, cell_a7, cell_a8}, 
                {cell_b1, cell_b2, cell_b3, cell_b4, cell_b5, cell_b6, cell_b7, cell_b8},
                {cell_c1, cell_c2, cell_c3, cell_c4, cell_c5, cell_c6, cell_c7, cell_c8},
                {cell_d1, cell_d2, cell_d3, cell_d4, cell_d5, cell_d6, cell_d7, cell_d8},
                {cell_e1, cell_e2, cell_e3, cell_e4, cell_e5, cell_e6, cell_e7, cell_e8},
                {cell_f1, cell_f2, cell_f3, cell_f4, cell_f5, cell_f6, cell_f7, cell_f8},
                {cell_g1, cell_g2, cell_g3, cell_g4, cell_g5, cell_g6, cell_g7, cell_g8},
                {cell_h1, cell_h2, cell_h3, cell_h4, cell_h5, cell_h6, cell_h7, cell_h8},
            };
            foreach (var panel in _panels)
            {
                panel.Click += cell_Click;
            }

            _state = FieldState.NotStarted;
            _moveColor = Color.DarkSeaGreen;
        }

        private void start_button_Click(object sender, EventArgs e)
        {
            var newGameDialog = new NewGameDialog();
            if (newGameDialog.ShowDialog(this) != DialogResult.OK) return;

            _game = new Game();
            // TODO pawns and kings only

            if (newGameDialog.DelBb)
                _game.Desk.FieldOfFigures[5, 7] = null;
            if (newGameDialog.DelWb)
                _game.Desk.FieldOfFigures[5, 0] = null;
            if (newGameDialog.DelBh)
                _game.Desk.FieldOfFigures[6, 7] = null;
            if (newGameDialog.DelWh)
                _game.Desk.FieldOfFigures[6, 0] = null;
            if (newGameDialog.DelBr)
                _game.Desk.FieldOfFigures[0, 7] = null;
            if (newGameDialog.DelWr)
                _game.Desk.FieldOfFigures[0, 0] = null;
            if (newGameDialog.DelBq)
                _game.Desk.FieldOfFigures[3, 7] = null;
            if (newGameDialog.DelWq)
                _game.Desk.FieldOfFigures[3, 0] = null;


            game_panel.Visible = true;
            desk_panel.Visible = true;
            start_panel.Visible = false;
            RenewFigures();
            _state = FieldState.FigNotChosen;
        }

        private void RenewFigures()
        {
            foreach (var cell in _panels)
            {
                var pos = cell.Name.Split('_')[1];
                var fig = _game.GetFigAt(pos);
                if (fig == null)
                {
                    cell.BackgroundImage = null;
                    continue;
                }
                switch (fig.Item1)
                {
                    case FigureType.Pawn:
                        cell.BackgroundImage = fig.Item2 == FigureSide.Black
                            ? Resources.Chess_bp
                            : Resources.Chess_wp;
                        break;
                    case FigureType.Horse:
                        cell.BackgroundImage = fig.Item2 == FigureSide.Black 
                            ? Resources.Chess_bh 
                            : Resources.Chess_wh;
                        break;
                    case FigureType.Bishop:
                        cell.BackgroundImage = fig.Item2 == FigureSide.Black
                            ? Resources.Chess_bb
                            : Resources.Chess_wb;
                        break;
                    case FigureType.Rook:
                        cell.BackgroundImage = fig.Item2 == FigureSide.Black 
                            ? Resources.Chess_br 
                            : Resources.Chess_wr;
                        break;
                    case FigureType.Queen:
                        cell.BackgroundImage = fig.Item2 == FigureSide.Black 
                            ? Resources.Chess_bq 
                            : Resources.Chess_wq;
                        break;
                    case FigureType.King:
                        cell.BackgroundImage = fig.Item2 == FigureSide.Black 
                            ? Resources.Chess_bk 
                            : Resources.Chess_wk;
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        private void DrawMovesForCell(string cell)
        {
            for(var i = 0; i < 8; i++)
                for(var j = 0; j < 8; j++)
                {
                    _panels[i, j].BackColor = (i + j) % 2 == 0 ? Color.WhiteSmoke : Color.DarkGray;
                    _panels[i, j].BorderStyle = BorderStyle.None;
                }
            if(cell == null) return;
            var moves = _game.GetMovesForCell(cell);
            if(moves == null) return;
            foreach (var panel in _panels)
            {
                var cellName = panel.Name.Split('_')[1];
                if (moves.Contains(cellName))
                {
                    panel.BackColor = _moveColor;
                    panel.BorderStyle = BorderStyle.FixedSingle;
                }
            }
        }

        private void cell_Click(object sender, EventArgs e)
        {
            if(!(sender is Panel cell)) return;
            var cellName = cell.Name.Split('_')[1];
            switch (_state)
            {
                case FieldState.NotStarted:
                    return;
                case FieldState.Paused:
                    return;
                case FieldState.FigChosen:
                    if (cell.BackColor == _moveColor)
                    {
                        _game.DoAMove(_chosenCell, cellName);
                        RenewFigures();
                        _game.CurrentTurn = _game.CurrentTurn == FigureSide.Black 
                            ? FigureSide.White 
                            : FigureSide.Black;
                    }

                    _chosenCell = null;
                    _state = FieldState.FigNotChosen;
                    DrawMovesForCell(null);
                    break;
                case FieldState.FigNotChosen:
                    if(_game.GetFigAt(cellName) == null || _game.GetFigAt(cellName).Item2 != _game.CurrentTurn) return;
                    _chosenCell = cellName;
                    _state = FieldState.FigChosen;
                    DrawMovesForCell(_chosenCell);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }
    }
}

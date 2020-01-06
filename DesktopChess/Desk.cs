﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopChess
{
    class Desk
    {
        public List<Figure> allFigures { get; private set; }

        public Figure[,] fieldOfFigures { get; private set; }

        public King WhiteKing;

        public King BlackKing;

        public FigureSide CurrentTurn { get; private set; }

        public Desk()
        {
            // TODO
            // Create all figures
            // 
        }

        public void ApplyMove(FigMove move)
        {
            // TODO
        }

        public void ApplyMoves(IEnumerable<FigMove> moves)
        {
            foreach (var move in moves)
            {
                this.ApplyMove(move);
            }
        }

        public IEnumerator<Figure> WhiteEnumerator()
        {
            return allFigures.Where(figure => figure.FigureSide == FigureSide.White).GetEnumerator();
        }

        public IEnumerator<Figure> BlackEnumerator()
        {
            return allFigures.Where(figure => figure.FigureSide == FigureSide.Black).GetEnumerator();
        }
    }
}
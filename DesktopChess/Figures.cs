using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopChess
{
    class Figure
    {
        public Position Position;

        public virtual void GetPossibleTurns() {}

        public FigureSide FigureSide { get; protected set; }

        public FigureType FigureType { get; protected set; }

        public bool IsAtacked()
        {
            //TODO
            return false;
        }

    }

    class Pawn: Figure
    {
        Pawn(Position pos, FigureSide side, FigureType type)
        {
            Position = pos;
            this.FigureSide = side;
            this.FigureType = type;
        }


    }

    ////////////////...

    class King : Figure
    {
        King(Position pos, FigureSide side, FigureType type)
        {
            Position = pos;
            this.FigureSide = side;
            this.FigureType = type;
        }
    }


}

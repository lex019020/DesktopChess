using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopChess
{
    class Figure
    {
        public Position FigPosition;

        public virtual List<FigMove> GetPossibleTurns(Desk desk)
        {
            return new List<FigMove>();}

        public FigureSide FigureSide { get; protected set; }

        public FigureType FigureType { get; protected set; }

        public bool IsAtacked(Desk desk)
        {
            var opFigs = this.FigureSide == FigureSide.Black ? desk.WhiteFigures() : desk.BlackFigures();
            return opFigs.Any(fig => fig.GetPossibleTurns(desk).Any(move => move.AfterPosition.Equals(FigPosition) && move.CanEat));
        }

    }

    class Pawn: Figure
    {
        Pawn(Position pos, FigureSide side, FigureType type)
        {
            FigPosition = pos;
            this.FigureSide = side;
            this.FigureType = type;
        }

        public override List<FigMove> GetPossibleTurns(Desk desk)
        {
            var list = new List<FigMove>();
            int x, y;
            Position.FromTextToInt(this.FigPosition.GetPos(), out x, out y);
            switch (FigureSide)
            {
                case FigureSide.Black:
                {
                        if(y > 1 && desk.fieldOfFigures[x, y - 2] == null && desk.fieldOfFigures[x, y - 1] == null)
                            list.Add(new FigMove(this, this.FigPosition, new Position(x, y - 2), false));

                        if(y > 0 && desk.fieldOfFigures[x, y - 1] == null)
                            list.Add(new FigMove(this, FigPosition, new Position(x, y - 1), false));

                        if(y > 0 && x > 0 && desk.fieldOfFigures[x - 1, y - 1] != null && desk.fieldOfFigures[x - 1, y - 1].FigureSide == FigureSide.White)
                            list.Add(new FigMove(this, FigPosition, new Position(x-1,y-1), true));

                        if(y > 0 && x < 7 && desk.fieldOfFigures[x + 1, y - 1] != null && desk.fieldOfFigures[x + 1, y - 1].FigureSide == FigureSide.White)
                            list.Add(new FigMove(this, FigPosition, new Position(x+1,y-1), true));
                }
                    break;
                case FigureSide.White:
                {
                        if(y < 6 && desk.fieldOfFigures[x, y + 2] == null && desk.fieldOfFigures[x, y + 1] == null)
                            list.Add(new FigMove(this, this.FigPosition, new Position(x, y + 2), false));

                        if(y < 7 && desk.fieldOfFigures[x, y + 1] == null)
                            list.Add(new FigMove(this, FigPosition, new Position(x, y + 1), false));

                        if(y < 6 && x > 0 && desk.fieldOfFigures[x - 1, y + 1] != null && desk.fieldOfFigures[x - 1, y + 1].FigureSide == FigureSide.Black)
                            list.Add(new FigMove(this, FigPosition, new Position(x-1,y+1), true));

                        if(y < 6 && x < 7 && desk.fieldOfFigures[x + 1, y + 1] != null && desk.fieldOfFigures[x + 1, y + 1].FigureSide == FigureSide.Black)
                            list.Add(new FigMove(this, FigPosition, new Position(x+1,y+1), true));
                }
                    break;
            }

            return list;
        }


    }

    ////////////////...

    class King : Figure
    {
        King(Position pos, FigureSide side, FigureType type)
        {
            FigPosition = pos;
            this.FigureSide = side;
            this.FigureType = type;
        }

        public override List<FigMove> GetPossibleTurns(Desk desk)
        {
            var list = new List<FigMove>();



            return list;
        }
    }


}

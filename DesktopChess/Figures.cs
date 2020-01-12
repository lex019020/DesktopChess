using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopChess
{
    [Serializable]
    abstract class Figure
    {
        public Position FigPosition;

        public abstract List<FigMove> GetPossibleMoves(Desk desk);

        public FigureSide FigureSide { get; protected set; }

        public FigureType FigureType { get; protected set; }

        public bool IsAtacked(Desk desk)
        {
            var opFigs = this.FigureSide == FigureSide.Black ? desk.WhiteFigures() : desk.BlackFigures();
            return opFigs.Any(fig => fig.GetPossibleMoves(desk).Any(move => move.AfterPosition.Equals(FigPosition) && move.CanEat));
        }

        /// <summary>
        /// Returns can figure atack or move to position
        /// </summary>
        /// <param name="desk">Current desk object</param>
        /// <param name="xDelta"></param>
        /// <param name="yDelta"></param>
        /// <returns>True if coordinates are OK and cell is empty or enemy</returns>
        public bool CanAtackTo(Desk desk, int xDelta, int yDelta)
        {
            Position.FromTextToInt(FigPosition.GetPos(), out var x, out var y);
            if (x + xDelta < 0 || x + xDelta > 7) return false;
            if (y + yDelta < 0 || y + yDelta > 7) return false;
            return desk.FieldOfFigures[x + xDelta, y + yDelta] == null || desk.FieldOfFigures[x + xDelta, y + yDelta].FigureSide != FigureSide;
        }

        protected bool IsMoveOpensKing(Desk desk, int xDelta, int yDelta)
        {
            var deskCopy = desk.GetCopy();
            Position.FromTextToInt(FigPosition.GetPos(), out var x, out var y);
            deskCopy.ApplyMove(new FigMove(this, FigPosition, new Position(x + xDelta, y + yDelta), true));
            return FigureSide == FigureSide.Black ? deskCopy.BlackKing.IsAtacked(deskCopy) : deskCopy.WhiteKing.IsAtacked(deskCopy);
        }

        /// <summary>
        /// Try to add atacking move in list of moves
        /// </summary>
        /// <param name="desk"></param>
        /// <param name="list"></param>
        /// <param name="xDelta"></param>
        /// <param name="yDelta"></param>
        /// <returns>True if added succesfully</returns>
        protected bool TryToAddMove(Desk desk, List<FigMove> list, int xDelta, int yDelta)
        {
            Position.FromTextToInt(FigPosition.GetPos(), out var x, out var y);
            if (!CanAtackTo(desk, xDelta, yDelta) || IsMoveOpensKing(desk, xDelta, yDelta)) return false;
            list.Add(new FigMove(this, FigPosition, new Position(x + xDelta, y + yDelta), true));
            return true;

        }

    }

    [Serializable]
    class Pawn: Figure
    {
        public Pawn(Position pos, FigureSide side)
        {
            FigPosition = pos;
            FigureSide = side;
            FigureType = FigureType.Pawn;
        }

        public override List<FigMove> GetPossibleMoves(Desk desk)
        {
            var list = new List<FigMove>();
            Position.FromTextToInt(this.FigPosition.GetPos(), out var x, out var y);
            switch (FigureSide)
            {
                case FigureSide.Black:
                {
                        if(y > 1 && desk.FieldOfFigures[x, y - 2] == null && desk.FieldOfFigures[x, y - 1] == null && !IsMoveOpensKing(desk, 0, -2))
                            list.Add(new FigMove(this, FigPosition, new Position(x, y - 2), false));

                        if(y > 0 && desk.FieldOfFigures[x, y - 1] == null && !IsMoveOpensKing(desk, 0, -1))
                            list.Add(new FigMove(this, FigPosition, new Position(x, y - 1), false));

                        if (CanAtackTo(desk, -1, -1) && !IsMoveOpensKing(desk, -1, -1) && desk.FieldOfFigures[x-1,y-1] != null)
                            list.Add(new FigMove(this, FigPosition, new Position(x-1, y-1), true));
                        if (CanAtackTo(desk, 1, -1) && !IsMoveOpensKing(desk, 1, -1) && desk.FieldOfFigures[x+1,y-1] != null)
                            list.Add(new FigMove(this, FigPosition, new Position(x+1, y-1), true));

                        
                }
                    break;
                case FigureSide.White:
                {
                        if(y < 6 && desk.FieldOfFigures[x, y + 2] == null && desk.FieldOfFigures[x, y + 1] == null && !IsMoveOpensKing(desk, 0, 2))
                            list.Add(new FigMove(this, this.FigPosition, new Position(x, y + 2), false));

                        if(y < 7 && desk.FieldOfFigures[x, y + 1] == null && !IsMoveOpensKing(desk, 0, 1))
                            list.Add(new FigMove(this, FigPosition, new Position(x, y + 1), false));

                        if (CanAtackTo(desk, 1, 1) && !IsMoveOpensKing(desk, 1, 1) && desk.FieldOfFigures[x+1,y+1] != null)
                            list.Add(new FigMove(this, FigPosition, new Position(x+1, y+1), true));
                        if (CanAtackTo(desk, -1, 1) && !IsMoveOpensKing(desk, -1, 1) && desk.FieldOfFigures[x-1,y+1] != null)
                            list.Add(new FigMove(this, FigPosition, new Position(x-1, y+1), true));
                }
                    break;
            }

            return list;
        }


    }

    [Serializable]
    class Horse : Figure
    {
        public Horse(Position pos, FigureSide side)
        {
            FigPosition = pos;
            FigureSide = side;
            FigureType = FigureType.Horse;
        }

        public override List<FigMove> GetPossibleMoves(Desk desk)
        {
            var list = new List<FigMove>();

            TryToAddMove(desk, list, 1, 2);
            TryToAddMove(desk, list, -1, 2);
            TryToAddMove(desk, list, 2, 1);
            TryToAddMove(desk, list, -2, 1);
            TryToAddMove(desk, list, -2 , -1);
            TryToAddMove(desk, list, -1, -2);
            TryToAddMove(desk, list, 1, -2);
            TryToAddMove(desk, list, 2, -1);

            return list;
        }
    }


    [Serializable]
    class Bishop : Figure
    {
        public Bishop(Position pos, FigureSide side)
        {
            FigPosition = pos;
            FigureSide = side;
            FigureType = FigureType.Bishop;
        }

        public override List<FigMove> GetPossibleMoves(Desk desk)
        {
            var list = new List<FigMove>();

            for (var i = 1; i < 7; i++)
            {
                if(!TryToAddMove(desk, list, i, i)) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if(!TryToAddMove(desk, list, i, -i)) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if(!TryToAddMove(desk, list, -i, i)) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if(!TryToAddMove(desk, list, -i, -i)) break;
            }

            return list;
        }
    }

    [Serializable]
    class Rook : Figure
    {

        public Rook(Position pos, FigureSide side)
        {
            FigPosition = pos;
            FigureSide = side;
            FigureType = FigureType.Rook;
        }

        public override List<FigMove> GetPossibleMoves(Desk desk)
        {
            var list = new List<FigMove>();

            for (var i = 1; i < 7; i++)
            {
                if(!TryToAddMove(desk, list, 0, i)) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if(!TryToAddMove(desk, list, 0, -i)) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if(!TryToAddMove(desk, list, i, 0)) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if(!TryToAddMove(desk, list, -i, 0)) break;
            }

            return list;
        }
    }

    [Serializable]
    class Queen : Figure
    {
        public Queen(Position pos, FigureSide side)
        {
            FigPosition = pos;
            FigureSide = side;
            FigureType = FigureType.Queen;
        }

        public override List<FigMove> GetPossibleMoves(Desk desk)
        {
            var list = new List<FigMove>();

            for (var i = 1; i < 7; i++)
            {
                if(!TryToAddMove(desk, list, 0, i)) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if(!TryToAddMove(desk, list, 0, -i)) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if(!TryToAddMove(desk, list, i, 0)) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if(!TryToAddMove(desk, list, -i, 0)) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if(!TryToAddMove(desk, list, i, i)) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if(!TryToAddMove(desk, list, i, -i)) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if(!TryToAddMove(desk, list, -i, i)) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if(!TryToAddMove(desk, list, -i, -i)) break;
            }

            return list;
        }
    }


    [Serializable]
    class King : Figure
    {
        public King(Position pos, FigureSide side)
        {
            FigPosition = pos;
            this.FigureSide = side;
            this.FigureType = FigureType.King;
        }

        public override List<FigMove> GetPossibleMoves(Desk desk)
        {
            var list = new List<FigMove>();

            TryToAddMove(desk, list,-1,1);
            TryToAddMove(desk, list,0,1);
            TryToAddMove(desk, list,1,1);
            TryToAddMove(desk, list,1,0);
            TryToAddMove(desk, list,1,-1);
            TryToAddMove(desk, list,0,-1);
            TryToAddMove(desk, list,-1,-1);
            TryToAddMove(desk, list,-1,0);

            // TODO рокировка

            return list;
        }
    }


}

using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopChess
{
    [Serializable]
    public abstract class Figure
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
            Position.FromTextToInt(FigPosition.GetPos(), out var x, out var y);
            var tmp = desk.FieldOfFigures[x + xDelta, y + yDelta];
            desk.FieldOfFigures[x + xDelta, y + yDelta] = this;
            this.FigPosition = new Position(x + xDelta, y + yDelta);
            desk.FieldOfFigures[x, y] = null;
            var ret = FigureSide == FigureSide.White ? desk.WhiteKing.IsAtacked(desk) : desk.BlackKing.IsAtacked(desk);
            desk.FieldOfFigures[x + xDelta, y + yDelta] = tmp;
            desk.FieldOfFigures[x, y] = this;
            this.FigPosition = new Position(x, y);
            return ret;
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
            list.Add(new FigMove(this, new Position(x + xDelta, y + yDelta), true));
            return true;

        }

        protected bool TryToAddMove(Desk desk, List<FigMove> list, int xDelta, int yDelta, out bool willEat)
        {
            var ret = TryToAddMove(desk, list, xDelta, yDelta);
            if (!ret)
            {
                willEat = false;
                return false;
            }
            Position.FromTextToInt(FigPosition.GetPos(), out var x, out var y);
            willEat = desk.FieldOfFigures[x + xDelta, y + yDelta] != null;
            return true;
        }

        public override string ToString()
        {
            return FigureSide + " " + FigureType + " at " + FigPosition.GetPos();
        }
    }

    [Serializable]
    public class Pawn : Figure
    {
        private bool _isMoved = false;
        public Pawn(Position pos, FigureSide side, bool isMoved = false)
        {
            FigPosition = pos;
            FigureSide = side;
            FigureType = FigureType.Pawn;
            _isMoved = isMoved;
        }

        public override List<FigMove> GetPossibleMoves(Desk desk)
        {
            var list = new List<FigMove>();
            Position.FromTextToInt(this.FigPosition.GetPos(), out var x, out var y);
            switch (FigureSide)
            {
                case FigureSide.Black:
                {
                        if (!_isMoved && y > 1 && desk.FieldOfFigures[x, y - 2] == null && desk.FieldOfFigures[x, y - 1] == null && !IsMoveOpensKing(desk, 0, -2))
                            list.Add(new FigMove(this, new Position(x, y - 2), false));

                        if (y > 0 && desk.FieldOfFigures[x, y - 1] == null && !IsMoveOpensKing(desk, 0, -1))
                            list.Add(new FigMove(this, new Position(x, y - 1), false));

                        if (CanAtackTo(desk, -1, -1) && !IsMoveOpensKing(desk, -1, -1) && desk.FieldOfFigures[x - 1, y - 1] != null)
                            list.Add(new FigMove(this, new Position(x - 1, y - 1), true));
                        if (CanAtackTo(desk, 1, -1) && !IsMoveOpensKing(desk, 1, -1) && desk.FieldOfFigures[x + 1, y - 1] != null)
                            list.Add(new FigMove(this, new Position(x + 1, y - 1), true));


                }
                    break;
                case FigureSide.White:
                    {
                        if (!_isMoved && y < 6 && desk.FieldOfFigures[x, y + 2] == null && desk.FieldOfFigures[x, y + 1] == null && !IsMoveOpensKing(desk, 0, 2))
                            list.Add(new FigMove(this, new Position(x, y + 2), false));

                        if (y < 7 && desk.FieldOfFigures[x, y + 1] == null && !IsMoveOpensKing(desk, 0, 1))
                            list.Add(new FigMove(this, new Position(x, y + 1), false));

                        if (CanAtackTo(desk, 1, 1) && !IsMoveOpensKing(desk, 1, 1) && desk.FieldOfFigures[x + 1, y + 1] != null)
                            list.Add(new FigMove(this, new Position(x + 1, y + 1), true));
                        if (CanAtackTo(desk, -1, 1) && !IsMoveOpensKing(desk, -1, 1) && desk.FieldOfFigures[x - 1, y + 1] != null)
                            list.Add(new FigMove(this, new Position(x - 1, y + 1), true));
                    }
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return list;
        }

        public void Moved()
        {
            this._isMoved = true;
        }
    }

    [Serializable]
    public class Horse : Figure
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
            TryToAddMove(desk, list, -2, -1);
            TryToAddMove(desk, list, -1, -2);
            TryToAddMove(desk, list, 1, -2);
            TryToAddMove(desk, list, 2, -1);

            return list;
        }
    }


    [Serializable]
    public class Bishop : Figure
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
                if (!TryToAddMove(desk, list, i, i, out var willEat) || willEat) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if (!TryToAddMove(desk, list, i, -i, out var willEat) || willEat) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if (!TryToAddMove(desk, list, -i, i, out var willEat) || willEat) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if (!TryToAddMove(desk, list, -i, -i, out var willEat) || willEat) break;
            }

            return list;
        }
    }

    [Serializable]
    public class Rook : Figure
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
                if (!TryToAddMove(desk, list, 0, i, out var willEat) || willEat) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if (!TryToAddMove(desk, list, 0, -i, out var willEat) || willEat) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if (!TryToAddMove(desk, list, i, 0, out var willEat) || willEat) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if (!TryToAddMove(desk, list, -i, 0, out var willEat) || willEat) break;
            }

            return list;
        }
    }

    [Serializable]
    public class Queen : Figure
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
                if (!TryToAddMove(desk, list, 0, i, out var willEat) || willEat) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if (!TryToAddMove(desk, list, 0, -i, out var willEat) || willEat) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if (!TryToAddMove(desk, list, i, 0, out var willEat) || willEat) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if (!TryToAddMove(desk, list, -i, 0, out var willEat) || willEat) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if (!TryToAddMove(desk, list, i, i, out var willEat) || willEat) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if (!TryToAddMove(desk, list, i, -i, out var willEat) || willEat) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if (!TryToAddMove(desk, list, -i, i, out var willEat) || willEat) break;
            }
            for (var i = 1; i < 7; i++)
            {
                if (!TryToAddMove(desk, list, -i, -i, out var willEat) || willEat) break;
            }

            return list;
        }
    }


    [Serializable]
    public class King : Figure
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

            TryToAddMove(desk, list, -1, 1);
            TryToAddMove(desk, list, 0, 1);
            TryToAddMove(desk, list, 1, 1);
            TryToAddMove(desk, list, 1, 0);
            TryToAddMove(desk, list, 1, -1);
            TryToAddMove(desk, list, 0, -1);
            TryToAddMove(desk, list, -1, -1);
            TryToAddMove(desk, list, -1, 0);

            // TODO castling

            return list;
        }

        public new bool IsAtacked(Desk desk)
        {
            Position.FromTextToInt(FigPosition.GetPos(), out var x, out var y);
            bool isUp = false, isDown = false, isRight = false, isLeft = false, 
                isUpRight = false, isUpLeft = false, isDownRight = false, isDownLeft = false;
            // sometimes works
            for (var i = 1; i < 8; i++)
            {
                if (!isUp && y + i < 8 && desk.FieldOfFigures[x, y + i] != null)
                {
                    isUp = true;
                    var fig = desk.FieldOfFigures[x, y + i];
                    if (fig.FigureSide != FigureSide &&
                        (fig.FigureType == FigureType.Rook || fig.FigureType == FigureType.Queen))
                        return true;
                }
                if (!isDown && y - i > -1 && desk.FieldOfFigures[x, y - i] != null)
                {
                    isDown = true;
                    var fig = desk.FieldOfFigures[x, y - i];
                    if (fig.FigureSide != FigureSide &&
                        (fig.FigureType == FigureType.Rook || fig.FigureType == FigureType.Queen))
                        return true;
                }
                if (!isRight && x + i < 8 && desk.FieldOfFigures[x + i, y] != null)
                {
                    isRight = true;
                    var fig = desk.FieldOfFigures[x + i, y];
                    if (fig.FigureSide != FigureSide &&
                        (fig.FigureType == FigureType.Rook || fig.FigureType == FigureType.Queen))
                        return true;
                }
                if (!isLeft && x - i > -1 && desk.FieldOfFigures[x - i, y] != null)
                {
                    isLeft = true;
                    var fig = desk.FieldOfFigures[x - i, y];
                    if (fig.FigureSide != FigureSide &&
                        (fig.FigureType == FigureType.Rook || fig.FigureType == FigureType.Queen))
                        return true;
                }

                if (x + i < 8)
                {
                    if (y + i < 8 && !isUpRight)
                    {
                        var fig = desk.FieldOfFigures[x + i, y + i];
                        if (fig != null)
                        {
                            isUpRight = true;
                            if (i == 1 && fig.FigureSide != FigureSide &&
                                fig.FigureType == FigureType.Pawn)
                                return true;
                            if (fig.FigureSide != FigureSide &&
                                (fig.FigureType == FigureType.Bishop || fig.FigureType == FigureType.Queen))
                                return true;
                        }
                    }

                    if (y - i > -1 && !isDownRight)
                    {
                        var fig = desk.FieldOfFigures[x + i, y - i];
                        if (fig != null)
                        {
                            isDownRight = true;
                            if (fig.FigureSide != FigureSide &&
                                (fig.FigureType == FigureType.Bishop || fig.FigureType == FigureType.Queen))
                                return true;
                        }
                    }
                }

                if (x - i > -1)
                {
                    if (y + i < 8 && !isUpLeft)
                    {
                        var fig = desk.FieldOfFigures[x - i, y + i];
                        if(fig != null)
                        {
                            isUpLeft = true;
                            if (i == 1 && fig.FigureSide != FigureSide && fig.FigureType == FigureType.Pawn)
                                return true;
                            if (fig.FigureSide != FigureSide &&
                                (fig.FigureType == FigureType.Bishop || fig.FigureType == FigureType.Queen))
                                return true;

                        }
                    }

                    if (y - i > -1 && !isDownLeft)
                    {
                        var fig = desk.FieldOfFigures[x - i, y - i];
                        if (fig != null)
                        {
                            isDownLeft = true;
                            if (fig.FigureSide != FigureSide &&
                                (fig.FigureType == FigureType.Bishop || fig.FigureType == FigureType.Queen))
                                return true;
                        }
                    }
                }
            }



            // Now check for horses and pawns
            if (x < 8 - 1 && y < 8 - 2)
            {
                var fig = desk.FieldOfFigures[x + 1, y + 2];
                if (fig != null && fig.FigureSide != FigureSide && fig.FigureType == FigureType.Horse)
                    return true;
            }
            if (x < 8 - 2 && y < 8 - 1)
            {
                var fig = desk.FieldOfFigures[x + 2, y + 1];
                if (fig != null && fig.FigureSide != FigureSide && fig.FigureType == FigureType.Horse)
                    return true;
            }
            if (x > 0 && y > 1)
            {
                var fig = desk.FieldOfFigures[x - 1, y - 2];
                if (fig != null && fig.FigureSide != FigureSide && fig.FigureType == FigureType.Horse)
                    return true;
            }
            if (x > 1 && y > 0)
            {
                var fig = desk.FieldOfFigures[x - 2, y - 1];
                if (fig != null && fig.FigureSide != FigureSide && fig.FigureType == FigureType.Horse)
                    return true;
            }
            if (x > 0 && y < 8 - 2)
            {
                var fig = desk.FieldOfFigures[x - 1, y + 2];
                if (fig != null && fig.FigureSide != FigureSide && fig.FigureType == FigureType.Horse)
                    return true;
            }
            if (x > 1 && y < 8 - 1)
            {
                var fig = desk.FieldOfFigures[x - 2, y + 1];
                if (fig != null && fig.FigureSide != FigureSide && fig.FigureType == FigureType.Horse)
                    return true;
            }
            if (x < 8 - 1 && y > 1)
            {
                var fig = desk.FieldOfFigures[x + 1, y - 2];
                if (fig != null && fig.FigureSide != FigureSide && fig.FigureType == FigureType.Horse)
                    return true;
            }
            if (x < 8 - 2 && y > 0)
            {
                var fig = desk.FieldOfFigures[x + 2, y - 1];
                if (fig != null && fig.FigureSide != FigureSide && fig.FigureType == FigureType.Horse)
                    return true;
            }


            return false;
        }
    }


}

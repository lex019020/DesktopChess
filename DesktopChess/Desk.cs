using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace DesktopChess
{
    public delegate void MateDelegate(FigureSide winner);

    public delegate void EatenHandler(Figure eatenFig);

    public delegate void VoidHandler();

    public delegate FigureType PawnSwapHandler(Pawn pawn);

    [Serializable]
    public class Desk
    {
        public Figure[,] FieldOfFigures { get; private set; }

        public King WhiteKing { get; private set; }

        public King BlackKing { get; private set; }


        public event MateDelegate OnMate;

        public event EatenHandler OnFigireEaten;

        public event VoidHandler OnFigEatenOrPaawnMove;

        public event VoidHandler OnTie;

        public PawnSwapHandler OnPawnSwap;

        public Desk()
        {
            FieldOfFigures = new Figure[8,8];

            FieldOfFigures[0,0] = new Rook(new Position(0, 0), FigureSide.White);
            FieldOfFigures[1,0] = new Horse(new Position(1,0), FigureSide.White);
            FieldOfFigures[2,0] = new Bishop(new Position(2,0), FigureSide.White);
            FieldOfFigures[7,0] = new Rook(new Position(7, 0), FigureSide.White);
            FieldOfFigures[6,0] = new Horse(new Position(6,0), FigureSide.White);
            FieldOfFigures[5,0] = new Bishop(new Position(5,0), FigureSide.White);
            FieldOfFigures[3,0] = new Queen(new Position(3,0), FigureSide.White);
            FieldOfFigures[4,0] = new King(new Position(4,0), FigureSide.White);
            for(var i = 0; i < 8; i++)
                FieldOfFigures[i, 1] = new Pawn(new Position(i, 1), FigureSide.White);

            FieldOfFigures[0,7] = new Rook(new Position(0, 7), FigureSide.Black);
            FieldOfFigures[1,7] = new Horse(new Position(1,7), FigureSide.Black);
            FieldOfFigures[2,7] = new Bishop(new Position(2,7), FigureSide.Black);
            FieldOfFigures[7,7] = new Rook(new Position(7, 7), FigureSide.Black);
            FieldOfFigures[6,7] = new Horse(new Position(6,7), FigureSide.Black);
            FieldOfFigures[5,7] = new Bishop(new Position(5,7), FigureSide.Black);
            FieldOfFigures[3,7] = new Queen(new Position(3,7), FigureSide.Black);
            FieldOfFigures[4,7] = new King(new Position(4,7), FigureSide.Black);
            for(var i = 0; i < 8; i++)
                FieldOfFigures[i, 6] = new Pawn(new Position(i, 6), FigureSide.Black);

            WhiteKing = FieldOfFigures[4, 0] as King;
            BlackKing = FieldOfFigures[4,7] as King;
            

        }

        public Desk(IEnumerable<Figure> figures)
        {
            bool bKing = false, wKing = false;
            FieldOfFigures = new Figure[8,8];
            foreach (var figure in figures)
            {
                Position.FromTextToInt(figure.FigPosition.GetPos(), out var x, out var y);
                FieldOfFigures[x, y] = figure;
                if(figure.FigureType == FigureType.King && figure.FigureSide == FigureSide.White)
                    if (!wKing)
                    {
                        WhiteKing = figure as King;
                        wKing = true;
                    }
                    else
                    {
                        throw new ArgumentException("Cannot have 2 white kings");
                    }

                if(figure.FigureType == FigureType.King && figure.FigureSide == FigureSide.Black)
                    if (!bKing)
                    {
                        BlackKing = figure as King;
                        bKing = true;
                    }
                    else
                    {
                        throw new ArgumentException("Cannot have 2 black kings");
                    }
            }
            if(!bKing || !wKing)
                throw  new ArgumentException("Desk must have 1 white and 1 black king");
        }

        public Desk GetCopy()
        {

            var stream = new MemoryStream();
            var formatter = new BinaryFormatter();
            formatter.Serialize(stream, this);
            stream.Seek(0, SeekOrigin.Begin);
            var s = formatter.Deserialize(stream) as Desk;
            stream.Close();
            return s;
        }

        public void ApplyMove(FigMove move)
        {
            if(move == null)
                return;
            if (!AllFigures().Contains(move.Figure))
            {
                var deskAggregate = AllFigures().Aggregate("", (current, figure) => current + figure + " ");
                throw new ArgumentException("Desk: " + deskAggregate + " \nfig: " + move.Figure);
            }
            
            Position.FromTextToInt(move.Figure.FigPosition.GetPos(), out var x, out var y);
            Position.FromTextToInt(move.AfterPosition.GetPos(), out var newX, out var newY);

            if (GetFigAtPosition(move.AfterPosition) == null)
            {
                FieldOfFigures[newX, newY] = move.Figure;
                move.Figure.FigPosition = move.AfterPosition;
                FieldOfFigures[x, y] = null;
                if (move.Figure.FigureType == FigureType.Pawn)
                {
                    OnFigEatenOrPaawnMove?.Invoke();
                }
                move.Figure.Moved();
                if(move.CastlingType != CastlingTypes.None)
                {
                    Rook crook = null; // rook for castling
                    // ReSharper disable once SwitchStatementMissingSomeCases
                    switch (move.CastlingType)
                    {
                        case CastlingTypes.ToRight:
                            crook = FieldOfFigures[7, y] as Rook;
                            FieldOfFigures[5, y] = crook;
                            if (crook != null) crook.FigPosition = new Position(5, y);
                            FieldOfFigures[7, y] = null;
                            break;
                        case CastlingTypes.ToLeft:
                            crook = FieldOfFigures[0,y] as Rook;
                            FieldOfFigures[2, y] = crook;
                            if (crook != null) crook.FigPosition = new Position(2, y);
                            FieldOfFigures[0, y] = null;
                            break;
                    }

                    crook.Moved();
                }

            }
            else
            {
                if (!GetFigAtPosition(move.AfterPosition).FigureSide.Equals(move.Figure.FigureSide))
                {
                    OnFigireEaten?.Invoke(GetFigAtPosition(move.AfterPosition));
                    OnFigEatenOrPaawnMove?.Invoke();

                    DelFigure(GetFigAtPosition(move.AfterPosition));
                    FieldOfFigures[newX, newY] = move.Figure;
                    move.Figure.FigPosition = move.AfterPosition;
                    FieldOfFigures[x, y] = null;
                    move.Figure.Moved();
                }
                else
                    throw new ArgumentException(move.Figure + " cannot eat " + GetFigAtPosition(move.AfterPosition));
            }



            CheckForPawnSwap();

            CheckForCheckmateOrTie();
        }

        public void ApplyMoves(IEnumerable<FigMove> moves)
        {
            foreach (var move in moves)
            {
                ApplyMove(move);
            }
        }

        public IEnumerable<Figure> WhiteFigures()
        {
            return AllFigures().Where(figure => figure.FigureSide == FigureSide.White);
        }

        public IEnumerable<Figure> BlackFigures()
        {
            return AllFigures().Where(figure => figure.FigureSide == FigureSide.Black);
        }

        public IEnumerable<Figure> AllFigures()
        {
            return FieldOfFigures.Cast<Figure>().Where(fig => fig != null);
        }

        public Figure GetFigAtPosition(Position pos)
        {
            return AllFigures().FirstOrDefault(fig => Equals(fig.FigPosition, pos));
        }

        private void DelFigure(Figure fig)
        {
            Position.FromTextToInt(fig.FigPosition.GetPos(), out var x, out var y);
            FieldOfFigures[x, y] = null;
        }

        private void CheckForCheckmateOrTie()
        {
            #region debug

            var wfigs = WhiteFigures();
            var bkmvs = BlackKing.GetPossibleMoves(this);
            var bfigs = WhiteFigures();
            var wkmvs = WhiteKing.GetPossibleMoves(this);

            #endregion

            if (WhiteKing.IsAtacked(this) && BlackKing.IsAtacked(this))
                throw new ApplicationException("What the fuck just happened?");

            if (WhiteKing.IsAtacked(this) || BlackKing.IsAtacked(this))
            {
                if (WhiteKing.IsAtacked(this))
                    if (WhiteFigures().All(fig => fig.GetPossibleMoves(this).Count == 0))
                        OnMate?.Invoke(FigureSide.Black);

                if (BlackKing.IsAtacked(this))
                    if (BlackFigures().All(fig => fig.GetPossibleMoves(this).Count == 0))
                        OnMate?.Invoke(FigureSide.White);
            }
            else
                if (WhiteFigures().All(fig => fig.GetPossibleMoves(this).Count == 0) ||
                    BlackFigures().All(fig => fig.GetPossibleMoves(this).Count == 0))
                {
                    OnTie?.Invoke();
                }

        }

        public void CheckForPawnSwap()
        {
            for (var i = 0; i < 8; i++)
            {
                var fig = FieldOfFigures[i, 0];
                if (fig == null || fig.FigureType != FigureType.Pawn || fig.FigureSide != FigureSide.Black)
                {
                    fig = FieldOfFigures[i, 7];
                    if (fig == null || fig.FigureType != FigureType.Pawn || fig.FigureSide != FigureSide.White)
                        continue;
                }

                var side = fig.FigureSide;
                Position.FromTextToInt(fig.FigPosition.GetPos(), out var x, out var y);
                var type = OnPawnSwap(fig as Pawn);
                // ReSharper disable once SwitchStatementMissingSomeCases
                switch (type)
                {
                    case FigureType.Horse:
                        FieldOfFigures[x,y] = new Horse(fig.FigPosition, side);
                        break;
                    case FigureType.Bishop:
                        FieldOfFigures[x,y] = new Bishop(fig.FigPosition, side);
                        break;
                    case FigureType.Rook:
                        FieldOfFigures[x,y] = new Rook(fig.FigPosition, side);
                        break;
                    case FigureType.Queen:
                        FieldOfFigures[x,y] = new Queen(fig.FigPosition, side);
                        break;
                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }
        }

        public override string ToString()
        {
            var s = "";

            for (var y = 7; y > -1; y--)
            {
                for (var x = 0; x < 8; x++)
                {
                    var fig = FieldOfFigures[x, y];
                    if (fig == null)
                    {
                        s += " ";
                        continue;
                    }
                    switch (fig.FigureType)
                    {
                        case FigureType.Pawn:
                            s += "P";
                            break;
                        case FigureType.Horse:
                            s += "H";
                            break;
                        case FigureType.Bishop:
                            s += "B";
                            break;
                        case FigureType.Rook:
                            s += "R";
                            break;
                        case FigureType.Queen:
                            s += "Q";
                            break;
                        case FigureType.King:
                            s += "K";
                            break;
                        default:
                            throw new ArgumentOutOfRangeException();
                    }
                }

                s += Environment.NewLine;
            }

            return s;
        }
    }
}

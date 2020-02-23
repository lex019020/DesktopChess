using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopChess
{
    [Serializable]
    public class Game
    {
        public Desk Desk;
        private int _movesWithoutAction;
        public List<Figure> WhiteEatenFigures { get; private set; }
        public List<Figure> BlackEatenFigures { get; private set; }
        public FigureSide CurrentTurn;
        public GameState CurrentState;
        public enum GameState
        {
            //NotStarted,
            Started,
            WhiteWon,
            BlackWon,
            Tied
        }

        public Game()
        {
            Desk = new Desk();
            CurrentTurn = FigureSide.White;
            CurrentState = GameState.Started;
            WhiteEatenFigures = new List<Figure>();
            BlackEatenFigures = new List<Figure>();
            _movesWithoutAction = 0;

            SubcribeToDeskEvents();
        }

        internal void SubcribeToDeskEvents()
        {
            Desk.OnFigEatenOrPaawnMove += Desk_OnFigEatenOrPaawnMove;
            Desk.OnFigireEaten += Desk_OnFigireEaten;
            Desk.OnMate += Desk_OnMate;
            Desk.OnTie += Desk_OnTie;
        }

        private void Desk_OnTie()
        {
            CurrentState = GameState.Tied;
        }

        private void Desk_OnMate(FigureSide winner)
        {
            CurrentState = winner == FigureSide.White ? GameState.WhiteWon : GameState.BlackWon;
        }

        private void Desk_OnFigireEaten(Figure eatenFig)
        {
            switch (eatenFig.FigureSide)
            {
                case FigureSide.White:
                    WhiteEatenFigures.Add(eatenFig);
                    break;
                case FigureSide.Black:
                    BlackEatenFigures.Add(eatenFig);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Desk_OnFigEatenOrPaawnMove()
        {
            _movesWithoutAction = 0;
        }

        public bool DoAMove(string figPosition, string move)
        {
            Position.FromTextToInt(figPosition, out var x, out var y);
            var fig = Desk.FieldOfFigures[x, y];
            if (fig == null || fig.FigureSide != CurrentTurn)
                return false;
            try
            {
                _movesWithoutAction++;
                Desk.ApplyMove(fig.GetPossibleMoves(Desk).FirstOrDefault(
                    mmove => mmove.AfterPosition.Equals(new Position(move))));
                if (_movesWithoutAction == 50)
                    Desk_OnTie();
            }
            catch (Exception)
            {
                _movesWithoutAction--;
                return false;
            }

            return true;
        }

        public List<string> GetMovesForCell(string cell)
        {
            Position.FromTextToInt(cell, out var x, out var y);
            if (CurrentState != GameState.Started)
                return null;
            if (x < 0 || x > 7 || y < 0 || y > 7)
                return null;

            var fig = Desk.FieldOfFigures[x, y];
            if (fig == null || fig.GetPossibleMoves(Desk).Count == 0)
                return null;

            return fig.GetPossibleMoves(Desk).Select(move => move.AfterPosition.GetPos()).ToList();
        }

        public Tuple<FigureType, FigureSide> GetFigAt(string pos)
        {
            Position.FromTextToInt(pos, out var x, out var y);
            if (Desk.FieldOfFigures[x, y] == null)
                return null;

            var fig = Desk.FieldOfFigures[x, y];
            return new Tuple<FigureType, FigureSide>(fig.FigureType, fig.FigureSide);
        }


    }
}

using System;
using System.Collections.Generic;
using System.Linq;

namespace DesktopChess
{
    class Game
    {
        private Desk desk;
        private int _movesWithoutAction;
        public List<Figure> WhiteEatenFigures { get; private set; }
        public List<Figure> BlackEanenFigures { get; private set; }
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
            desk = new Desk();
            CurrentTurn = FigureSide.White;
            CurrentState = GameState.Started;
            WhiteEatenFigures = new List<Figure>();
            BlackEanenFigures = new List<Figure>();
            _movesWithoutAction = 0;

            desk.OnFigEatenOrPaawnMove += Desk_OnFigEatenOrPaawnMove;
            desk.OnFigireEaten += Desk_OnFigireEaten;
            desk.OnMate += Desk_OnMate;
            desk.OnTie += Desk_OnTie;
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
                    BlackEanenFigures.Add(eatenFig);
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }
        }

        private void Desk_OnFigEatenOrPaawnMove()
        {
            _movesWithoutAction = 0;
        }

        public bool DoAMove(Tuple<int, int> figPosition, Tuple<int, int> move)
        {
            var fig = desk.FieldOfFigures[figPosition.Item1, figPosition.Item2];
            if (fig == null || fig.FigureSide != CurrentTurn)
                return false;
            try
            {
                _movesWithoutAction++;
                desk.ApplyMove(fig.GetPossibleMoves(desk).FirstOrDefault(
                    mmove => mmove.AfterPosition.Equals(new Position(move.Item1, move.Item2))));
                if(_movesWithoutAction == 50)
                    Desk_OnTie();
            }
            catch (Exception)
            {
                _movesWithoutAction--;
                return false;
            }

            return true;
        }

        public List<Tuple<int, int>> GetMovesForCell(int x, int y)
        {
            if (CurrentState != GameState.Started)
                return null;
            if (x < 0 || x > 7 || y < 0 || y > 7)
                return null;

            var fig = desk.FieldOfFigures[x, y];
            if (fig == null || fig.GetPossibleMoves(desk).Count == 0)
                return null;

            var list = new List<Tuple<int, int>>();

            foreach (var move in fig.GetPossibleMoves(desk))
            {
                Position.FromTextToInt(move.AfterPosition.GetPos(), out var xMove, out var yMove);
                list.Add(new Tuple<int, int>(xMove,yMove));
            }

            return list;
        }

        public Tuple<FigureType, FigureSide> GetFigAt(int x, int y)
        {
            if (desk.FieldOfFigures[x, y] == null)
                return null;

            var fig = desk.FieldOfFigures[x, y];
            return new Tuple<FigureType, FigureSide>(fig.FigureType, fig.FigureSide);
        }


    }
}

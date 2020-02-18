using System;
using System.Linq;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using DesktopChess;

namespace UnitTests
{
    [TestClass]
    public class UnitTest1
    {
        private Desk createEmptyDesk()
        {
            return new Desk(new Figure[]{new King(new Position(0, 0), FigureSide.White), new King(new Position(7, 7), FigureSide.Black)});
        }

        [TestMethod]
        public void DefaultDesk()
        {
            var defaultDesk = new Desk();
            Assert.AreEqual(0, defaultDesk.BlackKing.GetPossibleMoves(defaultDesk).Count);
        }

        [TestMethod]
        public void TestKings()
        {
            var defaultDesk = new Desk();
            Assert.AreEqual(false, defaultDesk.WhiteKing.IsAtacked(defaultDesk));
        }

        [TestMethod]
        public void TestSomeFigures()
        {
            var testDesk = new Desk();
            Assert.AreEqual(false, testDesk.FieldOfFigures[0, 0].IsAtacked(testDesk));
        }

        [TestMethod]
        public void AddQueen()
        {
            var defDesk = new Desk();
            defDesk.FieldOfFigures[4, 1] = new Queen(new Position(4, 1), FigureSide.Black);
            Assert.AreEqual(true, defDesk.WhiteKing.IsAtacked(defDesk));
        }

        [TestMethod]
        public void AddHorse()
        {
            var desk = new Desk();
            desk.FieldOfFigures[3, 2] = new Horse(new Position(4, 2), FigureSide.Black);
            Assert.AreEqual(true, desk.WhiteKing.IsAtacked(desk));
        }

        [TestMethod]
        public void CheckPawnsAndHorses()
        {
            var desk = new Desk();
            Assert.AreEqual(2, desk.FieldOfFigures[4, 1].GetPossibleMoves(desk).Count);
            Assert.AreEqual(2, desk.FieldOfFigures[4, 6].GetPossibleMoves(desk).Count);
            Assert.AreEqual(2, desk.FieldOfFigures[1, 0].GetPossibleMoves(desk).Count);
            Assert.AreEqual(2, desk.FieldOfFigures[1, 7].GetPossibleMoves(desk).Count);
        }

        [TestMethod]
        public void ApplyTwoPawnMoves()
        {
            var desk = new Desk();
            desk.ApplyMove(new FigMove(desk.FieldOfFigures[4, 1], new Position(4, 3), false));
            desk.ApplyMove(new FigMove(desk.FieldOfFigures[4, 6], new Position(4, 4), false));
            Assert.AreEqual(0, desk.FieldOfFigures[4, 3].GetPossibleMoves(desk).Count);
        }

        [TestMethod]
        public void TestBishop()
        {
            var desk = new Desk();
            desk.FieldOfFigures[2, 2] = new Bishop(new Position(2, 2), FigureSide.Black);
            Assert.AreEqual(false, desk.WhiteKing.IsAtacked(desk));
            desk.FieldOfFigures[3, 1] = new Bishop(new Position(3, 1), FigureSide.Black);
            Assert.AreEqual(true, desk.WhiteKing.IsAtacked(desk));
        }

        [TestMethod]
        public void AddIsolatedQueen()
        {
            var defDesk = new Desk();
            defDesk.FieldOfFigures[4, 2] = new Queen(new Position(4, 1), FigureSide.White);
            Assert.AreEqual(false, defDesk.BlackKing.IsAtacked(defDesk));
        }

        [TestMethod]
        public void CustomEmptyDesk()
        {
            var desk = createEmptyDesk();
        }

        [TestMethod]
        public void TwoQueensCantMove()
        {
            var desk = createEmptyDesk();
            desk.FieldOfFigures[1,1] = new Queen(new Position(1, 1), FigureSide.White);
            desk.FieldOfFigures[6, 6] = new Queen(new Position(6, 6), FigureSide.Black);
            Assert.AreEqual(5, desk.FieldOfFigures[1, 1].GetPossibleMoves(desk).Count);
        }

        [TestMethod]
        public void RookCheck()
        {
            var desk = createEmptyDesk();
            desk.FieldOfFigures[0, 7] = new Rook(new Position(0, 7), FigureSide.Black);
            Assert.AreEqual(true, desk.WhiteKing.IsAtacked(desk));
        }

        [TestMethod]
        public void TwoBlackPawns()
        {
            var desk = createEmptyDesk();
            desk.FieldOfFigures[6, 6] = new Pawn(new Position(6, 6), FigureSide.Black);
            desk.FieldOfFigures[5, 6] = new Pawn(new Position(5, 6), FigureSide.Black);
            desk.FieldOfFigures[1, 1] = new Queen(new Position(1, 1), FigureSide.White);
            Assert.AreEqual(0, desk.FieldOfFigures[6, 6].GetPossibleMoves(desk).Count);
            Assert.AreEqual(2, desk.FieldOfFigures[5, 6].GetPossibleMoves(desk).Count);
        }

        [TestMethod]
        public void FightOfPawns()
        {
            var desk = createEmptyDesk();
            desk.FieldOfFigures[3, 3] = new Pawn(new Position(3, 3), FigureSide.White, true);
            desk.FieldOfFigures[4, 4] = new Pawn(new Position(4, 4),FigureSide.Black );
            Assert.AreEqual(true, desk.FieldOfFigures[4, 4].IsAtacked(desk));
            Assert.AreEqual(2, desk.FieldOfFigures[3, 3].GetPossibleMoves(desk).Count);
            Assert.AreEqual(3, desk.FieldOfFigures[4, 4].GetPossibleMoves(desk).Count);
        }

        [TestMethod]
        public void PawnEatsOtherPawn()
        {
            var desk = createEmptyDesk();
            desk.FieldOfFigures[3, 3] = new Pawn(new Position(3, 3), FigureSide.White, true);
            desk.FieldOfFigures[4, 4] = new Pawn(new Position(4, 4),FigureSide.Black );
            var move = desk.FieldOfFigures[3, 3].GetPossibleMoves(desk)
                .First(mv => Equals(mv.AfterPosition, new Position(4, 4)));
            desk.ApplyMove(move);
            Console.WriteLine(desk.ToString());
        }

        [TestMethod]
        public void TestKingAtackedTime()
        {
            var desk = new Desk();
            desk.WhiteKing.IsAtacked(desk);
        }

        [TestMethod]
        public void TestQueenAtackedTime()
        {
            var desk = new Desk();
            desk.FieldOfFigures[3, 0].IsAtacked(desk);
        }

        [TestMethod]
        public void TestCheckedKing()
        {
            var desk = createEmptyDesk();
            desk.FieldOfFigures[1,1] = new Queen(new Position(1, 1), FigureSide.White);
            Assert.AreEqual(2, desk.BlackKing.GetPossibleMoves(desk).Count);
        }

        [TestMethod]
        public void TestMate()
        {
            var desk = createEmptyDesk();
            desk.FieldOfFigures[7, 0] = new Rook(new Position(7, 0), FigureSide.White);
            desk.FieldOfFigures[6, 0] = new Rook(new Position(6, 0), FigureSide.White);
            Assert.AreEqual(0, desk.BlackKing.GetPossibleMoves(desk).Count);
        }

        [TestMethod]
        public void DoAMate()
        {
            var desk = createEmptyDesk();
            desk.FieldOfFigures[7, 0] = new Rook(new Position(7, 0), FigureSide.White);
            desk.FieldOfFigures[5, 0] = new Rook(new Position(5, 0), FigureSide.White);
            desk.ApplyMove(new FigMove(desk.FieldOfFigures[5, 0], new Position("g1"), true ));
            Assert.AreEqual(0, desk.BlackKing.GetPossibleMoves(desk).Count);
        }
    }
}

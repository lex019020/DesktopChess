using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization.Formatters.Binary;

namespace DesktopChess
{
    [Serializable]
    class Desk
    {
        public List<Figure> AllFigures { get; private set; }

        public Figure[,] FieldOfFigures { get; private set; }

        public King WhiteKing;

        public King BlackKing;

        public FigureSide CurrentTurn { get; private set; }

        public Desk()
        {
            // Create all figures
            throw new NotImplementedException();
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
            throw new NotImplementedException();
        }

        public void ApplyMoves(IEnumerable<FigMove> moves)
        {
            foreach (var move in moves)
            {
                this.ApplyMove(move);
            }
        }

        public IEnumerable<Figure> WhiteFigures()
        {
            return AllFigures.Where(figure => figure.FigureSide == FigureSide.White);
        }

        public IEnumerable<Figure> BlackFigures()
        {
            return AllFigures.Where(figure => figure.FigureSide == FigureSide.Black);
        }

    }
}

namespace DesktopChess
{
    public class FigMove
    {
        public Figure Figure { get; }
        public Position AfterPosition { get; }
        public CastlingTypes CastlingType { get; }
        public bool CanEat { get; }

        public FigMove(Figure fig, Position pos2, bool canEat, CastlingTypes castling = CastlingTypes.None)
        {
            Figure = fig;
            AfterPosition = pos2;
            CanEat = canEat;
            CastlingType = castling;
        }
    }
}

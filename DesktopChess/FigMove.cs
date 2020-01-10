namespace DesktopChess
{
    class FigMove
    {
        public Figure Figure { get; }
        public Position BeforePosition { get; }
        public Position AfterPosition { get; }
        public bool CanEat { get; }

        public FigMove(Figure fig, Position pos1, Position pos2, bool canEat)
        {
            Figure = fig;
            BeforePosition = pos1;
            AfterPosition = pos2;
            CanEat = canEat;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopChess
{
    class FigMove
    {
        public Figure Figure { get; }
        public Position BeforePosition { get; }
        public Position AfterPosition { get; }

        public FigMove(Figure fig, Position pos1, Position pos2)
        {
            Figure = fig;
            BeforePosition = pos1;
            AfterPosition = pos2;
        }
    }
}

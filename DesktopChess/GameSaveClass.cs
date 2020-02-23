using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopChess
{
    [Serializable]
    public class GameSaveClass
    {
        public Game game;
        public TimeSpan bTime, wTime;

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DesktopChess
{
    class Position
    {
        private string pos;

        Position(int x, int y)
        {
            FromIntToText(x, y, out pos);
        }

        Position(string pos)
        {
            this.pos = pos;
        }

        /// <summary>
        /// Get a string position
        /// </summary>
        /// <returns></returns>
        public string GetPos() => pos;

        static void FromTextToInt(string pos, out int x, out int y)
        {
            if(pos.Length != 2)
                throw new ArgumentException();
            if(Convert.ToInt32(pos[1]) > 8 || Convert.ToInt32(pos[1]) < 1 || !"abcdefgh".Contains(pos[0]))
                throw new ArgumentException();
            x = "abcdefgh".IndexOf(pos[0]);

            y = Convert.ToInt32(pos[1]) - 1;
        }

        static void FromIntToText(int x, int y, out string pos)
        {
            if(x < 0 || x > 7 || y < 0 || y > 7)
                throw new ArgumentException();
            pos = "abcdefgh"[x] + (y + 1).ToString();
        }
    }
}

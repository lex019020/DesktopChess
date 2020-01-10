using System;
using System.Linq;

namespace DesktopChess
{
    class Position
    {
        private string pos;

        public Position(int x, int y)
        {
            FromIntToText(x, y, out pos);
        }

        public Position(string pos)
        {
            this.pos = pos;
        }

        /// <summary>
        /// Get a string position
        /// </summary>
        /// <returns></returns>
        public string GetPos() => pos;

        public static void FromTextToInt(string pos, out int x, out int y)
        {
            if(pos.Length != 2)
                throw new ArgumentException();
            if(Convert.ToInt32(pos[1]) > 8 || Convert.ToInt32(pos[1]) < 1 || !"abcdefgh".Contains(pos[0]))
                throw new ArgumentException();
            x = "abcdefgh".IndexOf(pos[0]);

            y = Convert.ToInt32(pos[1]) - 1;
        }

        public static void FromIntToText(int x, int y, out string pos)
        {
            if(x < 0 || x > 7 || y < 0 || y > 7)
                throw new ArgumentException();
            pos = "abcdefgh"[x] + (y + 1).ToString();
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (!(obj is Position pos2)) return false;
            return pos2.pos == pos;
        }
    }
}

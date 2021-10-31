using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame
{
    class GameRules
    {
        public static int[,] GenerateRules(int[,] arr)
        {
            var final = arr;
            for (int x = 0; x < arr.GetLength(1); x++)
            {
                for (int y = x; y < arr.GetLength(0); y++)
                {
                    if (x == y) { final[x, y] = 0; continue; }
                    if (x % 2 == 0)
                    {
                        final[x, y] = -1 * (int)Math.Pow(-1, y);
                        final[y, x] = (int)Math.Pow(-1, y);
                    }
                    else
                    {
                        final[x, y] = (int)Math.Pow(-1, y);
                        final[y, x] = -1 * (int)Math.Pow(-1, y);
                    }

                }
            }
            return final;
        }
    }
}

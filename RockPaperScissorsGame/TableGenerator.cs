using ConsoleTables;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame
{
    class TableGenerator
    {
        public static ConsoleTable GenerateHelp(int[,] arr, string[] args)
        {

            var arg = args.ToList();
            arg.Insert(0, "PC/User");
            ConsoleTable table = new ConsoleTable(arg.ToArray());
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                var a = ConvertArray(arr.SliceRow(i).Select(x => x.ToString()).ToArray()).ToList();
                a.Insert(0, args[i]);
                table.AddRow(a.ToArray());
            }
            return table;
        }
        private static string[] ConvertArray(string[] input)
        {
            for (int i = 0; i < input.Length; i++)
            {
                input[i] = Enum.GetName(typeof(HelpMessageEnum), Convert.ToInt32(input[i]));

            }
            return input;
        }

        public enum HelpMessageEnum
        {
            Lose = -1,
            Draw,
            Win
        }
    }
}

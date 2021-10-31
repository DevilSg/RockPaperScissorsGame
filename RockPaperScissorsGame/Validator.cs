using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame
{
    class Validator
    {
        public bool Validate(string[] args)
        {
            return !(args.Length % 2 == 0) && args.Length > 2 && !args.GroupBy(element => element).Any(duplicate => duplicate.Count() > 1);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace RockPaperScissorsGame
{
    class Game
    {
        private string[] arguments;
        public int[,] gamerules { get; private set; }
        public string Winner { get; private set; }

        public Game(string[] arguments)
        {
            this.arguments = arguments;
            this.gamerules = GameRules.GenerateRules(new int[arguments.Length, arguments.Length]);
        }
        public int GenerateMove()
        {
            return RNGCryptoServiceProvider.GetInt32(arguments.Length);
        }
        private int DecideWinner(int usermove, int computermove)
        {
            return gamerules[computermove, usermove];
        }
        public string MakeMove(int move, int pcmove)
        {
            return $"PC move: {arguments[pcmove]}{Environment.NewLine}Your move: {arguments[move - 1]}{Environment.NewLine}{FinishGame(DecideWinner(move - 1, pcmove))}";
        }
        private string FinishGame(int result)
        {
            switch (result)
            {
                case -1: return "You lose.";
                case 0: return "Draw.";
            }
            return "Congratulations! You win!";
        }
    }
}

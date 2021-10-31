using System;

namespace RockPaperScissorsGame
{
    class Program
    {
        static void Main(string[] args)
        {
            KeyGenerator keyGenerator = new KeyGenerator();
            Validator validator = new Validator();
            Message message = new Message();
            if (validator.Validate(args))
            {
                var a = validator.Validate(args);
                Console.WriteLine(message.StartMessage(args));
                while (true)
                {
                    var key = keyGenerator.GenerateKey();
                    Game game = new Game(args);
                    var pcmove = game.GenerateMove();
                    Console.WriteLine("\n"+$"HMAC: {keyGenerator.GenerateHMAC(args[pcmove], key)}");
                    Console.WriteLine("Chose your option: ");
                    var input = Console.ReadLine();
                    switch (input)
                    {
                        case "0": Environment.Exit(0); break;
                        case "?": message.HelpMessage(game.gamerules, args).Write(); break;

                    }
                    int choice;
                    if (Int32.TryParse(input, out choice))
                    {
                        Console.WriteLine(game.MakeMove(choice, pcmove));
                        Console.WriteLine($"HMAC key is: {key}");
                            
                    }
                    else if (input != "?")
                    {
                        Console.WriteLine(message.ErrorMessage());
                    }

                }
            }
            else
            {
                Console.WriteLine(message.ErrorMessage());
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using test.IGameRepo;
using test.Services;

namespace test
{
    internal class Game
    {
        private readonly List<string> moves;
        private readonly IGameRules rules;
        private readonly IHelpTable helpTable;
        private readonly ICryptoServicesProvider cryptoServices;
        private readonly Random random;

        public Game(List<string> Moves,IGameRules gameRules,IHelpTable helpTable,ICryptoServicesProvider cryptoServices)
        {
            this.moves = Moves;
            this.rules = gameRules;
            this.helpTable = helpTable;
            this.cryptoServices = cryptoServices;
            this.random = new Random();
        }

        public void Start()
        {
            byte[] key = cryptoServices.GenerateKey();
            string keyHex = BitConverter.ToString(key).Replace("-", "").ToLower();
            string computerMove = moves[random.Next(moves.Count)];
            string hmac = cryptoServices.CalculateHMAC(computerMove, key);

            Console.WriteLine("HMAC: " + hmac);

            Console.WriteLine("Available Moves: ");
            for (int i = 0; i < moves.Count; i++)
            {
                Console.WriteLine(i + 1 + ". " + moves[i]);
            }


            Console.WriteLine("0 - exit");
            Console.WriteLine("? - help");

            while (true)
            {
                Console.Write("Enter your move: ");
                string input = Console.ReadLine();

                if (input == "0")
                {
                    Console.WriteLine("Exiting...");
                    break;
                }
                else if (input == "?")
                {
                    helpTable.DisplayHelpTable();
                }
                else
                {
                    if (int.TryParse(input, out int userMoveIndex) && userMoveIndex > 0 && userMoveIndex <= moves.Count)
                    {
                        string userMove = moves[userMoveIndex - 1];
                        Console.WriteLine("Your move: " + userMove);
                        Console.WriteLine("Computer move: " + computerMove);
                        Console.WriteLine(rules.GetWinner(userMove, computerMove));
                        Console.WriteLine("HMAC key: " + keyHex);
                        break;
                    }
                    else
                    {
                        Console.WriteLine("Invalid move. Try again.");
                    }
                }
            }
        }
    }
}
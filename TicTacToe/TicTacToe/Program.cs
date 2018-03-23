using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tic Tac Toe");
        }

        static void GetPlayerOneInfo()
        {
            Console.WriteLine("Player 1 what is your name?");
            string player1 = Console.ReadLine();
            Console.WriteLine("Select your marker.");
            string marker = Console.ReadLine();
            Player player = CreatePlayer1(player1, marker);
            Console.WriteLine("Player 2 what is your name?");
            string player2 = Console.ReadLine();
            GetPlayerTwoMarker(player, marker, player2);
        }

        static void GetPlayerTwoMarker(Player player1, string marker, string player)
        {
            Console.WriteLine("Select your marker.");
            string marker2 = Console.ReadLine();
            if (marker2 == marker)
            {
                Console.WriteLine("Please select a different marker.");
                GetPlayerTwoMarker(player1, marker, player);
            }
            Player player2 = CreatePlayer2(player, marker2);
        }

        static Player CreatePlayer1(string name, string marker)
        { 
            Player player1 = new Player(name, marker);
            return player1;
        }

        static Player CreatePlayer2(string name, string marker)
        {
            Player player2 = new Player(name, marker);
            return player2;
            
        }
    }
}

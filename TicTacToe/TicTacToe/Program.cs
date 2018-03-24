using System;

namespace TicTacToe
{
    public class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Tic Tac Toe");
            GetPlayerInfo();
            
        }

        /// <summary>
        /// gets player 1 and player 2 names, passes the names to StartGame
        /// </summary>
        static void GetPlayerInfo()
        {
            Console.WriteLine("Player 1 what is your name?");
            string player1 = Console.ReadLine();
            Player player = CreatePlayer1(player1, "|X|");
            Console.WriteLine("Player 2 what is your name?");
            string player2 = Console.ReadLine();
            Player second = CreatePlayer2(player2, "|O|");
            StartGame(player, second);
        }

        /// <summary>
        /// creates a instance of the Player class with player 1's inputted
        /// name, and X as their marker
        /// </summary>
        /// <param name="name">string type of player name</param>
        /// <param name="marker">string type of player marker</param>
        /// <returns>a Player object</returns>
        static Player CreatePlayer1(string name, string marker)
        { 
            Player player1 = new Player(name, marker);
            return player1;
        }

        /// <summary>
        /// creates a instance of the Player class with player 2's inputted
        /// name, and O as their marker
        /// </summary>
        /// <param name="name">string type of player name</param>
        /// <param name="marker">string type of player marker</param>
        /// <returns>a Player object</returns>
        static Player CreatePlayer2(string name, string marker)
        {
            Player player2 = new Player(name, marker);
            return player2;
            
        }

        /// <summary>
        /// creates an instance of TheBoard class
        /// </summary>
        /// <returns>a TheBoard object</returns>
        static string[,] CreateBoard()
        {
            TheBoard board = new TheBoard();
            /// creating 3x3 game board matrix
            string[,] gameBoard = new string[,] { { board.Pos1, board.Pos2, board.Pos3 },
                { board.Pos4, board.Pos5, board.Pos6 },
                { board.Pos7, board.Pos8, board.Pos9 } };
            return gameBoard;
        }

        /// <summary>
        /// takes the matrix from TheBoard object and displays it in console
        /// </summary>
        /// <param name="board">a string[,] type of the current board state</param>
        static void DisplayBoard(string[,] board)
        {
            //goes through the outer array
            for (int i = 0; i < 3; i++)
            {
                //goes through inner array
                for (int j = 0; j < 3; j++)
                {
                    Console.Write(string.Format("{0} ", board[i, j]));
                }
                Console.WriteLine(Environment.NewLine);
            }

        }

        /// <summary>
        /// starts a new cycle of the game, creates a counter to track
        /// number of plays made, passes player objects and counter
        /// to the PlayerOneTurn method
        /// </summary>
        /// <param name="player1">Player object</param>
        /// <param name="player2">Player object</param>
        static void StartGame(Player player1, Player player2)
        {
            string[,] board = CreateBoard();
            DisplayBoard(board);
            // Used to end the game in case of draw
            byte counter = 0;
            PlayerOneTurn(board, player1, player2, counter);
        }

        /// <summary>
        /// handles everytime it is player 1's turn. Reads the players selection
        /// calls method to check if selection is available, calls method to update the
        /// board, increments the counter by 1, calls method to check for winner/draw,
        /// calls the playertwo method
        /// </summary>
        /// <param name="board">string[,] type of thecurrent board state</param>
        /// <param name="player1">Player object</param>
        /// <param name="player2">Player object</param>
        /// <param name="counter">byte type of the current amount of selections made</param>
        static void PlayerOneTurn(string[,] board, Player player1, Player player2, byte counter)
        {
            Console.WriteLine($"{player1.Name} it is your turn. Please choose a location.");
            string choice = Console.ReadLine();
            string selection = "|" + choice + "|";
            bool check = CheckIfSpaceOpen(selection, board);
            //if check is true, means the space is available
            //if check is false, means space is occupied
            if (check == false)
            {
                PlayerOneTurn(board, player1, player2, counter);
            }
            board = UpdateBoard(selection, board, player1);
            counter++;
            CheckForWinner(board, player1, player2, counter);
            PlayerTwoTurn(board, player1, player2, counter);
        }

        /// <summary>
        /// handles everytime it is player 2's turn. Reads the players selection
        /// calls method to check if selection is available, calls method to update the
        /// board, increments the counter by 1, calls method to check for winner/draw,
        /// calls the playerone method
        /// </summary>
        /// <param name="board">string[,] type of thecurrent board state</param>
        /// <param name="player1">Player object</param>
        /// <param name="player2">Player object</param>
        /// <param name="counter">byte type of the current amount of selections made</param>
        static void PlayerTwoTurn(string[,] board, Player player1, Player player2, byte counter)
        {
            Console.WriteLine($"{player2.Name} it is your turn. Please choose a location.");
            string choice = Console.ReadLine();
            string selection = "|" + choice + "|";
            bool check = CheckIfSpaceOpen(selection, board);
            //if check is true, means the space is available
            //if check is false, means space is occupied
            if (check == false)
            {
                PlayerTwoTurn(board, player1, player2, counter);
            }
            board = UpdateBoard(selection, board, player2);
            counter++;
            CheckForWinner(board, player2, player1, counter);
            PlayerOneTurn(board, player1, player2, counter);
        }

        /// <summary>
        /// checks if the space the user selected is available to play
        /// </summary>
        /// <param name="selection">string type of the selected space</param>
        /// <param name="board">string[,] type of current game state</param>
        /// <returns>bool type</returns>
        static bool CheckIfSpaceOpen(string selection, string[,] board)
        {
            bool check = false;
            // arrays to pass current row values into
            string[] rowOne = new string[3];
            string[] rowTwo = new string[3];
            string[] rowThree = new string[3];
            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    //puts all of the top row into rowOne
                    if (i == 0)
                    {
                        rowOne[j] = board[i, j];
                    }
                    //puts all of the middle row into rowTwo
                    if (i == 1)
                    {
                        rowTwo[j] = board[i, j];
                    }
                    //puts all of the bottom row into rowThree
                    if (i == 2)
                    {
                        rowThree[j] = board[i, j];
                    }
                }
            }
            // checking to see if any of the new arrays have the users selection
            // in them. If the selection is there, its index will be returned, which
            // will be reater than 0, so then the check is set to true
            if (Array.IndexOf(rowOne, selection) >= 0)
            {
                check = true;
            }
            if (Array.IndexOf(rowTwo, selection) >= 0)
            {
                check = true;
            }
            if (Array.IndexOf(rowThree, selection) >= 0)
            {
                check = true;
            }

            return check;
            
        }

        /// <summary>
        /// updates the current board state with users selection
        /// </summary>
        /// <param name="selection">string type of the users selection</param>
        /// <param name="board">string[,] type of current board state</param>
        /// <param name="player">Player object of the current player</param>
        /// <returns>string[,] type of new board state</returns>
        static string[,] UpdateBoard(string selection, string[,] board, Player player)
        {
            Console.Clear();

            for (int i = 0; i < 3; i++)
            {
                for (int j = 0; j < 3; j++)
                {
                    if (board[i,j] == selection)
                    {
                        board[i, j] = player.Mark;
                    }
                }
            }
            
            DisplayBoard(board);
            return board;
        }

        /// <summary>
        /// checks the current board state to see if there is 3 in a row horizontally,
        /// vertically or diagonally. It also checks if the counter is at 9 after checking
        /// for a winner. Then prompts the players if they want to play again and calls
        /// on the EndOfGame method.
        /// </summary>
        /// <param name="board">string[,] type of current board state</param>
        /// <param name="player">Player object of current/winning player</param>
        /// <param name="loser">Player object of losing player</param>
        /// <param name="counter">byte type of the current number of plays</param>
        static void CheckForWinner(string[,] board, Player player, Player loser, byte counter )
        {
            for (int i = 0; i < 3; i++)
            {
                //checks for horizontal winner
                if (board[i,0] == board[i, 1] && board[i,0] == board[i,2])
                {
                    Console.WriteLine($"{player.Name} Wins!!! Do you want to play again?");
                    string answer = Console.ReadLine().ToUpper();
                    EndOfGame(answer, player, loser);
                }
                //checks for vertical winner
                if (board[0, i] == board[1,i] && board[0, i] == board[2, i])
                {
                    Console.WriteLine($"{player.Name} Wins!!! Do you want to play again?");
                    string answer = Console.ReadLine().ToUpper();
                    EndOfGame(answer, player, loser);
                }

            }
            //check for diagonal winner
            if (board[0,0] == board[1,1] && board[0,0] == board[2,2])
            {
                Console.WriteLine($"{player.Name} Wins!!! Do you want to play again?");
                string answer = Console.ReadLine().ToUpper();
                EndOfGame(answer, player, loser);
            }

            if (board[2,0] == board[1,1] && board[2,0] == board[0,2])
            {
                Console.WriteLine($"{player.Name} Wins!!! Do you want to play again?");
                string answer = Console.ReadLine().ToUpper();
                EndOfGame(answer, player, loser);
            }
            // check for a draw
            if (counter == 9)
            {
                Console.WriteLine("It is a draw!");
                string answer = Console.ReadLine().ToUpper();
                EndOfGame(answer, player, loser);
            }

        }

        /// <summary>
        /// handles if the players want to play again or not.
        /// </summary>
        /// <param name="answer">string type of whether or not users want to play again</param>
        /// <param name="player1">Player object</param>
        /// <param name="player2">Player object</param>
        static void EndOfGame(string answer, Player player1, Player player2)
        {
            if (answer == "Y" || answer == "YES")
            {
                Console.WriteLine($"{player1.Name} goes first.");
                StartGame(player1, player2);
            }
            else if (answer == "N" || answer == "NO")
            {
                Console.WriteLine("Thanks for playing! Press any key to exit.");
                Console.ReadKey();
                Environment.Exit(0);
            }
            else
            {
                Console.WriteLine("I will take that as a no...");
                Environment.Exit(0);
            }

        }

    }
}

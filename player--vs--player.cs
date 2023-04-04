using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[3, 3]; // create 2D array to represent game board
            char player = 'X'; // start with X player
            bool gameover = false; // set gameover to false initially

            // initialize the game board with spaces
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }

            // loop until the game is over
            while (!gameover)
            {
                // print the game board
                Console.WriteLine("  0 1 2");
                for (int row = 0; row < 3; row++)
                {
                    Console.Write(row + " ");
                    for (int col = 0; col < 3; col++)
                    {
                        Console.Write(board[row, col] + " ");
                    }
                    Console.WriteLine();
                }

                // get input from the current player
                Console.WriteLine("It's " + player + "'s turn.");
                Console.Write("Enter row: ");
                int rowInput = int.Parse(Console.ReadLine());
                Console.Write("Enter column: ");
                int colInput = int.Parse(Console.ReadLine());

                // validate input
                if (rowInput < 0 || rowInput > 2 || colInput < 0 || colInput > 2)
                {
                    Console.WriteLine("Invalid input. Please try again.");
                    continue;
                }
                if (board[rowInput, colInput] != ' ')
                {
                    Console.WriteLine("That spot is already taken. Please try again.");
                    continue;
                }

                // update the game board with the player's move
                board[rowInput, colInput] = player;

                // check if the game is over
                if (CheckWin(board, player))
                {
                    Console.WriteLine(player + " wins!");
                    gameover = true;
                }
                else if (CheckTie(board))
                {
                    Console.WriteLine("Tie game!");
                    gameover = true;
                }

                // switch to the other player
                if (player == 'X')
                {
                    player = 'O';
                }
                else
                {
                    player = 'X';
                }
            }
        }

        // check if the specified player has won the game
        static bool CheckWin(char[,] board, char player)
        {
            // check rows
            for (int row = 0; row < 3; row++)
            {
                if (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player)
                {
                    return true;
                }
            }

            // check columns
            for (int col = 0; col < 3; col++)
            {
                if (board[0, col] == player && board[1, col] == player && board[2, col] == player)
                {
                    return true;
                }
            }

            // check diagonals
            if (board[0, 0] == player && board[1, 1] == player && board[2, 2] == player)
            {
                return true;
            }
            if (board[0, 2] == player && board[1, 1] == player && board[2, 0] == player)
            {
                return true;
            }

            // if none of the above
            // player has not won
            return false;
        }

        // check if the game is a tie
        static bool CheckTie(char[,] board)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == ' ')
                    {
                        // found an empty spot, game is not over
                        return false;
                    }
                }
            }

            // game board is full and no player has won, game is a tie
            return true;
        }
    }
}

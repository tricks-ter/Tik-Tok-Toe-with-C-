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
            int turns = 0; // initialize turn counter

            // initialize the game board with spaces
            ResetBoard(board);

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

                turns++; // increment turn counter
                Console.WriteLine("Number of turns: " + turns);

                // check if maximum number of turns have been reached
                if (turns == 9)
                {
                    Console.WriteLine("Maximum number of turns reached.");
                    gameover = true;
                }

                // check if game is over and prompt user to play again or reset board
                if (gameover)
                {
                    Console.Write("Play again? (Y/N): ");
                    string playAgainInput = Console.ReadLine().ToUpper();
                    if (playAgainInput == "Y")
                    {
                        // reset game board and turn counter
                        ResetBoard(board);
                        turns = 0;
                        // reset player to X for a new game
                        player = 'X';
                        // set gameover to false to start a new game
                        gameover = false;
                    }
                    else
                    {
                        Console.WriteLine("Thanks for playing!");
                    }
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

            return false;
        }

        static bool CheckTie(char[,] board)
        {
            // check if every spot on the board is filled
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == ' ')
                    {
                        // if any spot is empty, the game is not a tie
                        return false;
                    }
                }
            }

            // if every spot is filled and no win condition was met, the game is a tie
            return true;
        }

        // reset the game board with empty spaces
        static void ResetBoard(char[,] board)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    board[row, col] = ' ';
                }
            }
        }
    }
}

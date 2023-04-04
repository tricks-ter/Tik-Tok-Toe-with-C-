using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            char[,] board = new char[3, 3]; // create 2D array to represent game board
            char humanPlayer = 'X'; // human player is always X
            char computerPlayer = 'O'; // computer player is always O
            bool gameover = false; // set gameover to false initially
            bool isHumanTurn = true; // set the human player's turn to true initially

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
                if (isHumanTurn)
                {
                    Console.WriteLine("It's your turn.");
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

                    // update the game board with the human player's move
                    board[rowInput, colInput] = humanPlayer;
                }
                else
                {
                    Console.WriteLine("It's the computer's turn.");
                    // simulate the computer's move by choosing a random empty spot on the board
                    Random random = new Random();
                    int rowInput = random.Next(3);
                    int colInput = random.Next(3);
                    while (board[rowInput, colInput] != ' ')
                    {
                        rowInput = random.Next(3);
                        colInput = random.Next(3);
                    }

                    Console.WriteLine("Computer chooses row " + rowInput + " column " + colInput);
                    // update the game board with the computer's move
                    board[rowInput, colInput] = computerPlayer;
                }

                // check if the game is over
                if (CheckWin(board, isHumanTurn ? humanPlayer : computerPlayer))
                {
                    Console.WriteLine(isHumanTurn ? "You win!" : "Computer wins!");
                    gameover = true;
                }
                else if (CheckTie(board))
                {
                    Console.WriteLine("Tie game!");
                    gameover = true;
                }

                // switch to the other player
                isHumanTurn = !isHumanTurn;
            }
        }

        // check if the specified player has won the game
        static bool CheckWin(char[,] board, char player)
        {
            // check rows
            for (int row = 0; row < 3; row++)
            {
                // check if all spots in the row are the same player
                if (board[row, 0] == player && board[row, 1] == player && board[row, 2] == player)
                {
                    return true;
                }
            }
            // check columns
            for (int col = 0; col < 3; col++)
            {
                // check if all spots in the column are the same player
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

            // no winning combination found
            return false;
        }

        // check if the game is tied (i.e. no empty spots left on the board)
        static bool CheckTie(char[,] board)
        {
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (board[row, col] == ' ')
                    {
                        return false;
                    }
                }
            }
            return true;
        }
    }
}






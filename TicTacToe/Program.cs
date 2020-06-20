using System;

namespace TicTacToe
{
    class MainClass
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Welcome to TicTacToe");

            var player1 = new Player(1);
            var player2 = new Player(2);
            var board = new Board();

            bool gameOver = false;

            board.PrintBoard();

            do
            {
                Console.WriteLine("Player 1 Move");
                player1.IsWinner = board.TakeTurn(player1.ID);
                gameOver = player1.IsWinner || board.IsDraw;
                board.PrintBoard();

                if (!gameOver)
                {
                    Console.WriteLine("Player 2 Move");
                    player1.IsWinner = board.TakeTurn(player2.ID);
                    gameOver = player2.IsWinner || board.IsDraw;
                    board.PrintBoard();
                }
            } while (!gameOver);

            if(board.IsDraw)
            {
                Console.WriteLine("It's a Draw!");
            }
            else
            {
                if(player1.IsWinner)
                {
                    Console.WriteLine("Player {0} wins!", player1.ID);
                }
                if (player2.IsWinner)
                {
                    Console.WriteLine("Player {0} wins!", player2.ID);
                }
            }
            board.PrintBoard();
            Console.WriteLine("Press any key to exit.");
            Console.ReadKey();
        }
    }
}

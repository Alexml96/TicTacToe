using System;
namespace TicTacToe
{
    public class Board
    {
        // Auto-implemented readonly property:
        public int[,] Box { get; set; }
        public bool IsDraw { get; set; }


        private int turnCount;
        private bool hasRow;
        private bool isFull;
        

        // Constructor that takes no arguments:
        public Board()
        {
            Box = new int[3, 3];
            IsDraw = false;

            turnCount = 0;
            hasRow = false;
            isFull = false;
        }

        // Constructor that takes one argument:
        public Board(int[,] box)
        {
            Box = box;
        }

        private bool BoxIsEmpty(int[] box)
        {
            if(Box[box[0],box[1]] == 0)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        
        //method to take turn
        public bool TakeTurn(int player)
        {
            int[] playerTurn;

            playerTurn = GetPlayerInput(player);

            Box[playerTurn[0], playerTurn[1]] = player;

            turnCount++;

            if(turnCount >= 9)
            {
                isFull = true;
            }

            hasRow = CheckForRow();
            IsDraw = CheckForDraw();


            return hasRow;
        }

        private int[] GetPlayerInput(int player)
        {
            string playerInput;
            bool isValid = false;
            bool isEmpty = false;
            int[] playerTurn = new int[2];

            Console.WriteLine("Player {0}, choose your next move.", player);
            while (!isValid || !isEmpty)
            {
                Console.Write("Input: ");
                playerInput = Console.ReadLine();
                playerInput.ToUpper();
                playerInput.Trim();

                switch (playerInput)//.Trim().ToUpper())
                {
                    case "TOP LEFT":
                    case "TL":
                        playerTurn = new int[] { 0, 0 };
                        isValid = true;
                        break;

                    case "TOP MIDDLE":
                    case "TM":
                        playerTurn = new int[] { 0, 1 };
                        isValid = true;
                        break;

                    case "TOP RIGHT":
                    case "TR":
                        playerTurn = new int[] { 0, 2 };
                        isValid = true;
                        break;

                    case "MIDDLE LEFT":
                    case "ML":
                        playerTurn = new int[] { 1, 0 };
                        isValid = true;
                        break;

                    case "MIDDLE":
                    case "M":
                        playerTurn = new int[] { 1, 1 };
                        isValid = true;
                        break;

                    case "MIDDLE RIGHT":
                    case "MR":
                        playerTurn = new int[] { 1, 2 };
                        isValid = true;
                        break;

                    case "BOTTOM LEFT":
                    case "BL":
                        playerTurn = new int[] { 2, 0 };
                        isValid = true;
                        break;

                    case "BOTTOM MIDDLE":
                    case "BM":
                        playerTurn = new int[] { 2, 1 };
                        isValid = true;
                        break;

                    case "BOTTOM RIGHT":
                    case "BR":
                        playerTurn = new int[] { 2, 2 };
                        isValid = true;
                        break;

                    case "HELP":
                    case "H":
                        Console.WriteLine("Acceptable moves are:");
                        Console.WriteLine("TL, TM, TR, ML, M, MR, BL, BM, BR");
                        isValid = false;
                        break;

                    default:
                        Console.WriteLine("Please enter a valid move");
                        isValid = false;
                        break;
                }
                isEmpty = BoxIsEmpty(playerTurn);
                if(!isEmpty)
                {
                    Console.WriteLine("Please Select and Empty Space.");
                }
            }
            return playerTurn;
        }


        //method to check for three in a row
        private bool CheckForRow()
        {
            //All Possible Wins
            //Top Row
            if(Box[0,0] == Box[0, 1] && Box[0, 1] == Box[0, 2] && Box[0,0] != 0)
            {
                hasRow = true;
            }
            //Middle Row
            if (Box[1, 0] == Box[1, 1] && Box[1, 1] == Box[1, 2] && Box[1, 0] != 0)
            {
                hasRow = true;
            }
            //Bottom Row
            if (Box[2, 0] == Box[2, 1] && Box[2, 1] == Box[2, 2] && Box[2, 0] != 0)
            {
                hasRow = true;
            }
            //Positive Diagonal
            if (Box[2, 0] == Box[1, 1] && Box[1, 1] == Box[0, 2] && Box[2, 0] != 0)
            {
                hasRow = true;
            }
            //Negative Diagonal
            if (Box[0, 0] == Box[1, 1] && Box[1, 1] == Box[2, 2] && Box[0, 0] != 0)
            {
                hasRow = true;
            }
            //Left Col
            if (Box[0, 0] == Box[1, 0] && Box[1, 0] == Box[2, 0] && Box[0, 0] != 0)
            {
                hasRow = true;
            }
            //Middle Col
            if (Box[0, 1] == Box[1, 1] && Box[1, 1] == Box[2, 1] && Box[0, 1] != 0)
            {
                hasRow = true;
            }
            //Right Col
            if (Box[0, 2] == Box[1, 2] && Box[1, 2] == Box[2, 2] && Box[0, 2] != 0)
            {
                hasRow = true;
            }

            return hasRow;
        }

        //method to check for a draw
        private bool CheckForDraw()
        {
            if (!hasRow && isFull)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public void PrintBoard()
        {
            int i, j;
            Console.WriteLine("");

            for(i = 0; i < 3; i++)
            {
                for(j = 0; j < 3; j++)
                {
                    switch (Box[i,j])
                    {
                        case 1:
                            Console.Write("X");
                            break;
                        case 2:
                            Console.Write("O");
                            break;
                        default:
                            Console.Write(" ");
                            break;
                    }
                    if(j <2)
                    {
                        Console.Write("|");
                    }
                    else
                    {
                        Console.WriteLine("");
                    }
                }
                if (i < 2)
                {
                    Console.WriteLine("-----");
                }
            }
            Console.WriteLine("");
        }

    }
}
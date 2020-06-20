using System;
namespace TicTacToe
{
    public class Player
    {
        public int ID { get; set; }
        public bool IsWinner { get; set; }

        public Player(int id)
        {
            ID = id;
            IsWinner = false;
        }
    }
}

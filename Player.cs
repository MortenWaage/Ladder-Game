using System;

namespace LadderGame
{
    public class Player
    {
        public int ID { get; }
        public int Position { get; private set; }

        public Player(int id, int boardSize)
        {
            ID = id;
            Position = boardSize - 1;
        }
        public void Move(int distance)
        {
            Position -= distance;
            if (Position < 0) Position = Game.BoardSize - Math.Abs(Position);
        }

        public void UseLadder(int? position = null)
        {
            Position = Game.BoardSize - position ?? Position;
        }
    }
}


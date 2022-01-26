using System;

namespace LadderGame
{
    class Cell
    {
        public bool[] Occupied = { false, false };
        public bool HasLadder;
        public int? LadderEnd = null;
        public ConsoleColor Color = BoardData.Default;
        public int ID;
    }
}

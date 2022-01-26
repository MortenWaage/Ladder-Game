using System;

namespace LadderGame
{
    public static class LadderData
    {
        public static ConsoleColor GetColorFromIndex(int index)
        {
            return index switch
            {
                40 or 1  => BoardData.LadderDown,
                5  or 24 => BoardData.LadderUp,
                64 or 50 => BoardData.LadderDown,
                72 or 82 => BoardData.LadderUp,
                _        => BoardData.Default
            };
        }

        public static int? LadderFromIndex(int index)
        {
            return index switch
            {
                40 => 1,
                5  => 24,
                72 => 82,
                _  => null
            };
        }
    }
}


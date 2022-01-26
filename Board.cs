using System;

namespace LadderGame
{
    class Board
    {
        private readonly int _width;
        private readonly int _height;
        private readonly int _size;
        public Cell[] BoardCells { get; }

        public Board(int width, int height)
        {
            _size = (_width = width) * (_height = height);
            BoardCells = new Cell[width * height];
        }

        public void Generate()
        {
            for (var i = 0; i < _size; i++)
            {
                BoardCells[i] = GenerateCell(_size - i);
            }

            Cell GenerateCell(int index)
            {
                var ladder = LadderData.LadderFromIndex(index);
                return new Cell() {
                    ID = index,
                    LadderEnd = ladder,
                    HasLadder = ladder != null,
                    Color = LadderData.GetColorFromIndex(index),
                };
            }
        }
        public void Draw()
        {
            const int CELL_SIZE = 4;

            for (int y = 0, i = 0; y < _height;)
            {
                for (var x = 0; x < _width; x++, i++)
                {
                    DrawCell(i, x, y);
                }
                y++;
                i += _width - 1;
                for (var x = _width - 1; x >= 0; x--, i--)
                {
                    DrawCell(i, (_width - 1) - x, y);
                }
                i += _width + 1;
                y++;
            }

            void DrawCell(int index, int x, int y)
            {
                if (BoardCells[index] == null) return;

                Console.BackgroundColor = BoardCells[index].Color;

                foreach (var player in Game.Players)
                {
                    DrawPlayer(player.ID);
                }
                DrawCellData();
                
                void DrawPlayer(int player)
                {
                    var playerInCell = BoardCells[index].Occupied[player];
                    var cellSymbol = playerInCell
                        ? player == 0 ? "X" : "O"
                        : " ";

                    Console.SetCursorPosition(x * CELL_SIZE + player, y);
                    Console.ForegroundColor = playerInCell
                        ? player == 0 ? BoardData.PlayerOne : BoardData.PlayerTwo
                        : ConsoleColor.Black;
                    Console.Write(cellSymbol);
                }

                void DrawCellData()
                {
                    Console.ForegroundColor = BoardData.TextColor;
                    Console.WriteLine($"{BoardCells[index].ID}");
                }
            }
        }
    }
}

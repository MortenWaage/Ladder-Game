using System;
using System.Threading;

namespace LadderGame
{
    class GameController
    {
        private bool _gameRunning = true;
        private readonly int _width;
        private readonly int _height;
        private readonly Board _board;
        private Player[] _players;

        public Player[] Players => _players;

        public GameController(int width, int height)
        {
            _width = width; _height = height;
            _board = new Board(width, height);
        }
        public void Play()
        {
            _players = new Player[]
            {
                new Player(0, _width * _height),
                new Player(1, _width * _height),
            };

            _board.Generate();
            _board.Draw();

            while (_gameRunning)
            {
                Thread.Sleep(2000);
                //-- I stedet for å vente kan du heller bruke Console.ReadLine() for å lese input fra spillerene.
                //-- Når spilleren for eksempel skriver "roll" kan du bruke Game.DiceRoll() for å rulle en terning, og så flytte den relevante spilleren
                //-- ved hjelp av MovePlayer-metoden som som i foreach-loopen under.
                //-- Du kan også sette _gameRunning til false når en av spillerene når slutten av spille brettet om dette er ønskelig.

                foreach (var player in Game.Players)
                {
                    var distance = Game.DiceRoll();
                    MovePlayer(player.ID, distance);
                }
            }
        }
        private void MovePlayer(int playerId, int distance)
        {
            var usedLadder = false;
            var player = _players[playerId];

            var oldPlayerPosition = GetPlayerPosition();
            MovePlayer();
            ClimbIfLadder();
            DrawPlayer();
            LogPlayer();

            #region Local Methods
            void MovePlayer()
            {
                _board.BoardCells[player.Position].Occupied[player.ID] = false;
                player.Move(distance);
            }
            void ClimbIfLadder()
            {
                if (!_board.BoardCells[player.Position].HasLadder) return;
                var ladderEnd = _board.BoardCells[player.Position].LadderEnd;
                player.UseLadder(ladderEnd);
                usedLadder = true;
            }
            void DrawPlayer()
            {
                _board.BoardCells[player.Position].Occupied[player.ID] = true;
                _board.Draw();
            }
            void LogPlayer()
            {
                var newCell = GetPlayerPosition();
                Console.ForegroundColor = BoardData.LogColor;
                Console.SetCursorPosition(0, BoardData.HEIGHT + 5 + player.ID);
                Console.WriteLine($"Moved Player {player.ID + 1} from {oldPlayerPosition} to {newCell}. Total Distance moved is {distance}");

                Console.SetCursorPosition(0, BoardData.HEIGHT + 7 + player.ID);
                Console.WriteLine((usedLadder ? $"Player {player.ID + 1 } used Ladder" : "                                "));
            }
            string GetPlayerPosition()
            {
                return (_board.BoardCells.Length - player.Position).ToString();
            }
            #endregion
        } 
    }
}

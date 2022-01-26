using System;

namespace LadderGame
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.CursorVisible = false;
            GameManager.Instance = new GameManager
            {
                Dice = new Dice(),
                GameController = new GameController(BoardData.WIDTH, BoardData.HEIGHT),
            };

            Game.Play();
        }
    }
}

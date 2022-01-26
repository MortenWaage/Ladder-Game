using System.Collections.Generic;

namespace LadderGame
{
    public static class Game
    {
        public static int BoardSize => BoardData.WIDTH * BoardData.HEIGHT;
        public static void Play()
        {
            if (GameManager.Instance == null) return;
            GameManager.Instance.GameController.Play();
        }

        public static int DiceRoll()
        {
            return GameManager.Instance == null ? 0 : GameManager.Instance.Dice.Roll();
        }

        public static IEnumerable<Player> Players => GameManager.Instance.Players;
    }
}

namespace LadderGame
{
    class GameManager
    {
        public static GameManager Instance { get; set; }
        public GameController GameController { get; set; }
        public Dice Dice { get; set; }
        public Player[] Players => GameController.Players;
    }
}

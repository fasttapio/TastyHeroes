using System;

namespace EventsHelpers{
    public enum UIEvents
    {
        MainMenu = 10,
        Shop = 20,
        StartGame = 30
    }

    public enum GameStateEvents
    {
        ChangeGameState = 10,
        Shop = 20,
        StartGame = 30
    }




    public class ChangeIntEventArgs : EventArgs
    {
        public int Value { get; set; }
        public ChangeIntEventArgs(int value)
        {
            this.Value = value;
        }
    }

    
    /*
    public class ChangeCurrencyEventArgs : EventArgs
    {
        public Currency Currency { get; set; }
        public int Value { get; set; }
        public ChangeCurrencyEventArgs(Currency currency, int value)
        {
            this.Currency = currency;
            this.Value = value;
        }
    }

    
    public class ChangeGameStateEventArgs : EventArgs
    {
        public GameState GameState { get; set; }
        public ChangeGameStateEventArgs(GameState gameState)
        {
            this.GameState = gameState;
        }
    }
    */
}

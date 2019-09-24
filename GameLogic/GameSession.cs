using System.Collections.Generic;

namespace GameLogic
{
    internal class GameSession
    {
        private List<Player> CurrentPlayer { get; set; }

        public GameSession()
        {
            CurrentPlayer = new List<Player>()
            {
                new Player()
                {
                    Name = "Jordi",
                    Gold = 9999
                }
            };
        }
    }
}
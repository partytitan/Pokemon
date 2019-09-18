using System;
using System.Collections.Generic;
using System.Text;

namespace GameLogic
{
    class GameSession
    {
        List<Player> CurrentPlayer { get; set; }

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

using System.Collections.Generic;
using System.Linq;
using GameLogic.PokemonData;
namespace GameLogic.Trainers
{
    public class Trainer
    {
        public string Identity {get; set;}
        public string Name { get; private set; }
        public int PosX { get; set; }
        public int PosY { get; set; }

        public string currentMap { get; set; }

        private readonly List<Pokemon> party;

        public List<Pokemon> Party() => party.ToList();

        public void AddToParty(Pokemon pokemon)
        {
            if (party.Count < 6) party.Add(pokemon);
        }

        public Trainer(string name)
        {
            Name = name;
            party = new List<Pokemon>(6);
            this.PosX = 0;
            this.PosY = 0;
        }

        public Trainer(string name, List<Pokemon> party)
        {
            Name = name;
            this.party = party;
            this.PosX = 0;
            this.PosY = 0;
        }
        public Trainer(string name, int posX, int posY, string currentMap)
        {
            Name = name;
            this.PosX = posX;
            this.PosY = posY;
            this.currentMap = currentMap;
            party = new List<Pokemon>(6);
        }

        public Trainer(string name, List<Pokemon> party, int posX, int posY, string currentMap)
        {
            Name = name;
            this.party = party;
            this.PosX = posX;
            this.PosY = posY;
            this.currentMap = currentMap;
        }
    }
}

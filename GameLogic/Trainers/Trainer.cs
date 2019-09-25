using GameLogic.PokemonData;
using System.Collections.Generic;
using System.Linq;

namespace GameLogic.Trainers
{
    public class Trainer
    {
        public string Name { get; private set; }

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
        }

        public Trainer(string name, List<Pokemon> party)
        {
            Name = name;
            this.party = party;
        }
    }
}
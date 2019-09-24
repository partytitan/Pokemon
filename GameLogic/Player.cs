namespace GameLogic
{
    public class Player
    {
        public string Identity { get; set; }
        public string Name { get; set; }
        public int ExperiencePoints { get; set; }
        public int Level { get; set; }
        public int Gold { get; set; }
        public Coordinates coordinates { get; set; }

        public Player()
        {
            coordinates = new Coordinates(0, 0);
        }
    }
}
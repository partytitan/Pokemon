namespace GameLogic.Moves.Transitive.Status
{
    public abstract class TransitiveStatusMove : TransitiveMove
    {
        protected TransitiveStatusMove(int index, string name, Type type, int startingPP, int absoluteMaxPP, float accuracyPercent)
            : base(index, name, type, startingPP, absoluteMaxPP, accuracyPercent, 0, Battles.Category.STATUS)
        {
        }
    }
}
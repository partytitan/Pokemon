using Microsoft.Xna.Framework;
using System;

namespace Client.Services
{
    internal static class UtilityService
    {
        public static double GetDistance(Vector2 positionOne, Vector2 positionTwo)
        {
            var x = Math.Pow(positionOne.X - positionTwo.X, 2);
            var y = Math.Pow(positionOne.Y - positionTwo.Y, 2);
            return Math.Sqrt(x + y);
        }
    }
}
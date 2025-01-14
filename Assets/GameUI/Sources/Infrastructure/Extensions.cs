using System;

namespace GameUI.Sources.Infrastructure
{
    public static class Extensions
    {
        public static bool RandomBoolWithPercents(this int percents)
        {
            Random random = new Random();
            return percents > random.Next(100 + 1);
        }
    }
}
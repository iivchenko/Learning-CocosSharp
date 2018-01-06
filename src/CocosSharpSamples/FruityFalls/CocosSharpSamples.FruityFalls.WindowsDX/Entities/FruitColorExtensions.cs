using System;
using CocosSharp;

namespace CocosSharpSamples.FruityFalls.WindowsDX.Entities
{
    public static class FruitColorExtensions
    {
        public static CCColor4B ToCCColor(this FruitColor color)
        {
            switch (color)
            {
                case FruitColor.Yellow:
                    return new CCColor4B(150, 150, 0, 150);
                case FruitColor.Red:
                    return new CCColor4B(150, 0, 0, 150);
                default:
                    throw new ArgumentException("Unknown color " + color);
            }
        }
    }
}
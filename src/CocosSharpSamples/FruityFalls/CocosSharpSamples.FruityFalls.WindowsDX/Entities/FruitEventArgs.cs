using System;

namespace CocosSharpSamples.FruityFalls.WindowsDX.Entities
{
    public sealed class FruitEventArgs : EventArgs
    {
        public FruitEventArgs(Fruit fruit)
        {
            Fruit = fruit;
        }

        public Fruit Fruit { get; private set; }
    }
}

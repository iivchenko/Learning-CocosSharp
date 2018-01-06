using System;
using System.Collections.Generic;
using System.Linq;
using CocosSharp;

namespace CocosSharpSamples.FruityFalls.Game.Entities
{
    public sealed class FruitsPool
    {
        private readonly IList<Fruit> _fruits;
        private readonly float _spawnDelay;

        private float _spawnElapsed;

        public FruitsPool(float spawnDelay)
        {
            _spawnDelay = _spawnElapsed = spawnDelay;
            _fruits = new List<Fruit>();
        }

        public event EventHandler<FruitEventArgs> FruitCreated;

        public event EventHandler<FruitEventArgs> FruitDestroyed;

        public IEnumerable<Fruit> Fruits => _fruits.ToList();

        public void Update(float frameTime)
        {
            if (_spawnElapsed <= 0)
            {
                var fruit = GenerateFruit();

                _fruits.Add(fruit);

                OnFruit(fruit, FruitCreated);

                _spawnElapsed = _spawnDelay;
            }
            else
            {
                _spawnElapsed -= frameTime;
            }
        }

        internal void Remove(Fruit fruit)
        {
            _fruits.Remove(fruit);
            fruit.RemoveFromParent();

            OnFruit(fruit, FruitDestroyed);
        }

        private Fruit GenerateFruit()
        {
            var fruit =
                CCRandom.Float_0_1() > .5f
                    ? new Fruit(FruitColor.Red, this)
                    : new Fruit(FruitColor.Yellow, this);

            fruit.Visible = false;

            return fruit;
        }

        private void OnFruit(Fruit fruit, EventHandler<FruitEventArgs> fruitEvent)
        {
            fruitEvent?.Invoke(this, new FruitEventArgs(fruit));
        }
    }
}

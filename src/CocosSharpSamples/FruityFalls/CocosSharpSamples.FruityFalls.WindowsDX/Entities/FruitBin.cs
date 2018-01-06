using System.Diagnostics;
using CocosSharp;
using CocosSharpSamples.FruityFalls.WindowsDX.Geometry;

namespace CocosSharpSamples.FruityFalls.WindowsDX.Entities
{
    public class FruitBin : CCNode
    {
        private const float CollisionHeight = 100;

        private float _width = 200;
       
        private readonly FruitColor _fruitColor;

        public FruitBin(FruitColor color)
        {
            _fruitColor = color;
            CreateDebugGraphics();
        }

        public FruitColor FruitColor => _fruitColor;

        public Polygon Polygon
        {
            get;
            private set;
        }

        public float Width
        {
            get
            {
                return _width;
            }
            set
            {
                _width = value;

                // being lazy here:
                RemoveChild(Polygon);
                Polygon = Polygon.CreateRectangle(_width, CollisionHeight);
                // bin graphics are bottom-left aligned, so let's do the same with the polygon.
                Polygon.PositionX = _width / 2.0f;
                Polygon.PositionY = GameCoefficients.BinHeight - (CollisionHeight / 2.0f);
                AddChild(Polygon);
            }
        }

        [Conditional("DEBUG")]
        private void CreateDebugGraphics()
        {
            var graphic = new CCDrawNode();

            graphic.DrawRect(
                new CCRect(0, GameCoefficients.BinHeight - CollisionHeight, _width, CollisionHeight),
                fillColor: _fruitColor.ToCCColor());

            AddChild(graphic);
        }
    }
}


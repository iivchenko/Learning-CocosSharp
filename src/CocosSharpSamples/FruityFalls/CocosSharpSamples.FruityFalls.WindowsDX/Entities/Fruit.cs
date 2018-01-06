using System.Diagnostics;
using CocosSharp;
using CocosSharpSamples.FruityFalls.WindowsDX.Geometry;

namespace CocosSharpSamples.FruityFalls.WindowsDX.Entities
{
    public sealed class Fruit : CCNode
    {
        private readonly FruitsPool _pool;
        private readonly CCLabel _scoreLabel;

        public CCPoint Velocity;
        public CCPoint Acceleration;

        // This prevents the user from holding the
        // paddle under a fruit, earning extra points every frame
        float _scoreDelay;

        public Fruit(FruitColor fruitCollor, FruitsPool pool)
        {
            _pool = pool;
            Score = 1;
            _scoreLabel = CreateScoreLabel();

            CreateCollision();

            Acceleration.Y = GameCoefficients.FruitGravity;

            AddChild(CreateFruitGraphic(fruitCollor));
            AddChild(_scoreLabel);

            CreateDebugGraphic();
        }

        public int Score { get; private set; }

        // Putting this here just for convenience
        public float Radius
        {
            get
            {
                return GameCoefficients.FruitRadius;
            }
        }

        public Circle Collision
        {
            get;
            private set;
        }

        public FruitColor FruitColor { get; private set; }

        public void Destroy()
        {
            _pool.Remove(this);
        }

        private CCSprite CreateFruitGraphic(FruitColor color)
        {
            CCSprite graphic;
            if (color == FruitColor.Yellow)
            {
                graphic = new CCSprite(CCTextureCache.SharedTextureCache.AddImage("lemon.png"))
                {
                    IsAntialiased = false
                };

                _scoreLabel.Color = CCColor3B.Black;
                _scoreLabel.PositionY = 0;
            }
            else
            {
                graphic = new CCSprite(CCTextureCache.SharedTextureCache.AddImage("cherry.png"))
                {
                    IsAntialiased = false
                };

                _scoreLabel.Color = CCColor3B.White;
                _scoreLabel.PositionY = -8;
            }

            FruitColor = color;

            return graphic;
        }

        [Conditional("DEBUG")]
        private void CreateDebugGraphic()
        {
            var debugGrahic = new CCDrawNode();
            debugGrahic.Clear();
            const float borderWidth = 4;
            debugGrahic.DrawSolidCircle(
                CCPoint.Zero,
                GameCoefficients.FruitRadius,
                CCColor4B.Black);
            debugGrahic.DrawSolidCircle(
                CCPoint.Zero,
                GameCoefficients.FruitRadius - borderWidth,
                FruitColor.ToCCColor());

            AddChild(debugGrahic);
        }

        private void CreateCollision()
        {
            Collision = new Circle
            {
                Radius = GameCoefficients.FruitRadius
            };

            AddChild(Collision);
        }

        private CCLabel CreateScoreLabel()
        {
            return new CCLabel("", "Arial", 12, CCLabelFormat.SystemFont)
            {
                IsAntialiased = false,
                Color = CCColor3B.Black
            };
        }

        public override void Update(float frameTime)
        {
            base.Update(frameTime);

            _scoreDelay -= frameTime;

            // linear approximation:
            Velocity += Acceleration * frameTime;

            // This is a linera approximation to drag. It's used to
            // keep the object from falling too fast, and eventually
            // to slow its horizontal movement. This makes the game easier
            Velocity -= Velocity * GameCoefficients.FruitDrag * frameTime;

            Position += Velocity * frameTime;
        }

        public bool TryAddExtraPointValue()
        {
            var didAddPoint = false;

            if (_scoreDelay <= 0)
            {
                Score++;

                _scoreDelay = GameCoefficients.MinPointAwardingFrequency;
                _scoreLabel.Text = "+" + Score;
                didAddPoint = true;
            }

            return didAddPoint;
        }
    }
}


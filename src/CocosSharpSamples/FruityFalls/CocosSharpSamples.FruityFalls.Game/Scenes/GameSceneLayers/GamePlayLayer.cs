using System.Collections.Generic;
using System.Diagnostics;
using CocosDenshion;
using CocosSharp;
using CocosSharpSamples.FruityFalls.Game.Entities;
using CocosSharpSamples.FruityFalls.Game.Geometry;

namespace CocosSharpSamples.FruityFalls.Game.Scenes.GameSceneLayers
{
    public sealed class GameplayLayer : CCLayer
    {
        private readonly ScoreBox _scoreBox;
        private readonly FruitsPool _fruitsPool;

        private Paddle _paddle;
        private SolidRectangle _splitter;
        private IList<FruitBin> _bins;

        public GameplayLayer(ScoreBox scoreBox)
        {
            _scoreBox = scoreBox;

            _fruitsPool = new FruitsPool(GameCoefficients.FruitGenerateDelay);
            _fruitsPool.FruitDestroyed += FruitDestroyed;
            _fruitsPool.FruitCreated += FruitCreated;

            _paddle = new Paddle();

            CreateBins();

            CreateTouchListener();

            SetupDebug();

            AddChild(_paddle);

            Schedule(Activity);
        }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            _bins[0].PositionX = 0;
            _bins[0].PositionY = 10;
            _bins[0].Width = ContentSize.Width / 2;

            _bins[1].PositionX = ContentSize.Width / 2;
            _bins[1].Width = ContentSize.Width / 2;
            _bins[1].PositionY = 10;

            _splitter.PositionX = ContentSize.Width / 2.0f;
            _splitter.PositionY = GameCoefficients.SplitterHeight / 2.0f;

            _paddle.PositionX = ContentSize.Width / 2.0f;
            _paddle.PositionY = ContentSize.Height / 2.0f;
            _paddle.SetDesiredPositionToCurrentPosition();
        }

        private void FruitDestroyed(object sender, FruitEventArgs args)
        {
            RemoveChild(args.Fruit);
        }

        private void FruitCreated(object sender, FruitEventArgs args)
        {
            args.Fruit.PositionX = CCRandom.GetRandomFloat(0 + args.Fruit.Radius, ContentSize.Width - args.Fruit.Radius);
            args.Fruit.PositionY = ContentSize.Height + args.Fruit.Radius;
            args.Fruit.Visible = true;

            AddChild(args.Fruit);
        }

        private void CreateBins()
        {
            _bins = new List<FruitBin>();
            _splitter = new SolidRectangle(20, GameCoefficients.SplitterHeight)
            {
                Visible = false
            };

            var redBin = new FruitBin(FruitColor.Red);
            var yellowBin = new FruitBin(FruitColor.Yellow);

            _bins.Add(redBin);
            _bins.Add(yellowBin);

            AddChild(redBin);
            AddChild(yellowBin);
            AddChild(_splitter);
        }

        private void CreateTouchListener()
        {
            var touchListener = new CCEventListenerTouchAllAtOnce
            {
                OnTouchesMoved = HandleTouchesMoved
            };

            AddEventListener(touchListener);
        }

        void HandleTouchesMoved(List<CCTouch> touches, CCEvent touchEvent)
        {
            // we only care about the first touch:
            var locationOnScreen = touches[0].Location;

            _paddle.HandleInput(locationOnScreen);
        }

        private void Activity(float frameTime)
        {
            _paddle.Activity(frameTime);

            foreach (var fruit in _fruitsPool.Fruits)
            {
                fruit.Update(frameTime);
            }

            _fruitsPool.Update(frameTime);

            PerformCollision();
        }

        private void PerformCollision()
        {
            // reverse for loop since fruit may be destroyed:
            foreach (var fruit in _fruitsPool.Fruits)
            {
                FruitVsPaddle(fruit);

                if (FruitPolygonCollision(fruit, _splitter.Polygon, CCPoint.Zero))
                {
                    CCSimpleAudioEngine.SharedEngine.PlayEffect("FruitEdgeBounce");
                }

                FruitVsBorders(fruit);

                FruitVsBins(fruit);
            }
        }

        private void FruitVsPaddle(Fruit fruit)
        {
            bool didCollideWithPaddle = FruitPolygonCollision(fruit, _paddle.Polygon, _paddle.Velocity);
            if (didCollideWithPaddle)
            {
                bool didAddPoint = fruit.TryAddExtraPointValue();
                if (didAddPoint)
                {
                    CCSimpleAudioEngine.SharedEngine.PlayEffect("FruitPaddleBounce");
                }
            }
        }

        private void FruitVsBins(Fruit fruit)
        {
            foreach (var bin in _bins)
            {
                if (bin.Polygon.CollideAgainst(fruit.Collision))
                {
                    if (bin.FruitColor == fruit.FruitColor)
                    {
                        _scoreBox.Add(fruit.Score);
                        fruit.Destroy();
                        CCSimpleAudioEngine.SharedEngine.PlayEffect("FruitInBin");
                    }
                    else
                    {
                        // Game over
                        Director.ReplaceScene(new GameOverScene(Window, _scoreBox.Score));
                        CCSimpleAudioEngine.SharedEngine.PlayEffect("GameOver");
                    }

                    break;
                }
            }
        }

        private static bool FruitPolygonCollision(Fruit fruit, Polygon polygon, CCPoint polygonVelocity)
        {
            // Test whether the fruit collides
            var didCollide = polygon.CollideAgainst(fruit.Collision);

            if (didCollide)
            {
                var circle = fruit.Collision;

                // Get the separation vector to reposition the fruit so it doesn't overlap the polygon
                var separation = CollisionResponse.GetSeparationVector(circle, polygon);
                fruit.Position += separation;

                // Adjust the fruit's Velocity to make it bounce:
                var normal = separation;
                normal.Normalize();
                fruit.Velocity = CollisionResponse.ApplyBounce(
                    fruit.Velocity,
                    polygonVelocity,
                    normal,
                    GameCoefficients.FruitCollisionElasticity);

            }
            return didCollide;
        }

        private void FruitVsBorders(Fruit fruit)
        {
            if (fruit.PositionX - fruit.Radius < 0 && fruit.Velocity.X < 0)
            {
                fruit.Velocity.X *= -1 * GameCoefficients.FruitCollisionElasticity;
                CCSimpleAudioEngine.SharedEngine.PlayEffect("FruitEdgeBounce");
            }
            if (fruit.PositionX + fruit.Radius > ContentSize.Width && fruit.Velocity.X > 0)
            {
                fruit.Velocity.X *= -1 * GameCoefficients.FruitCollisionElasticity;
                CCSimpleAudioEngine.SharedEngine.PlayEffect("FruitEdgeBounce");

            }
            if (fruit.PositionY + fruit.Radius > ContentSize.Height && fruit.Velocity.Y > 0)
            {
                fruit.Velocity.Y *= -1 * GameCoefficients.FruitCollisionElasticity;
                CCSimpleAudioEngine.SharedEngine.PlayEffect("FruitEdgeBounce");
            }
        }

        [Conditional("DEBUG")]
        private void SetupDebug()
        {
            _splitter.Visible = true;
        }
    }
}

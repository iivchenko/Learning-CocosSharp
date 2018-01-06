using CocosSharp;
using CocosSharpSamples.FruityFalls.Game.Scenes.GameSceneLayers;

namespace CocosSharpSamples.FruityFalls.Game.Scenes
{
    public class GameScene : CCScene
    {
        //private readonly FruitsPool _fruitsPool;

        //private CCLayer _gameplayLayer;
        //private readonly HudLayer _hudLayer;

        //private Paddle _paddle;

        //private SolidRectangle _splitter;

        // IList<FruitBin> _bins;

        public GameScene(CCWindow window) : base(window)
        {
            //_fruitsPool = new FruitsPool(GameCoefficients.FruitGenerateDelay);
            //_fruitsPool.FruitDestroyed += FruitDestroyed;
            //_fruitsPool.FruitCreated += FruitCreated;
            
            var backgroundLayer = new BackgroundLayer();
            var hudLayer = new HudLayer();
            var gameplayLayer = new GameplayLayer(hudLayer.ScoreBox);
            var foregraundLayer = new ForegroundLayer();


            AddChild(backgroundLayer);

            //CreatePaddle();

            //CreateBins();

            AddChild(gameplayLayer);
            AddChild(foregraundLayer);

            //CreateTouchListener();

            AddChild(hudLayer);

            //Schedule(Activity);
        }

        //private void CreatePaddle()
        //{
        //    _gameplayLayer = new CCLayer();
        //    AddChild(_gameplayLayer);

        //    _paddle = new Paddle
        //    {
        //        PositionX = _gameplayLayer.ContentSize.Width / 2.0f,
        //        PositionY = _gameplayLayer.ContentSize.Height / 2.0f
        //    };

        //    _paddle.SetDesiredPositionToCurrentPosition();

        //    _gameplayLayer.AddChild(_paddle);
        //}

        //private void CreateBins()
        //{
        //    var gameView = Window;

        //    _bins = new List<FruitBin>();

        //    // make 2 bins for now:
        //    var bin = new FruitBin(FruitColor.Red)
        //    {
        //        Width = gameView.WindowSizeInPixels.Width / 2
        //    };

        //    _bins.Add(bin);
        //    _gameplayLayer.AddChild(bin);

        //    bin = new FruitBin(FruitColor.Yellow)
        //    {
        //        PositionX = gameView.WindowSizeInPixels.Width / 2,
        //        Width = gameView.WindowSizeInPixels.Width / 2
        //    };

        //    // todo: use the screen width to assign this:
        //    _bins.Add(bin);
        //    _gameplayLayer.AddChild(bin);

        //    _splitter = new SolidRectangle(20, GameCoefficients.SplitterHeight)
        //    {
        //        PositionX = _gameplayLayer.ContentSize.Width / 2.0f,
        //        PositionY = GameCoefficients.SplitterHeight / 2.0f,
        //        // TODO: to debug 
        //        //Visible = GameCoefficients.ShowCollisionAreas
        //    };

        //    _gameplayLayer.AddChild(_splitter);
        //}

        //private void CreateTouchListener()
        //{
        //    var touchListener = new CCEventListenerTouchAllAtOnce
        //    {
        //        OnTouchesMoved = HandleTouchesMoved
        //    };

        //    _gameplayLayer.AddEventListener(touchListener);
        //}

        //void HandleTouchesMoved(List<CCTouch> touches, CCEvent touchEvent)
        //{
        //    // we only care about the first touch:
        //    var locationOnScreen = touches[0].Location;

        //    _paddle.HandleInput(locationOnScreen);
        //}

        //private void Activity(float frameTime)
        //{
        //    _paddle.Activity(frameTime);

        //    foreach (var fruit in _fruitsPool.Fruits)
        //    {
        //        fruit.Update(frameTime);
        //    }

        //    _fruitsPool.Update(frameTime);

        //    PerformCollision();
        //}

        //private void PerformCollision()
        //{
        //    // reverse for loop since fruit may be destroyed:
        //    foreach (var fruit in _fruitsPool.Fruits)
        //    {
        //        FruitVsPaddle(fruit);

        //        if (FruitPolygonCollision(fruit, _splitter.Polygon, CCPoint.Zero))
        //        {
        //            CCSimpleAudioEngine.SharedEngine.PlayEffect("FruitEdgeBounce");
        //        }

        //        FruitVsBorders(fruit);

        //        FruitVsBins(fruit);
        //    }
        //}

        //private void FruitVsPaddle(Fruit fruit)
        //{
        //    bool didCollideWithPaddle = FruitPolygonCollision(fruit, _paddle.Polygon, _paddle.Velocity);
        //    if (didCollideWithPaddle)
        //    {
        //        bool didAddPoint = fruit.TryAddExtraPointValue();
        //        if (didAddPoint)
        //        {
        //            CCSimpleAudioEngine.SharedEngine.PlayEffect("FruitPaddleBounce");
        //        }
        //    }
        //}

        //private void FruitVsBins(Fruit fruit)
        //{
        //    foreach (var bin in _bins)
        //    {
        //        if (bin.Polygon.CollideAgainst(fruit.Collision))
        //        {
        //            if (bin.FruitColor == fruit.FruitColor)
        //            {
        //                _hudLayer.ScoreBox.Add(fruit.Score);
        //                fruit.Destroy();
        //                CCSimpleAudioEngine.SharedEngine.PlayEffect("FruitInBin");
        //            }
        //            else
        //            {
        //                // Game over
        //                Director.ReplaceScene(new GameOverScene(Window, _hudLayer.ScoreBox.Score));
        //                CCSimpleAudioEngine.SharedEngine.PlayEffect("GameOver");
        //            }

        //            break;
        //        }
        //    }
        //}

        //private void FruitDestroyed(object sender, FruitEventArgs args)
        //{
        //    RemoveChild(args.Fruit);
        //}

        //private void FruitCreated(object sender, FruitEventArgs args)
        //{
        //    args.Fruit.PositionX = CCRandom.GetRandomFloat(0 + args.Fruit.Radius, _gameplayLayer.ContentSize.Width - args.Fruit.Radius);
        //    args.Fruit.PositionY = _gameplayLayer.ContentSize.Height + args.Fruit.Radius;
        //    args.Fruit.Visible = true;

        //    _gameplayLayer.AddChild(args.Fruit);
        //}

        //private static bool FruitPolygonCollision(Fruit fruit, Polygon polygon, CCPoint polygonVelocity)
        //{
        //    // Test whether the fruit collides
        //    var didCollide = polygon.CollideAgainst(fruit.Collision);

        //    if (didCollide)
        //    {
        //        var circle = fruit.Collision;

        //        // Get the separation vector to reposition the fruit so it doesn't overlap the polygon
        //        var separation = CollisionResponse.GetSeparationVector(circle, polygon);
        //        fruit.Position += separation;

        //        // Adjust the fruit's Velocity to make it bounce:
        //        var normal = separation;
        //        normal.Normalize();
        //        fruit.Velocity = CollisionResponse.ApplyBounce(
        //            fruit.Velocity,
        //            polygonVelocity,
        //            normal,
        //            GameCoefficients.FruitCollisionElasticity);

        //    }
        //    return didCollide;
        //}

        //private void FruitVsBorders(Fruit fruit)
        //{
        //    if (fruit.PositionX - fruit.Radius < 0 && fruit.Velocity.X < 0)
        //    {
        //        fruit.Velocity.X *= -1 * GameCoefficients.FruitCollisionElasticity;
        //        CCSimpleAudioEngine.SharedEngine.PlayEffect("FruitEdgeBounce");
        //    }
        //    if (fruit.PositionX + fruit.Radius > _gameplayLayer.ContentSize.Width && fruit.Velocity.X > 0)
        //    {
        //        fruit.Velocity.X *= -1 * GameCoefficients.FruitCollisionElasticity;
        //        CCSimpleAudioEngine.SharedEngine.PlayEffect("FruitEdgeBounce");

        //    }
        //    if (fruit.PositionY + fruit.Radius > _gameplayLayer.ContentSize.Height && fruit.Velocity.Y > 0)
        //    {
        //        fruit.Velocity.Y *= -1 * GameCoefficients.FruitCollisionElasticity;
        //        CCSimpleAudioEngine.SharedEngine.PlayEffect("FruitEdgeBounce");
        //    }
        //}
    }
}
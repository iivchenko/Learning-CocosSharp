using CocosSharp;

namespace CocosSharpSamples.FruityFalls.WindowsDX.Scenes
{
    public sealed class GameOverScene : CCScene
    {
        public GameOverScene(CCWindow window, int score) 
            : base(window)
        {
            var gameoverLayer = new CCLayer();
            AddChild(gameoverLayer);

            var endGameLabel = new CCLabel("Game Over\nFinal Score:" + score, "Arial", 40, CCLabelFormat.SystemFont)
            {
                Color = CCColor3B.White,
                PositionX = gameoverLayer.ContentSize.Width / 2.0f,
                PositionY = gameoverLayer.ContentSize.Height / 2.0f
            };

            var touchListener = new CCEventListenerTouchAllAtOnce
            {
                OnTouchesBegan = (touches, @event) => Director.ReplaceScene(new GameScene(Window))
            };

            gameoverLayer.AddChild(endGameLabel);
            gameoverLayer.AddEventListener(touchListener);
        }
    }
}

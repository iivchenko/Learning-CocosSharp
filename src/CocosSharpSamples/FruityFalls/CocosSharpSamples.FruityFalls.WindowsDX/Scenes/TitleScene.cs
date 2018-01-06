using CocosSharp;

namespace CocosSharpSamples.FruityFalls.WindowsDX.Scenes
{
    public sealed class TitleScene : CCScene
    {
        public TitleScene(CCWindow window) 
            : base(window)
        {
            var layer = new CCLayer();

            AddChild(layer);

            var label = new CCLabel("Tap to begin", "Arial", 30, CCLabelFormat.SystemFont)
            {
                PositionX = layer.ContentSize.Width / 2.0f,
                PositionY = layer.ContentSize.Height / 2.0f,
                Color = CCColor3B.White
            };

            var touchListener = new CCEventListenerTouchAllAtOnce
            {
                OnTouchesBegan = (touches, @event) => Director.ReplaceScene(new GameScene(this.Window))
            };

            layer.AddChild(label);
            layer.AddEventListener(touchListener);
        }
    }
}

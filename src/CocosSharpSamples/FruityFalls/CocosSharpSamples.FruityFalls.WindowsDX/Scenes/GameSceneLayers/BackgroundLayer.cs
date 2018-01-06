using CocosSharp;

namespace CocosSharpSamples.FruityFalls.WindowsDX.Scenes.GameSceneLayers
{
    public sealed class BackgroundLayer : CCLayer
    {
        public BackgroundLayer()
        {
            AddChild(new CCSprite("background")
            {
                AnchorPoint = new CCPoint(0, 0),
                IsAntialiased = false
            });
        }
    }
}

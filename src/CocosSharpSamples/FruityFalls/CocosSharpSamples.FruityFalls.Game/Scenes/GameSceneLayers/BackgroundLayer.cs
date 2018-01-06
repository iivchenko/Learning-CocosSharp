using CocosSharp;

namespace CocosSharpSamples.FruityFalls.Game.Scenes.GameSceneLayers
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

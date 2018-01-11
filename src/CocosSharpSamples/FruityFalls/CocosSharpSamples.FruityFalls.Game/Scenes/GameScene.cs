using CocosSharp;
using CocosSharpSamples.FruityFalls.Game.Scenes.GameSceneLayers;

namespace CocosSharpSamples.FruityFalls.Game.Scenes
{
    public class GameScene : CCScene
    {
        public GameScene(CCWindow window) : base(window)
        {
            var backgroundLayer = new BackgroundLayer();
            var hudLayer = new HudLayer();
            var gameplayLayer = new GameplayLayer(hudLayer.ScoreBox);
            var foregraundLayer = new ForegroundLayer();

            AddChild(backgroundLayer);
            AddChild(gameplayLayer);
            AddChild(foregraundLayer);
            AddChild(hudLayer);
        }
    }
}
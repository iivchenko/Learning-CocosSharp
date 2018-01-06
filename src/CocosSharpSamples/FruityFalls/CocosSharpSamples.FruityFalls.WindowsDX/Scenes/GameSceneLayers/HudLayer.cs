using CocosSharp;
using CocosSharpSamples.FruityFalls.WindowsDX.Entities;

namespace CocosSharpSamples.FruityFalls.WindowsDX.Scenes.GameSceneLayers
{
    public sealed class HudLayer : CCLayer
    {
        public HudLayer()
        {
            ScoreBox = new ScoreBox();

            AddChild(ScoreBox);
        }

        public ScoreBox ScoreBox { get; }

        protected override void AddedToScene()
        {
            base.AddedToScene();

            ScoreBox.PositionX = 5;
            ScoreBox.PositionY = ContentSize.Height;
            ScoreBox.AnchorPoint = CCPoint.AnchorLowerLeft;
        }
    }
}

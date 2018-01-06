using System.Diagnostics;
using CocosSharp;

namespace CocosSharpSamples.FruityFalls.Game.Scenes.GameSceneLayers
{
    public sealed class ForegroundLayer : CCLayer
    {
        public ForegroundLayer()
        {
            AddChild(new CCSprite("foreground")
            {
                IsAntialiased = false,
                AnchorPoint = new CCPoint(0, 0)
            });
           
            SetupDebug();
        }

        [Conditional("DEBUG")]
        private void SetupDebug()
        {
            Visible = false;
        }
    }
}

using CocosSharp;
using CocosSharpSamples.Dungeon.Game.Scenes.GamePlaySceneLayers;

namespace CocosSharpSamples.Dungeon.Game.Scenes
{
    public sealed class GamePlayScene : CCScene
    {
        public GamePlayScene(CCWindow window)
            :base(window)
        {
            AddChild(new GameLayer());
        }
    }
}

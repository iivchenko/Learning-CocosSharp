using CocosSharp;
using CocosSharpSamples.Dungeon.Game.Scenes;
using CocosDenshion;

namespace CocosSharpSamples.Dungeon.Game
{
    public class GameDelegate : CCApplicationDelegate
    {
        public override void ApplicationDidFinishLaunching(CCApplication application, CCWindow mainWindow)
        {
            application.ContentRootDirectory = "Content";
            application.ContentSearchPaths.Add("Tilemaps");

            CCScene.SetDefaultDesignResolution(380, 240, CCSceneResolutionPolicy.ShowAll);
            mainWindow.RunWithScene(new GamePlayScene(mainWindow));
        }

        public override void ApplicationDidEnterBackground(CCApplication application)
        {
            application.Paused = true;
        }

        public override void ApplicationWillEnterForeground(CCApplication application)
        {
            application.Paused = false;
        }
    }
}

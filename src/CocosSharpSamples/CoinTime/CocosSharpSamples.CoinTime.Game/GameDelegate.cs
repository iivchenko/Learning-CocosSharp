using CocosSharp;
using CocosSharpSamples.CoinTime.Game.Scenes;
using CocosDenshion;

namespace CocosSharpSamples.CoinTime.Game
{
	public class GameDelegate : CCApplicationDelegate
	{
		static CCDirector director;
		static CCWindow mainWindow;

		public override void ApplicationDidFinishLaunching (CCApplication application, CCWindow mainWindow)
		{
			GameDelegate.mainWindow = mainWindow;
		    director = mainWindow.DefaultDirector;


            application.PreferMultiSampling = false;
			application.ContentRootDirectory = "Content";
			application.ContentSearchPaths.Add ("animations");
			application.ContentSearchPaths.Add ("fonts");
			application.ContentSearchPaths.Add ("images");
			application.ContentSearchPaths.Add ("levels");
		    application.ContentSearchPaths.Add("sounds");

            // Use the SNES resolution:
            float desiredWidth = 256.0f;
            float desiredHeight = 224.0f;

            CCScene.SetDefaultDesignResolution (desiredWidth, desiredHeight, CCSceneResolutionPolicy.ShowAll);

            // TODO: Doesn't work! Fix it
            //CCSimpleAudioEngine.SharedEngine.PlayBackgroundMusic("CoinTimeSong", loop: true);
            // Make the audio a little quieter:
            CCSimpleAudioEngine.SharedEngine.EffectsVolume = .3f;
			var scene = new LevelSelectScene (mainWindow);
            // Can skip to the GmameScene by using this line instead:
            //var scene = new GameScene(mainWindow);
		    mainWindow.DisplayStats = true;
		    mainWindow.RunWithScene (scene);
        }

		public override void ApplicationDidEnterBackground (CCApplication application)
		{
			application.Paused = true;
		}

		public override void ApplicationWillEnterForeground (CCApplication application)
		{
			application.Paused = false;
		}

		// For this game we're just going to handle moving between scenes here
		// A larger game might have a "flow" object responsible for moving between
		// scenes.
		public static void GoToGameScene()
		{
			var scene = new GameScene (mainWindow);
			director.ReplaceScene (scene);
		}

		public static void GoToLevelSelectScene()
		{
			var scene = new LevelSelectScene (mainWindow);
			director.ReplaceScene (scene);
		}

		public static void GoToHowToScene()
		{

			var scene = new HowToPlayScene (mainWindow);
			director.ReplaceScene (scene);
		}
	}
}

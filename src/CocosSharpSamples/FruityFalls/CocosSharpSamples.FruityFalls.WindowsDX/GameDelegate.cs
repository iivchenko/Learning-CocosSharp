using System.Collections.Generic;
using CocosDenshion;
using CocosSharp;
using CocosSharpSamples.FruityFalls.WindowsDX.Scenes;

namespace CocosSharpSamples.FruityFalls.WindowsDX
{
	public sealed class GameDelegate : CCApplicationDelegate
	{
        public override void ApplicationDidFinishLaunching(CCApplication application, CCWindow mainWindow)
        {
            application.ContentRootDirectory = "Content";
            application.ContentSearchPaths = new List<string> { "Sounds", "Images" };

            // We use a lower-resolution display to get a pixellated appearance
            int width = 384;
			int height = 512;
		    CCScene.SetDefaultDesignResolution(width, height, CCSceneResolutionPolicy.ShowAll);
 
            InitializeAudio();
            var scene = new TitleScene (mainWindow);
            mainWindow.RunWithScene(scene);
		}

        private static void InitializeAudio()
        {
            CCSimpleAudioEngine.SharedEngine.BackgroundMusicVolume = 1f;
           //CCSimpleAudioEngine.SharedEngine.PlayBackgroundMusic("FruityFallsSong");
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


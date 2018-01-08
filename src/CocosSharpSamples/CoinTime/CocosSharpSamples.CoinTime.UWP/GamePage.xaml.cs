using Windows.ApplicationModel.Activation;
using Windows.Graphics.Display;
using Windows.UI.Xaml;
using CocosSharp;
using CocosSharpSamples.CoinTime.Game;

namespace CocosSharpSamples.CoinTime.UWP
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class GamePage
    {
        public GamePage(LaunchActivatedEventArgs args)
        {
            this.InitializeComponent();

            DisplayInformation.AutoRotationPreferences = DisplayOrientations.Landscape;

            CCApplication.Create(new GameDelegate(), args, Window.Current.CoreWindow, this);
        }
    }
}

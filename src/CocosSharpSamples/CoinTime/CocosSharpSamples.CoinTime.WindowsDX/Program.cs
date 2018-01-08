using CocosSharp;
using CocosSharpSamples.CoinTime.Game;

namespace CocosSharpSamples.CoinTime.WindowsDX
{
    class Program
    {
        static void Main(string[] args)
        {
            new CCApplication(false)
                {
                    ApplicationDelegate = new GameDelegate()
                }
                .StartGame();
        }
    }
}

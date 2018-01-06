using System;
using CocosSharp;
using CocosSharpSamples.FruityFalls.Game;

namespace CocosSharpSamples.FruityFalls.WindowsDX
{
    public static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
		[STAThread]
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


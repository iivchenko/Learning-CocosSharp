using System;
using CocosSharp;
using System.Collections.Generic;
using CocosSharpSamples.CoinTime.Game.ContentRuntime.Animations;

namespace CocosSharpSamples.CoinTime.Game.Entities
{
	public class Coin : AnimatedSpriteEntity
	{

		public Coin ()
		{
			LoadAnimations ("Content/animations/coinanimations.achx");

			CurrentAnimation = animations [0];
		}
	}
}


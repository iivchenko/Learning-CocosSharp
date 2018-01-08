using System;

namespace CocosSharpSamples.CoinTime.Game.Entities
{
	public class Spikes : AnimatedSpriteEntity, IDamageDealer
	{
		public Spikes ()
		{
			LoadAnimations ("Content/animations/propanimations.achx");

			CurrentAnimation = animations [0];
		}
	}
}


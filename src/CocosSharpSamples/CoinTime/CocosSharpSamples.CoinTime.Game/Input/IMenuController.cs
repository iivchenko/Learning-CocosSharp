using System;

namespace CocosSharpSamples.CoinTime.Game
{
	public interface IMenuController
	{
		bool IsConnected { get; }

		bool MovedLeft { get;}
		bool MovedRight { get; }

		bool SelectPressed { get; }

		void UpdateInputValues();
	}
}


using System;

namespace CocosSharpSamples.CoinTime.Game
{
	public interface IGameController
	{
		bool IsConnected { get; }

		float HorizontalRatio { get; }

		bool JumpPressed { get; }

		bool BackPressed { get; }

		void UpdateInputValues();
	}
}


using CocosSharp;

namespace CocosSharpSamples.FruityFalls.Game.Geometry
{
	public class Circle : CCNode
	{
		public float Radius
		{
			get;
			set;
		}

		public Circle ()
		{
		}

		public bool IsPointInside(CCPoint point)
		{
			var absolutePosition = this.PositionWorldspace;

			return (point.X - absolutePosition.X) * (point.X - absolutePosition.X) +
				(point.Y - absolutePosition.Y) * (point.Y - absolutePosition.Y) <
				Radius * Radius;
		}
	}
}


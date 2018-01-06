using CocosSharp;
using CocosSharpSamples.FruityFalls.Game.Geometry;

namespace CocosSharpSamples.FruityFalls.Game.Entities
{
    public class SolidRectangle : CCNode
    {
        public Polygon Polygon
        {
            get;
            private set;
        }


        public SolidRectangle(float width, float height)
        {
            Polygon = Polygon.CreateRectangle(width, height);

            var graphic = new CCDrawNode();

            graphic.DrawRect(
                new CCRect(-width / 2, -height / 2, width, height),
                fillColor: CCColor4B.Blue);

            this.AddChild(graphic);

            this.AddChild(Polygon);
        }
    }
}

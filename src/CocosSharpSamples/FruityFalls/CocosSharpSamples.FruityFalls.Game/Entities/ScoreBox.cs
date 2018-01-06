using CocosSharp;

namespace CocosSharpSamples.FruityFalls.Game.Entities
{
    public sealed class ScoreBox : CCNode
    {
        private readonly CCLabel _label;

        private int _score;

        public ScoreBox()
        {
            _label = new CCLabel("Score: 0", "Arial", 20, CCLabelFormat.SystemFont)
            {
               AnchorPoint = new CCPoint(0, 1)
            };

            this.AddChild(_label);
        }

        public int Score => _score;

        public void Add(int score)
        {
            _score += score;

            UpdateText();
        }

        public void Substract(int score)
        {
            _score -= score;

            UpdateText();
        }

        private void UpdateText()
        {
            _label.Text = "Score: " + _score;
        }
    }
}

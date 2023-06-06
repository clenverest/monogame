using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Text;


namespace Village;

public class AnimatedText : TextlabelObject
{
    int timeCount = 0;

    static readonly int PERIOD = 50;

    StringBuilder drawableText, textToDraw;

    public bool IsEnded { get => textToDraw.Length == 0; }

    public AnimatedText(Vector2 position, float maxWidth, SpriteFont font, string text)
        : base(position, maxWidth, font, text)
    {
        textToDraw = new StringBuilder(this.text);
        drawableText = new StringBuilder(); this.text = "";
    }

    public override void Draw()
    {
        Animate(); 
        base.Draw();
    }

    public override void UpdateText(string newText, float maxWidth)
    {
        base.UpdateText(newText, maxWidth);

        textToDraw = new StringBuilder(text);
        drawableText = new StringBuilder(); 
        text = "";
    }

    private void Animate()
    {
        timeCount += (int)Drawing.DeltaMilli;

        if (timeCount > PERIOD)
        {
            timeCount -= PERIOD;

            if (textToDraw.Length <= 0) return;

            drawableText.Append(textToDraw[0]);
            textToDraw.Remove(0, 1);
            text = drawableText.ToString();
        }
    }
}

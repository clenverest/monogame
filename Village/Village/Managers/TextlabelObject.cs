using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Text;


namespace Village;

public class TextlabelObject
{
    protected string text;
    protected SpriteFont font;
    protected Vector2 position;

    public TextlabelObject(Vector2 position, float maxWidth, SpriteFont font, string text)
    {
        this.font = font;
        this.position = position;
        this.text = CutText(text, maxWidth, font);
    }

    public virtual void Draw()
    {
        Drawing.SpriteBatch.DrawString(font, text, position, Color.Black);
    }

    public virtual void UpdateText(string newText, float maxWidth)
    {
        text = CutText(newText, maxWidth, font);
    }

    private static string CutText(string text, float maxWidth, SpriteFont font)
    {
        var currentLength = 0f;
        var builder = new StringBuilder();
        var splitedText = text.Split(" ");

        for (int i = 0; i < splitedText.Length; i++)
        {
            var textToAdd = splitedText[i];
            if (splitedText.Length != i + 1) 
                textToAdd += " ";

            var delta = font.MeasureString(textToAdd).X;

            if (currentLength + delta > maxWidth)
            {
                currentLength = 0; 
                builder.Append("\n");
            }

            builder.Append(textToAdd); 
            currentLength += delta;
        }
        return builder.ToString();
    }
}

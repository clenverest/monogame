using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework;
using System.Text;


namespace Village;

public class TextObject
{
    protected Vector2 position;
    protected string text;
    protected SpriteFont font;

    public TextObject(Vector2 position, float maxWidth, SpriteFont font, string text)
    {
        this.position = position;
        this.font = font;
        this.text = CutText(text, maxWidth, font);
    }

    public virtual void Update(string newText, float maxWidth)
    {
        text = CutText(newText, maxWidth, font);
    }

    public virtual void Draw()
    {
        Drawing.SpriteBatch.DrawString(font, text, position, Color.Black);
    }

    static string CutText(string text, float maxWidth, SpriteFont font)
    {
        var currentLength = 0f;
        var cutText = new StringBuilder();
        var words = text.Split(" ");

        for (int i = 0; i < words.Length; i++)
        {
            var textToAdd = words[i];

            if (words.Length != i + 1) 
                textToAdd += " ";

            var symbolWidth = font.MeasureString(textToAdd).X;

            if (currentLength + symbolWidth > maxWidth)
            {
                currentLength = 0; 
                cutText.Append("\n");
            }

            cutText.Append(textToAdd); 
            currentLength += symbolWidth;
        }

        return cutText.ToString();
    }
}

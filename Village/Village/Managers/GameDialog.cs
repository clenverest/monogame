using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;

namespace Village;

public static class GameDialog
{
    static public Queue<string> Dialogs = new();
    static readonly Point padding = new(40, 20);
    static Rectangle bounds = new(Drawing.DialogPosition, Drawing.DialogSize);
    static Texture2D texture;
    static bool isStart = true;
    static public bool IsActive = false;
    static SpriteFont font;

    static AnimatedText TextObject;

    static public void Init(Game1 game)
    {
        texture = game.Content.Load<Texture2D>("Sprites\\GUI\\Dialog");
        font = game.Content.Load<SpriteFont>("Fonts\\Font");
    }

    static public void Update()
    {
        var keyboard = Keyboard.GetState();
        if (isStart)
        {
            IsActive = true;
            TextObject = InitTextlabel(Drawing.DialogPosition, Dialogs.Dequeue());
            isStart = false;
        }

        else if (keyboard.IsKeyDown(Keys.Space) && TextObject.IsEnded)
        {
            if (Dialogs.Count != 0)
                TextObject.Update(Dialogs.Dequeue(), bounds.Width - 2 * padding.X);
            else
            {
                IsActive = false;
                isStart = true;
            }
        }
    }

    static public void Draw()
    {
        if (IsActive)
        {
            Drawing.SpriteBatch.Begin();
            Drawing.SpriteBatch.Draw(texture, bounds, Color.White);
            TextObject.Draw();
            Drawing.SpriteBatch.End();
        }
    }

    static private AnimatedText InitTextlabel(Point labelPosition, string text)
    {
        var textPosition = labelPosition + padding;
        return new(textPosition.ToVector2(), bounds.Width - 2 * padding.X, font, text);
    }
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;
using System;
using System.Collections.Generic;
using System.Reflection.Metadata.Ecma335;

namespace Village;

public static class GameDialog
{
    static public Queue<string> dialogs = new();
    static readonly Point padding = new(40, 20);
    static Rectangle hitbox = new(Drawing.DialogPosition, Drawing.DialogSize);
    static Texture2D texture;
    static bool isStart = true;
    static public bool IsActive = false;
    static SpriteFont font;

    static public Rectangle Hitbox => hitbox;

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
            TextObject = InitTextlabel(Drawing.DialogPosition, dialogs.Dequeue());
            isStart = false;
        }

        else if (keyboard.IsKeyDown(Keys.Space) && TextObject.IsEnded)
        {
            if (dialogs.Count != 0)
            {
                TextObject.UpdateText(dialogs.Dequeue(), hitbox.Width - 2 * padding.X);
            }
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
            Drawing.SpriteBatch.Draw(texture, hitbox, Color.White);
            TextObject.Draw();
            Drawing.SpriteBatch.End();
        }
    }

    static private AnimatedText InitTextlabel(Point labelPos, string text)
    {
        var textPosition = labelPos + padding;
        return new(textPosition.ToVector2(), hitbox.Width - 2 * padding.X, font, text);
    }
}

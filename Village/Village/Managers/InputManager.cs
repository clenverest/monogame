using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System;

namespace Village;

public static class InputManager
{
    private static Vector2 direction;

    public static Vector2 Direction => direction;

    public static bool Moving => direction != Vector2.Zero;

    public static void Update()
    {
        var keyboard = Keyboard.GetState();
        direction = Vector2.Zero;

        if (keyboard.IsKeyDown(Keys.W) || keyboard.IsKeyDown(Keys.Up))
            direction.Y--;
        if (keyboard.IsKeyDown(Keys.S) || keyboard.IsKeyDown(Keys.Down))
            direction.Y++;
        if (keyboard.IsKeyDown(Keys.A) || keyboard.IsKeyDown(Keys.Left))
            direction.X--;
        if (keyboard.IsKeyDown(Keys.D) || keyboard.IsKeyDown(Keys.Right))
            direction.X++;

        if (keyboard.IsKeyUp(Keys.W) && keyboard.IsKeyUp(Keys.Up) && keyboard.IsKeyUp(Keys.S) && keyboard.IsKeyUp(Keys.Down))
            direction.Y = 0;
        if (keyboard.IsKeyUp(Keys.A) && keyboard.IsKeyUp(Keys.Left) && keyboard.IsKeyUp(Keys.D) && keyboard.IsKeyUp(Keys.Right))
            direction.X = 0;
    }
}

using System;
using Microsoft.Xna.Framework;

namespace Village;

public class Camera
{
    public Vector2 Position;
    public Matrix Transform { get; private set; }

    public float delay { get; set; } = 3.0f;

    public Camera(Vector2 position)
    {
        Position = position;
    }

    public void Update(Vector2 position, Game1 game)
    {
        var d = delay * Drawing.Delta;

        Position.X += ((position.X - Position.X) - Drawing.Width / 2) * d;
        Position.Y += ((position.Y - Position.Y) - Drawing.Height / 2) * d;

        Transform = Matrix.CreateTranslation(-Position.X, -Position.Y, 0);
    }

}

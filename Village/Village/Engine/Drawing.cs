using System;
using System.Globalization;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Village;

public static class Drawing
{
    public static GraphicsDeviceManager Graphics;
    public static SpriteBatch SpriteBatch;

    public static int Width { get; private set; }
    public static int Height { get; private set; }
    public static bool Vsync { get; private set; }

    public static Point DialogPosition { get; private set; }
    public static Point DialogSize { get; private set; }

    public static string Title = "The Village";

    public static float FPS, Delta, DeltaMilli;

    public static void Initialize(Game1 game)
    {
        Width = 1280;
        Height = 720;
        DialogPosition = new(40, 570);
        DialogSize = new(1200, 150);

        Graphics = new GraphicsDeviceManager(game);
        Graphics.PreferredBackBufferWidth = Width;
        Graphics.PreferredBackBufferHeight = Height;
        Graphics.SynchronizeWithVerticalRetrace = Vsync;
        Graphics.ApplyChanges();

        SpriteBatch = new SpriteBatch(game.GraphicsDevice);
    }

    public static void Update(GameTime gameTime, Game1 game)
    {
        Delta = (float)gameTime.ElapsedGameTime.TotalSeconds;
        FPS = (float)(1 / Delta);
        DeltaMilli = (float)gameTime.ElapsedGameTime.TotalMilliseconds;
    }

    public static void FillRect(Rectangle bounds, string path, Game1 game)
    {
        var texture = game.Content.Load<Texture2D>(path);
        SpriteBatch.Draw(texture, bounds, Color.White);
    }
}

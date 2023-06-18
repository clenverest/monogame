using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;

namespace Village;

public class Animation
{
    private readonly Texture2D texture;
    private readonly List<Rectangle> sourceRectangles = new();
    private readonly int frames;
    private int frame;
    private readonly float frameTime;
    private float frameTimeLeft;
    private bool isActive = true;

    public Animation(Game1 game, string path, int framesX, int framesY, float frameTime, int row = 1)
    {
        texture = game.Content.Load<Texture2D>(path);
        this.frameTime = frameTime;
        frameTimeLeft = this.frameTime;
        frames = framesX;
        var frameWidth = texture.Width / framesX;
        var frameHeight = texture.Height / framesY;

        for(int i = 0; i < frames; i++)
            sourceRectangles.Add(new Rectangle(i * frameWidth, (row - 1) * frameHeight, frameWidth, frameHeight));
    }

    public void Stop() { isActive = false; }

    public void Start() { isActive = true; }

    public void Resert()
    {
        frame = 0;
        frameTimeLeft = frameTime;
    }

    public void Update()
    {
        if(!isActive) return;

        frameTimeLeft -= Drawing.Delta;
        if(frameTimeLeft <= 0 )
        {
            frameTimeLeft += frameTime;
            frame = (frame + 1) % frames;
        }
    }

    public void Draw(Vector2 pos)
    {
        Drawing.SpriteBatch.Draw(
            texture, 
            pos, 
            sourceRectangles[frame], 
            Color.White, 
            0, 
            Vector2.Zero, 
            Vector2.One, 
            SpriteEffects.None, 
            1f);
    }
}

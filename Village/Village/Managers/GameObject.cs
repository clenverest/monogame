using System;
using Microsoft.Xna.Framework;


namespace Village;

public abstract class GameObject
{
    public float X, Y;
    public int Width, Height;

    public Vector2 Position 
    { 
        get { return new Vector2(X, Y); } 
        set
        {
            X = value.X;
            Y = value.Y;
        }
    }

    public Vector2 Size
    {
        get { return new Vector2(Width, Height); }
        set
        {
            Width = (int)value.X;
            Height = (int)value.Y;
        }
    }

    public Rectangle Bounds;
    public bool IsRendered, IsVisible;
    public bool IsActive;

    public Vector2 SpritePosition;

    public GameObject(int x, int y, int width, int height)
    {
        X = x;
        Y = y;
        Width = width;
        Height= height;
        Bounds = new Rectangle(x, y, width, height);

        IsActive = true;
        IsRendered= true;
        IsVisible = true;
        SpritePosition= new Vector2(0, 0);
    }

    public abstract void Initialize(Game1 game);
    public abstract void Destroy(Game1 game);
    public abstract void Update(Game1 game);
    public abstract void Draw(Game1 game);

    public void SetPosition (float x, float y)
    {
        X = x;
        Y = y;
    }

    public void SetSize(int width, int height)
    {
        Width = width;
        Height = height;
    }

    public void SetBounds(float x, float y, int width, int height)
    {
        Bounds = new Rectangle((int)x, (int)y, width, height);
    }

    public float DistanceTo(Vector2 position) => Vector2.Distance(Position, position);
    public Vector2 GetPositionCentered() => new Vector2(X + (Width / 2), Y + (Height / 2));
}

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Village;

class Tile
{
    protected Texture2D texture;
    Rectangle rectangle;

    public Rectangle Rectangle
    {
        get { return rectangle; }
        protected set { rectangle = value; }
    }

    static ContentManager content;
    public static ContentManager Content
    {
        protected get { return content; }
        set { content = value; }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        spriteBatch.Draw(texture, rectangle, Color.White);
    }
}

class CollisionTile : Tile
{
    public CollisionTile(int i, Rectangle rectangle)
    {
        texture = Content.Load<Texture2D>("Sprites\\Tiles\\Limiters\\Tile" + i);
        this.Rectangle = rectangle;
    }
}

class StandartTile : Tile
{
    public StandartTile(int i, Rectangle rectangle)
    {
        texture = Content.Load<Texture2D>("Sprites\\Tiles\\Ground\\Tile" + i);
        this.Rectangle = rectangle;
    }
}

class OverTile : Tile
{
    public OverTile(int i, Rectangle rectangle)
    {
        texture = Content.Load<Texture2D>("Sprites\\Tiles\\OverTiles\\Tile" + i);
        this.Rectangle = rectangle;
    }
}


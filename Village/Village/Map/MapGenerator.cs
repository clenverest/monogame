using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using System;
using System.Collections.Generic;


namespace Village;

class MapGenerator
{
    List<CollisionTile> collisionTiles = new();
    List<StandartTile> standartTiles = new();
    List<OverTile> overTiles = new();

    public List<CollisionTile> CollisionTiles
    {
        get { return collisionTiles; }
    }

    public List<StandartTile> StandartTiles
    {
        get { return standartTiles; }
    }

    int width, height;

    public int Width
    {
        get { return width; }
    }

    public int Height
    {
        get { return height; }
    }

    public MapGenerator()
    {

    }

    public void Generate(int[,] map, int size, Layers layer)
    {
        for(int x = 0; x < map.GetLength(1); x++)
            for(int y = 0; y < map.GetLength(0); y++)
            {
                var number = map[y, x];

                if(number > 0)
                {
                    if (layer == Layers.Normal)
                        standartTiles.Add(new StandartTile(number, new Rectangle(x * size, y * size, size, size)));
                    else if (layer == Layers.Collision)
                        collisionTiles.Add(new CollisionTile(number, new Rectangle(x * size, y * size, size, size)));
                    else
                        overTiles.Add(new OverTile(number, new Rectangle(x * size, y * size, size, size)));
                }

                width = (x + 1) * size; 
                height = (y + 1) * size; 
            }
    }

    public void Draw(SpriteBatch spriteBatch)
    {
        foreach (var tile in standartTiles)
            tile.Draw(spriteBatch);
        foreach (var tile in collisionTiles)
            tile.Draw(spriteBatch);
    }

    public void DrawOverLayer(SpriteBatch spriteBatch)
    {
        foreach(var tile in overTiles) 
            tile.Draw(spriteBatch);
    }
}

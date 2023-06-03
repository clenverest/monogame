using System;
using Microsoft.Xna.Framework;
using System.Collections.Generic;

namespace Village;

public class ObjectManager
{
    public List<GameObject> Objects = new List<GameObject>();
    public int Count => Objects.Count;
    public ObjectManager() { }

    public void Update(GameTime gameTime, Game1 game)
    {
        for(int i =0; i< Count; i++)
        {
            var obj = Objects[i];
            if (obj.IsRendered)
            {
                obj.SetBounds(obj.X, obj.Y, obj.Width, obj.Height);
                obj.Update(game);
            }
        }
    }

    public void Draw(Game1 game)
    {
        for (int i = 0; i < Count; i++)
        {
            var obj = Objects[i];
            if (obj.IsRendered && obj.IsVisible)
                obj.Draw(game);
        }
    }

    public void Add(GameObject obj, Game1 game)
    {
        Objects.Add(obj);
        obj.Initialize(game);
    }

    public void Clear() { Objects.Clear(); }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Village;

public class AnimationManager
{
    private readonly Dictionary<object, Animation> anims = new();

    private object lastKey;

    public void AddAnimation(object key, Animation animation)
    {
        anims.Add(key, animation);
        lastKey ??= key;
    }

    public void Update(object key)
    {
        if(anims.ContainsKey(key)) 
        {
            anims[key].Start();
            anims[key].Update();
            lastKey = key;
        }
        else
        {
            anims[lastKey].Stop();
            anims[lastKey].Resert();
        }
    }

    public void Draw(Vector2 position)
    {
        anims[lastKey].Draw(position);
    }
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Village;

public class TriggerManager
{
    public List<TriggerScene> scene = new();
    public int Count { get { return scene.Count; } }

    public TriggerManager() { }

    public void Update(Game1 game, Player player)
    {
        for (int i = 0; i < Count; i++)
        {
            var obj = scene[i];
                obj.Update(game, player);
        }
    }

    public void Draw(Game1 game)
    {
        for (int i = 0; i < Count; i++)
        {
            var obj = scene[i];
            obj.Draw(game);
        }
    }

    public void Add(TriggerScene obj, Game1 game)
    {
        scene.Add(obj);
        obj.Initialize(game);
    }

    public void Clear() { scene.Clear(); }
}

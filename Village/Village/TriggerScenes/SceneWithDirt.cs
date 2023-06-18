

using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;

namespace Village;

internal class SceneWithDirt : TriggerScene
{
    List<Dirt> dirts;

    public SceneWithDirt(Game1 game) : base(game) { }

    public override void Initialize(Game1 game)
    {
        dirts = new();
        dirts.Add(new(3972, 1278));
        dirts.Add(new(4332, 1203));
        dirts.Add(new(4483, 1431));
        dirts.Add(new(4268, 1558));
        dirts.Add(new(4103, 1586));
        dirts.Add(new(3774, 1195));
        dirts.Add(new(4007, 1294));
    }

    public override void Update(Game1 game, Player player)
    {
        var keyboard = Keyboard.GetState();

        for(int i = 0; i < dirts.Count; i++)
        {
            var dirt = dirts[i];
            if (player.Bounds.Intersects(dirt.Bounds))
            {
                if (keyboard.IsKeyDown(Keys.Space))
                {
                    player.Achievements.CleanDirt();
                    dirts.RemoveAt(i);
                }
            }
        }
    }

    public override void Draw(Game1 game)
    {
        foreach (var dirt in dirts)
            dirt.Draw(game);
    }
}

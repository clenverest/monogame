using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Content;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace Village;

public class Owl : GameObject
{
    public Owl(int x, int y) : base(x, y, 32, 32) { }

    private Animation anim;

    public override void Initialize(Game1 game)
    {
        anim = new(game, ObjectPath.Owl, 2, 1, 0.8f);
    }

    public override void Destroy(Game1 game) { }

    public override void Update(Game1 game)
    {
        anim.Update();
    }

    public override void Draw(Game1 game)
    {
        if(IsVisible)
            anim.Draw(Position);
    }
}

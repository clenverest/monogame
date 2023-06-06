using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Village;

public class Headman : GameObject
{
    private Animation anim;

    public Headman(int x, int y) : base(x, y, 64, 64)
    {
    }

    public override void Initialize(Game1 game)
    {
        anim = new(game, ObjectPath.Headman, 3, 1, 0.5f);
    }

    public override void Update(Game1 game)
    {
        anim.Update();
    }

    public override void Destroy(Game1 game)
    {
        
    }

    public override void Draw(Game1 game)
    {
        if (IsVisible)
            anim.Draw(Position);
    }

    
}

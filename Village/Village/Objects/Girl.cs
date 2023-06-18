using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Village;
public class Girl : GameObject
{
    public Animation Anim;

    public Girl(int x, int y) : base(x, y, 64, 64) { }

    public override void Initialize(Game1 game)
    {
        Anim = new(game, ObjectPath.Girl, 6, 1, 0.2f);
    }

    public override void Update(Game1 game)
    {
        Anim.Update();
    }

    public override void Destroy(Game1 game) { }

    public override void Draw(Game1 game)
    {
        if (IsVisible)
            Anim.Draw(Position);
    }
}



using Microsoft.Xna.Framework;

namespace Village;

public class Villagers : GameObject
{

    private Animation anim;
    public Villagers(int x, int y) : base(x, y, 128, 64) { }

public override void Initialize(Game1 game)
    {
        anim = new(game, ObjectPath.Villagers, 6, 1, 0.2f);
    }

    public override void Update(Game1 game)
    {
        anim.Update();
    }

    public override void Destroy(Game1 game) { }

    public override void Draw(Game1 game)
    {
        if (IsVisible)
            anim.Draw(Position);
    }
}

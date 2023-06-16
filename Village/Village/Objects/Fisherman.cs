

namespace Village;

public class Fisherman : GameObject
{
    private Animation anim;

    public Fisherman(int x, int y) : base(x, y, 128, 64)
    {
    }

    public override void Initialize(Game1 game)
    {
        anim = new(game, ObjectPath.Fisherman, 4, 1, 0.5f);
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

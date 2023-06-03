

using Microsoft.Xna.Framework;

namespace Village;

public class Ball : GameObject
{
    public Ball(int x, int y) : base(x, y, 32, 32)
    {
    }

    private Animation anim;

    public override void Initialize(Game1 game)
    {
        anim = new(game, ObjectPath.Ball, 2, 1, 0.5f);
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

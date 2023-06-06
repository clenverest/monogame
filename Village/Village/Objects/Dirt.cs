

using Microsoft.Xna.Framework;

namespace Village;

public class Dirt : GameObject
{
    public Dirt(int x, int y) : base(x, y, 32, 32)
    {
    }

    public override void Initialize(Game1 game)
    {
        
    }

    public override void Update(Game1 game)
    {
        
    }

    public override void Destroy(Game1 game)
    {
        
    }

    public override void Draw(Game1 game)
    {
        if (IsVisible)
            Drawing.FillRect(Bounds, ObjectPath.Dirt, game);
    }

    
}

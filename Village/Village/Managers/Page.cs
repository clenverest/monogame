using System;
using Microsoft.Xna.Framework;

namespace Village;

public abstract class Page
{
    public int ID;

    public Page(int id)
    {
        ID = id;
    }

    public abstract void Initialize(Game1 game);
    public abstract void LoadContent(Game1 game);
    public abstract void Update(GameTime gameTime, Game1 game);
    public abstract void Draw(Game1 game);
}

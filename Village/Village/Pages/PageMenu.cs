

using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Village;

public class PageMenu : Page
{
    public PageMenu() : base(PageID.Menu) { }

    public override void Initialize(Game1 game) { }

    public override void LoadContent(Game1 game) { }

    public override void Update(GameTime gameTime, Game1 game) { }

    public override void Draw(Game1 game)
    {
        Drawing.SpriteBatch.Begin();
        Drawing.FillRect(new(0, 0, Drawing.Width, Drawing.Height), GUIPath.Menu, game);
        Drawing.SpriteBatch.End();
    }
}

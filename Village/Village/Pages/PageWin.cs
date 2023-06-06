using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Village;

public class PageWin : Page
{
    public PageWin() : base(PageID.Win) { }

    public override void Draw(Game1 game)
    {
        Drawing.SpriteBatch.Begin();
        Drawing.FillRect(new(0, 0, Drawing.Width, Drawing.Height), GUIPath.Win, game);
        Drawing.SpriteBatch.End();
    }

    public override void Initialize(Game1 game) { }

    public override void LoadContent(Game1 game) { }

    public override void Update(GameTime gameTime, Game1 game) { }
}

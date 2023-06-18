using Microsoft.VisualBasic;
using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Village;

public abstract class TriggerScene
{
    public bool IsRendered, IsVisible;
    public bool IsActivated;

    public TriggerScene(Game1 game) { }

    public abstract void Initialize(Game1 game);
    public abstract void Update(Game1 game, Player player);
    public abstract void Draw(Game1 game);
}

using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Formats.Asn1.AsnWriter;

namespace Village;

public class SceneWithOwl : TriggerScene
{
    bool dialogIsActivated = false;

    Owl owl;
    private Rectangle triggerRectangle;

    Queue<string> owlDialog
    {
        get => new(new string[]
        {
            "Owl: Uwu-Uwu... \n <Press the Space bar to continue>",
            "Traveler: Argh, and there's this owl! Well, it's good that it's not green.",
            "Owl: Uwu!",
            "Traveler: I see..."
        });
    }

    public SceneWithOwl(Game1 game) : base(game)
    {

    }

    public override void Initialize(Game1 game)
    {
        triggerRectangle = new(2752, 576, 64, 64);
        owl = new(2752, 480);
        owl.Initialize(game);
    }

    public override void Update(Game1 game, Player player)
    {
        owl.Update(game);
        if (player.Bounds.Intersects(triggerRectangle) && !dialogIsActivated)
        {
            GameDialog.dialogs = owlDialog;
            GameDialog.IsActive = true;
            dialogIsActivated = true;
        }
    }

    public override void Draw(Game1 game) { owl.Draw(game); }
}

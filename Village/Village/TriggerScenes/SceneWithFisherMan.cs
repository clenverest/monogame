using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace Village;

public class SceneWithFisherMan : TriggerScene
{
    bool dialogIsActivated = false;
    private Rectangle triggerRectangle;

    Queue<string> dialog
    {
        get => new(new string[]
        {
            "Traveler: Oh, I see fishing gear! What? There's a fishing rod with a lifebuoy! Why is there a lifeline here at all? Okay, I can say that I were just lucky!",
            "Traveler: Knock-knock, is there anyone here?",
            "Fisherman: Yeah...",
            "Traveler: Oh, great! Can I borrow your fishing rod?",
            "Fisherman: Yeah.",
            "Traveler: Em... Thank you, you are very kind!",
            "Fisherman: Yeah..."
        });
    }

    public SceneWithFisherMan(Game1 game) : base(game)
    {
    }

    public override void Initialize(Game1 game)
    {
       triggerRectangle = new Rectangle(6848, 2688, 64, 32);
    }

    public override void Update(Game1 game, Player player)
    {
        if (player.Bounds.Intersects(triggerRectangle) && !dialogIsActivated)
        {
            GameDialog.dialogs = dialog;
            GameDialog.IsActive = true;
            dialogIsActivated = true;
            player.Inventory.TakeFishingRod();
        }
    }

    public override void Draw(Game1 game) { }

    
}

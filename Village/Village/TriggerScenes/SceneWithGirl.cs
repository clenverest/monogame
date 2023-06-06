using Microsoft.Xna.Framework;
using System.Collections.Generic;
using System.Threading;

namespace Village;

public class SceneWithGirl : TriggerScene
{
    Girl girl;
    private Rectangle triggerRectangle;

    bool dialog1IsActivated = false;
    bool dialog2IsActivated = false;
    bool dialog3IsActivated = false;

    int timeCount;
    static readonly int PERIOD = 15000;

    Queue<string> dialog1
    {
        get => new(new string[]
        {
            "Girl: *crying*",
            "Traveler: Girl, why are you crying so loudly?",
            "Girl: I dropped a ball in the river!",
            "Traveler: Hush, girl, don't cry! The ball will not drown in the river ...",
            "Girl: I know, but I need it!",
            "Girl: * crying*"
        });
    }

    Queue<string> dialog2
    {
        get => new(new string[]
        {
            "Girl: *crying*"
        });
    }

    Queue<string> dialog3
    {
        get => new(new string[]
        {
            "Traveler: Here, hold the ball.",
            "Girl: Whee, thank you very much! What can I do for you?",
            "Traveler: Don't cry for nothing anymore. That's all.",
            "Girl: My ball is not a trifle. But I still want to thank you. Here's a coin for you!",
            "Traveler: Thank you!"
        });
    }

    public SceneWithGirl(Game1 game) : base(game)
    {
    }

    public override void Initialize(Game1 game)
    {
        girl = new(928, 2373);
        triggerRectangle = girl.Bounds;
        girl.Initialize(game);
    }

    public override void Update(Game1 game, Player player)
    {
        girl.Update(game);
        if (player.Bounds.Intersects(triggerRectangle))
        {
            if (!dialog1IsActivated)
            {
                DoDialog(dialog1);
                dialog1IsActivated = true;
            }
            else if (!dialog2IsActivated && !player.Inventory.GotABall && !GameDialog.IsActive && timeCount > PERIOD)
            {
                DoDialog(dialog2);
                timeCount -= PERIOD;
            }
            else if (!dialog3IsActivated && player.Inventory.GotABall)
            {
                DoDialog(dialog3);
                dialog3IsActivated = true;
                player.Inventory.AddCoin();
            }
            timeCount += (int)Drawing.DeltaMilli;
        }
    }

    void DoDialog(Queue<string> dialog)
    {
        GameDialog.dialogs = dialog;
        GameDialog.IsActive = true;
    }

    public override void Draw(Game1 game) { girl.Draw(game); }
}

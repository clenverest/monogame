using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;
using System.Threading;

namespace Village;

public class SceneWithWell : TriggerScene
{
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
            "3 coins = 1 wish",
            "Traveler: Wow! It seems that inflation has touched this world as well.",
            "Traveler: What should I do? I need to ask the headman for advice."
        });
    }

    Queue<string> dialog2
    {
        get => new(new string[]
        {
            "3 coins = 1 wish"
        });
    }

    Queue<string> dialog3
    {
        get => new(new string[]
        {
            "Traveler: Yippee, finally I can get home! I will miss this Village... probably. Goodbye!"
        });
    }

    public SceneWithWell(Game1 game) : base(game)
    {
    }

    public override void Initialize(Game1 game)
    {
        triggerRectangle = new(6560, 704, 96, 64);
        timeCount = 0;
    }

    public override void Update(Game1 game, Player player)
    {
        if (player.Bounds.Intersects(triggerRectangle))
        {
            if (!dialog1IsActivated)
            {
                DoDialog(dialog1);
                dialog1IsActivated = true;
                player.Achievements.VisitWell();
            }
            else if (!dialog2IsActivated && !GameDialog.IsActive && timeCount > PERIOD)
            {
                DoDialog(dialog2);
                timeCount -= PERIOD;
            }
            else if (!dialog3IsActivated && player.Inventory.Coins == 3)
            {
                DoDialog(dialog3);
                dialog3IsActivated = true;
                player.Achievements.Win();
            }
            timeCount += (int)Drawing.DeltaMilli;
        }
    }

    void DoDialog(Queue<string> dialog)
    {
        GameDialog.dialogs = dialog;
        GameDialog.IsActive = true;
    }


    public override void Draw(Game1 game) { }


}

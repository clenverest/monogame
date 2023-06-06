using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Village;

public class SceneWithHeadman : TriggerScene
{
    Headman headman;
    private Rectangle triggerRectangle;
    bool dialog1IsActivated = false;
    bool dialog2IsActivated = false;
    bool dialog3IsActivated = false;

    Queue<string> dialog1
    {
        get => new(new string[]
        {
            "Headman: Greetings, Stranger! For what purpose did you come to our village?",
            "Traveler: Em... I don't know... I don't remember how I got here! How do I get out of here?",
            "Headman: Just come out?",
            "Traveler: I can't...",
            "Headman: I probably know what can help you. There is a wishing well across the river.",
            "Traveler: The wishing well? Hmm, it's worth a try. Thanks!",
            "Headman: You're welcome!"
        });
    }

    Queue<string> dialog2
    {
        get => new(new string[]
        {
            "Traveler: Why didn't you tell me that you need three coins for one wish?",
            "Headman: Hmm... Strange... A couple of days ago, one wish was worth one and a half coins.",
            "Traveler: Where can I get so many coins?",
            "Headman: You can complete the tasks of the villagers.",
            "Traveler: Good... Do you have a task for me?",
            "Headman: Let me think... Oh, yeah. You can clean up around the obelisks.",
            "Traveler: Great! So where are they?",
            "Headman: Find them yourself. And as soon as you clean up, come to me for payment.",
            "Traveler: Okay..."
        });
    }

    Queue<string> dialog3
    {
        get => new(new string[]
        {
            "Traveler: I've cleaned up the territory!",
            "Headman: Well done! Hold the coin! And good luck to you!",
            "Traveler: This is the way!"
        });
    }

    public SceneWithHeadman(Game1 game) : base(game)
    {
    }

    public override void Initialize(Game1 game)
    {
        headman = new(2976, 1792);
        triggerRectangle = headman.Bounds;
        headman.Initialize(game);
    }

    public override void Update(Game1 game, Player player)
    {
        headman.Update(game);
        if (player.Bounds.Intersects(triggerRectangle))
        {
            if (!dialog1IsActivated)
            {
                DoDialog(dialog1);
                dialog1IsActivated = true;
            }
            else if (!dialog2IsActivated && player.Achievements.WellIsVisited)
            {
                DoDialog(dialog2);
                dialog2IsActivated = true;
            }
            else if (!dialog3IsActivated && player.Achievements.CleanedDirt == 7)
            {
                DoDialog(dialog3);
                dialog3IsActivated = true;
                player.Inventory.AddCoin();
            }
        }
    }

    void DoDialog(Queue<string> dialog)
    {
        GameDialog.dialogs = dialog;
        GameDialog.IsActive = true;
    }

    public override void Draw(Game1 game) { headman.Draw(game); }

    
}

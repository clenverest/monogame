using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;
using System.Collections.Generic;


namespace Village;

public class SceneWithVillagers : TriggerScene
{
    bool dialog1IsActivated = false;
    bool dialog23IsActivated = false;

    Villagers villagers;
    private Rectangle triggerRectangle;

    Queue<string> dialog1
    {
        get => new(new string[]
        {
            "Butcher: And I'm telling you that a horse is better!",
            "Woodcutter: No, it's better a donkey!",
            "Butcher: Yes, your donkey is slow and sloppy, and the horse is fast and elegant.",
            "Woodcutter: Yes, there is so much fuss with your horse. But the donkey does not need much: he gave a carrot and he is ready to work!",
            "Butcher: Oh, you fool! You don't understand anything!",
            "Woodcutter: You don't understand!",
            "Butcher: Hey, Stranger, judge us.",
            "Traveler: Me?",
            "Woodcutter: Yes, you!",
            "<Press Z if you think the Horse is better>                         \n<Press X if you think Donkey is better>\n                     <Press the Space bar to confirm the answer>"
        });
    }

    Queue<string> dialog2
    {
        get => new(new string[]
        {
            "Traveler: I think the horse is better because I'm for speed and productivity!",
            "Butcher: Haha, I told you so!",
            "Woodcutter: What does he understand?",
            "Butcher: Apparently, a lot, unlike you!",
            "Butcher: You made me happy, Stranger! Here's a coin, I'm generous today.",
            "Traveler: Thank you!"
        });
    }

    Queue<string> dialog3
    {
        get => new(new string[]
        {
            "Traveler: I think donkey is better because I'm for convenience and simplicity!",
            "Woodcutter: Here, it's immediately obvious that a person understands this!",
            "Butcher: Yeah, of course, both of you are stupid!",
            "Woodcutter: Don't listen to him. For the fact that you supported me, I'll give you a coin!",
            "Traveler: Thank you very much!"
        });
    }

    Queue<string> dialog23;

    public SceneWithVillagers(Game1 game) : base(game)
    {
    }

    public override void Initialize(Game1 game)
    {
        villagers = new(3264, 3232);
        triggerRectangle = villagers.Bounds;
        dialog23 = dialog2;
        villagers.Initialize(game);
    }

    public override void Update(Game1 game, Player player)
    {
        villagers.Update(game);
        if (player.Bounds.Intersects(triggerRectangle))
        {
            var keyboard = Keyboard.GetState();
            if (keyboard.IsKeyDown(Keys.X))
                dialog23 = dialog3;
            else if (keyboard.IsKeyDown(Keys.Z))
                dialog23 = dialog2;

            if (!dialog1IsActivated)
            {
                DoDialog(dialog1);
                dialog1IsActivated = true;
            }
            else if (!dialog23IsActivated && !GameDialog.IsActive)
            {
                DoDialog(dialog23);
                dialog23IsActivated = true;
                player.Inventory.AddCoin();
            }

        }
    }

    void DoDialog(Queue<string> dialog)
    {
        GameDialog.dialogs = dialog;
        GameDialog.IsActive = true;
    }

    public override void Draw(Game1 game) { villagers.Draw(game); }
}

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
    static readonly int period = 5000;

    Queue<string> dialog1
    {
        get => new(new string[]
        {
            "Девочка: *плачет*",
            "Попаданец: Девочка, почему ты так громко плачешь?",
            "Девочка: Я уронила в речку мячик!",
            "Попаданец: Тише, Девочка, не плачь: не утонет в речке мяч...",
            "Девочка: Я знаю, но никто не может его мне достать!"
        });
    }

    Queue<string> dialog2
    {
        get => new(new string[]
        {
            "Девочка: *плачет*",
        });
    }

    Queue<string> dialog3
    {
        get => new(new string[]
        {
            "Попаданец: Вот твой мяч, держи!",
            "Девочка: Уии, спасибо тебе большое! Что я могу сделать для тебя?",
            "Попаданец: Просто не плачь больше по пустякам. Этого достаточно.",
            "Девочка: Мой мяч - не пустяк! Но все равно я хочу тебя отблагодарить. У меня есть для тебя монетка. Вот, держи!",
            "Попаданец: Хм, спасибо."
        });
    }

    public SceneWithGirl(Game1 game) : base(game) { }

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
            else if (!dialog2IsActivated && !player.Inventory.GotABall && !GameDialog.IsActive && timeCount > period)
            {
                DoDialog(dialog2);
                timeCount = 0;
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
        GameDialog.Dialogs = dialog;
        GameDialog.IsActive = true;
    }

    public override void Draw(Game1 game) { girl.Draw(game); }
}

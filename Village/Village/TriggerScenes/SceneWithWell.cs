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
    static readonly int period = 15000;

    Queue<string> dialog1
    {
        get => new(new string[]
        {
            "3 монетки = 1 желание",
            "Попаданец: Ничего себе! Кажется, инфляция добралась и до этого мира.",
            "Попаданец: Что же мне делать дальше? Нужно сходить к Старосте за советом."
        });
    }

    Queue<string> dialog2
    {
        get => new(new string[]
        {
            "3 монетки = 1 желание"
        });
    }

    Queue<string> dialog3
    {
        get => new(new string[]
        {
            "Попаданец: Ураа! Наконец-то я смогу выбраться отсюда! Наверное, я буду скучать по этому месту, а может и нет. Прощай!"
        });
    }

    public SceneWithWell(Game1 game) : base(game) { }

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
            else if (!dialog2IsActivated && !GameDialog.IsActive && timeCount > period)
            {
                DoDialog(dialog2);
                timeCount = 0;
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
        GameDialog.Dialogs = dialog;
        GameDialog.IsActive = true;
    }


    public override void Draw(Game1 game) { }
}

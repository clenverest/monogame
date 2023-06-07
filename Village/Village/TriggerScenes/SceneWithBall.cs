using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

namespace Village;

internal class SceneWithBall : TriggerScene
{
    Ball ball;
    bool dialog1IsActivated = false;
    bool dialog2IsActivated = false;
    private Rectangle triggerRectangle;

    Queue<string> dialog1
    {
        get => new(new string[]
        {
            "Попаданец: Слишком далеко! Нужно найти какой-нибудь предмет, который поможет мне достать мяч."
        });
    }

    Queue<string> dialog2
    {
        get => new(new string[]
        {
            "Попаданец: Да, он у меня!"
        });
    }

    public SceneWithBall(Game1 game) : base(game)
    {
    }

    public override void Initialize(Game1 game)
    {
        ball = new(5888, 1664);
        triggerRectangle = new(5760, 1632, 352, 96);
        ball.Initialize(game);
    }

    public override void Update(Game1 game, Player player)
    {
        ball.Update(game);
        if (player.Bounds.Intersects(triggerRectangle))
        {
            if (!dialog1IsActivated && !player.Inventory.GotAFishingRod)
            {
                DoDialog(dialog1);
                dialog1IsActivated = true;
            }
            else if (!dialog2IsActivated && player.Inventory.GotAFishingRod)
            {
                DoDialog(dialog2);
                dialog2IsActivated = true;
                player.Inventory.TakeBall();
                ball.IsVisible = false;
            }
        }
    }

    void DoDialog(Queue<string> dialog)
    {
        GameDialog.dialogs = dialog;
        GameDialog.IsActive = true;
    }

    public override void Draw(Game1 game) { ball.Draw(game); }
}

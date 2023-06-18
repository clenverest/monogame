using Microsoft.Xna.Framework;
using System;
using System.Collections.Generic;

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
            "Сова: Уву-Уву... \n <Нажмите Пробел, чтобы продолжить>",
            "Попаданец: Агрх, и тут эта сова! Но хорошо, что на этот раз она не зеленая.",
            "Сова: Уву!",
            "Попаданец: Согласен..."
        });
    }

    public SceneWithOwl(Game1 game) : base(game) { }

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
            GameDialog.Dialogs = owlDialog;
            GameDialog.IsActive = true;
            dialogIsActivated = true;
        }
    }

    public override void Draw(Game1 game) { owl.Draw(game); }
}

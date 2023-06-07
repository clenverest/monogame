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
            "Попаданец: О, кажется, я вижу рыболовные снасти!",
            "Попаданец: ЧТО? Тут есть удочка с привязанным к ней спасательным кругом? Откуда тут вообще взялся спасательный круг?! Хорошо, буду считать, что мне просто повезло!",
            "Попаданец: Тук-тук. Здесь кто-нибудь есть? Дайте знак!",
            "Рыбак: Ага...",
            "Попаданец: Оу, отлично! Могу я одолжить вашу удочку?",
            "Рыбак: Ага.",
            "Попаданец: Эм... Спасибо, вы очень добры!",
            "Рыбак: Ага..."
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

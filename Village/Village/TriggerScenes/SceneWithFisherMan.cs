using Microsoft.Xna.Framework;
using System.Collections.Generic;


namespace Village;

public class SceneWithFisherMan : TriggerScene
{
    Fisherman fisherman;
    bool dialogFishermanIsActivated = false;
    bool dialogHouseIsActivated = false;
    private Rectangle triggerRectangleFisherman;
    private Rectangle triggerRectangleHouse;

    Queue<string> dialogFisherman
    {
        get => new(new string[]
        {
            "Попаданец: Хмм... Этот рыбак выглядит очень... приветливо... Я думаю он сможет мне как-нибудь помочь.",
            "Попаданец: Кхм-кхм. Здравствуйте, дорогой товарищ Рыбак!",
            "Рыбак: Ага...",
            "Попаданец: Эээ, хорошо. Не могли бы вы одолжить мне удочку?",
            "Рыбак: Ага.",
            "Попаданец: Отлично! Тогда можно я возьму одну из ваших удочек у вашего дома?",
            "Рыбак: Ага.",
            "Попаданец: Спасибо, вы очень добры! Не буду вас больше отвлекать.",
            "Рыбак: Ага..."
        });
    }

    Queue<string> dialogHouse
    {
        get => new(new string[]
        {
            "Попаданец: О, кажется, я вижу рыболовные снасти!",
            "Попаданец: ЧТО? Тут есть удочка с привязанным к ней спасательным кругом? Откуда тут вообще взялся спасательный круг?! Хорошо, буду считать, что мне просто повезло!",
            "Попаданец: Все, снаряжение у меня!",
        });
    }

    public SceneWithFisherMan(Game1 game) : base(game)
    {
    }

    public override void Initialize(Game1 game)
    {
        fisherman = new(6840, 2530);
        triggerRectangleFisherman = fisherman.Bounds;
        fisherman.Initialize(game);
        triggerRectangleHouse = new Rectangle(6848, 2688, 64, 32);
    }

    public override void Update(Game1 game, Player player)
    {
        fisherman.Update(game);
        if (player.Bounds.Intersects(triggerRectangleFisherman) && !dialogFishermanIsActivated)
        {
            GameDialog.Dialogs = dialogFisherman;
            GameDialog.IsActive = true;
            dialogFishermanIsActivated = true;
        }

        if (player.Bounds.Intersects(triggerRectangleHouse) && dialogFishermanIsActivated && !dialogHouseIsActivated)
        {
            GameDialog.Dialogs = dialogHouse;
            GameDialog.IsActive = true;
            dialogHouseIsActivated = true;
            player.Inventory.TakeFishingRod();
        }
    }

    public override void Draw(Game1 game) { fisherman.Draw(game); }

    
}

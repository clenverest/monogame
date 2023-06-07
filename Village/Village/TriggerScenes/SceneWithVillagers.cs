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
            "Мясник: ... А я тебе говорю, что лощадь лучше!",
            "Дровосек: Нет, ишак лучше!",
            "Мясник: Да твой ишак тупой и медленный, а лошадь умная и быстрая.",
            "Дровосек: Ишак не тупой. Он простой и неприхотливый, в отличии от твоей лошади, с которой очень долго надо возиться, чтобы она начала работать!",
            "Мясник: Ага, конечно. Ничего ты не понимаешь!",
            "Дровосек: Это ты не понимаешь!",
            "Мясник: Хей, Чудила, рассуди нас.",
            "Попаданец: Я?",
            "Мясник: Да ты, кто же еще?",
            "<Нажмите Z, если Вы считаете, что Лошадь лучше>\n<Нажмите X, если Вы считаете, что Ишак лучше>\n               <Нажмите Пробел, чтобы подтвердить выбор>"
        });
    }

    Queue<string> dialog2
    {
        get => new(new string[]
        {
            "Попаданец: Я считаю, что лошадь лучше, потому что я за скорость и производительность!",
            "Мясник: Ха-ха, я же тебе говорил!",
            "Дровосек: Да что он понимает?",
            "Мясник: Очевидно, что поболее тебя!",
            "Мясник: Ты сделал меня счастливым, Чудила! Вот тебе монетка, я сегодня щедрый",
            "Попаданец: Спасибо!"
        });
    }

    Queue<string> dialog3
    {
        get => new(new string[]
        {
            "Попаданец: Я считаю, что ишак лучше, потому что я за удобство и простоту!",
            "Дровосек: Вот, сразу видно, что человек в этом разбирается!",
            "Мясник: Конечно, он же недалекий, как и твой ишак!",
            "Дровосек: Не слушай его. За то, что ты меня поддержал, я даю тебе монетку.",
            "Попаданец: Спасибо!"
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

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
            "Староста: Приветствую тебя, Незнакомец! Как ты оказался в нашей деревне?",
            "Попаданец: Эм... Я не знаю... Я не помню как очутился здесь! Как мне выбраться отсюда?",
            "Староста: Просто выйди?",
            "Попаданец: Я не могу...",
            "Староста: Наверное, я знаю как тебе помочь. За рекой есть колодец желаний. Он то тебе точно поможет.",
            "Попаданец: Колодец желаний? Хм, стоит попробовать. Спасибо!",
            "Староста: Всегда пожалуйста!"
        });
    }

    Queue<string> dialog2
    {
        get => new(new string[]
        {
            "Попаданец: Почему ты не сказал мне, что за одно желание колодец просит три монтеки?!",
            "Староста: Хм... Странно... Еще пару дней назад одно желание стоило полторы монетки.",
            "Попаданец: Где мне раздобыть такое богатство?",
            "Староста: Ты можешь выполнять задания жителей.",
            "Попаданец: Хорошо... А у тебя есть задание для меня?",
            "Староста: Дай-ка подумать... О, да. Ты можешь убраться вокруг обелисков.",
            "Попаданец: Отлично! Так где же мне их найти, и как убраться?",
            "Староста: Найди и догадайся сам! А как сделаешь работу, приходи ко мне за оплатой!",
            "Попаданец: Ладно..."
        });
    }

    Queue<string> dialog3
    {
        get => new(new string[]
        {
            "Попаданец: Я убрал территорию.",
            "Староста: Хорошая работа! Вот тебе монетка. И да пребудет с тобой Удача!",
            "Попаданец: Таков путь!"
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
        GameDialog.Dialogs = dialog;
        GameDialog.IsActive = true;
    }

    public override void Draw(Game1 game) { headman.Draw(game); }

    
}

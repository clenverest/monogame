﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Input;

namespace Village;

public class PageManager
{
    public List<Page> Pages = new();
    bool isStart = true;
    bool isGame = false;
    Page currientPage;

    public void Update(GameTime gameTime, Game1 game)
    {
        var keyboard = Keyboard.GetState();
        if (isStart)
        {
            currientPage = Pages[PageID.Menu];
            currientPage.Update(gameTime, game);
        }

        if(keyboard.IsKeyDown(Keys.Space) && !isGame)
        {
            isStart = false;
            isGame = true;
            currientPage = Pages[PageID.Game];
        }

        if(!isStart && game.PageGame.Player.Achievements.IsWin && !GameDialog.IsActive)
            currientPage = Pages[PageID.Win];

       currientPage.Update(gameTime, game);
    }

    public void Draw(Game1 game)
    {
        currientPage.Draw(game);
    }

    public void Add(Page page, Game1 game)
    {
        Pages.Add(page);
        page.Initialize(game);
    }
}

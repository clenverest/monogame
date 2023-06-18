using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Village;

public class Game1 : Game
{
    public PageManager PageManager = new();
    public PageGame PageGame = new();
    public PageMenu PageMenu = new();
    public PageWin PageWin = new();

    public Game1()
    {
        Drawing.Initialize(this);

        Content.RootDirectory = "Content";
    }

    protected override void Initialize()
    {
        IsMouseVisible = false;
        IsFixedTimeStep = false;
        Window.Title = Drawing.Title;

        PageManager.Add(PageMenu, this);
        PageManager.Add(PageGame, this);
        PageManager.Add(PageWin, this);

        GameDialog.Init(this);

        base.Initialize();
    }

    protected override void LoadContent()
    {
        // TODO: use this.Content to load your game content here
        PageMenu.LoadContent(this);
        PageGame.LoadContent(this);
        PageWin.LoadContent(this);
    }

    protected override void Update(GameTime gameTime)
    {
        if (GamePad.GetState(PlayerIndex.One).Buttons.Back == ButtonState.Pressed || Keyboard.GetState().IsKeyDown(Keys.Escape))
            Exit();

        // TODO: Add your update logic here
        PageManager.Update(gameTime, this);
        InputManager.Update();
        if(GameDialog.IsActive)
            GameDialog.Update();

        Drawing.Update(gameTime, this);
        //Window.Title = string.Format("X:{0}; Y:{1}", PageGame.player.X, PageGame.player.Y);
        Window.Title = "The Village";

        base.Update(gameTime);
    }

    protected override void Draw(GameTime gameTime)
    {
        GraphicsDevice.Clear(Color.CornflowerBlue);

        // TODO: Add your drawing code here
        PageManager.Draw(this);
        if (GameDialog.IsActive)
            GameDialog.Draw();

        base.Draw(gameTime);
    }
}
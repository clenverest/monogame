using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;

namespace Village;

public class PageGame : Page
{
    ObjectManager objectManager = new ObjectManager();
    TriggerManager triggerManager = new();
    public Player Player = new Player(1005, 660);
    Camera camera = new Camera(Vector2.Zero);
    MapGenerator mapGenerator;

    public PageGame() : base(PageID.Game)
    {

    }

    public override void Initialize(Game1 game)
    {
        mapGenerator = new MapGenerator();
        objectManager.Add(Player, game);
        triggerManager.Add(new SceneWithOwl(game), game);
        triggerManager.Add(new SceneWithFisherMan(game), game);
        triggerManager.Add(new SceneWithBall(game), game);
        triggerManager.Add(new SceneWithGirl(game), game);
        triggerManager.Add(new SceneWithHeadman(game), game);
        triggerManager.Add(new SceneWithWell(game), game);
        triggerManager.Add(new SceneWithDirt(game), game);
        triggerManager.Add(new SceneWithVillagers(game), game);
    }

    public override void LoadContent(Game1 game)
    {
        Tile.Content = game.Content;
        mapGenerator.Generate(Map.Layer0, 32, Layers.Normal);
        mapGenerator.Generate(Map.Layer1, 32, Layers.Collision);
        mapGenerator.Generate(Map.Layer2, 32, Layers.Over);
    }

    public override void Update(GameTime gameTime, Game1 game)
    {
        camera.Update(Player.GetPositionCentered(), game);

        CollisionMap(gameTime, game);
        triggerManager.Update(game, Player);
    }

    public void CollisionMap(GameTime gameTime, Game1 game)
    {
        var x = Player.X;
        var y = Player.Y;

        objectManager.Update(gameTime, game);

        foreach (var tile in mapGenerator.CollisionTiles)
        {
            if (Player.Hitbox.Intersects(tile.Rectangle))
            {
                var xOffset = Math.Min(
                    Math.Abs(Player.Hitbox.Left - tile.Rectangle.Right),
                    Math.Abs(Player.Hitbox.Right - tile.Rectangle.Left)
                );

                var yOffset = Math.Min(
                    Math.Abs(Player.Hitbox.Top - tile.Rectangle.Bottom),
                    Math.Abs(Player.Hitbox.Bottom - tile.Rectangle.Top)
                );

                if (xOffset < yOffset)
                {
                    if (tile.Rectangle.Intersects(GetNewHitbox()))
                        Player.X = x;
                }
                else
                {
                    if (tile.Rectangle.Intersects(GetNewHitbox()))
                        Player.Y = y;
                }

            }
        }
    }
    
    public override void Draw(Game1 game)
    {
        Drawing.SpriteBatch.Begin(transformMatrix: camera.Transform, samplerState: SamplerState.PointClamp);
        mapGenerator.Draw(Drawing.SpriteBatch);
        triggerManager.Draw(game);
        objectManager.Draw(game);
        mapGenerator.DrawOverLayer(Drawing.SpriteBatch);
        Drawing.SpriteBatch.End();
    }

    Rectangle GetNewHitbox()
    {
        var newVector = Player.Position + InputManager.Direction;
        var newPointWithOffset = new Point((int)(newVector.X + Player.Width / 4), (int)(newVector.Y + Player.Height / 2));
        var newSize = (Player.Size / 2).ToPoint();
        return new (newPointWithOffset, newSize);
    }
}

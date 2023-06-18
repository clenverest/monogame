using System;
using Microsoft.Xna.Framework;
using Microsoft.Xna.Framework.Graphics;
using Microsoft.Xna.Framework.Input;

namespace Village;

public class Player : GameObject
{
    public Player(int x, int y) : base(x, y, 64, 64) { }

    public float WalkSpeed = 150f;

    private readonly AnimationManager anims = new();

    public PlayerInventory Inventory;
    public Achievements Achievements;

    public override void Initialize(Game1 game)
    {
        anims.AddAnimation(new Vector2(0, 1), new(game, ObjectPath.Player, 9, 4, 0.1f, 3));
        anims.AddAnimation(new Vector2(0, -1), new(game, ObjectPath.Player, 9, 4, 0.1f, 1));
        anims.AddAnimation(new Vector2(1, 0), new(game, ObjectPath.Player, 9, 4, 0.1f, 4));
        anims.AddAnimation(new Vector2(-1, 0), new(game, ObjectPath.Player, 9, 4, 0.1f, 2));
        anims.AddAnimation(new Vector2(1, 1), new(game, ObjectPath.Player, 9, 4, 0.1f, 4));
        anims.AddAnimation(new Vector2(-1, -1), new(game, ObjectPath.Player, 9, 4, 0.1f, 2));
        anims.AddAnimation(new Vector2(-1, 1), new(game, ObjectPath.Player, 9, 4, 0.1f, 2));
        anims.AddAnimation(new Vector2(1, -1), new(game, ObjectPath.Player, 9, 4, 0.1f, 4));
        Inventory = new();
        Achievements = new();
    }

    public override void Destroy(Game1 game) { }

    public override void Update(Game1 game)
    {
        if (!GameDialog.IsActive)
        {
            var speed = WalkSpeed * Drawing.Delta;

            if (InputManager.Moving)
            {
                X += InputManager.Direction.X * speed;
                Y += InputManager.Direction.Y * speed;
            }

            anims.Update(InputManager.Direction);
        }
        else
            anims.Update(Vector2.Zero);
    }

    public override void Draw(Game1 game)
    {
        anims.Draw(Position);
    }
}

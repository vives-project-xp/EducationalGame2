using System.Drawing;
using Godot;
partial class Bird : Sprite2D
{
    public override void _Ready()
    {
        Name = "Bird";
        Texture = GD.Load<Texture2D>("res://assets/industrial/bomb.png");
        Scale = new Vector2(0.1f, 0.1f);
        Position = new Vector2(100, 100);
    }
    public float Gravity = 0.5f;
    public float JumpForce = -500;
    public float Velocity = 0;
    public enum BirdEnumStates
    {
        Falling,
        Jumping,
        Dead
    }
    public BirdEnumStates State = BirdEnumStates.Falling;

    public void Die()
    {
        State = BirdEnumStates.Dead;
    }

    public void Jump()
    {
        Velocity = JumpForce;
        State = BirdEnumStates.Jumping;
    }

    public override void _Process(double delta)
    {
        
        if (State == BirdEnumStates.Dead) return;
        foreach (var tree in GetTree().GetNodesInGroup("Tree"))
        {
            if (tree is Tree treeSprite)
            {
                Rect2 treeRect = new Rect2(treeSprite.Position - treeSprite.GetRect().Size / 2, treeSprite.GetRect().Size * treeSprite.Scale);
                if (treeRect.Intersects(GetTrueRect()))
                {
                    Die();
                }
            }
        }
        if(Position.Y > GetWindowScreenSize().Y - GetBirdSize().Y / 2 || Position.Y < 0 + GetBirdSize().Y / 2)   
        {
            Die();
        }
        Velocity += Gravity;
        Position += new Vector2((float)delta * 120, Velocity * (float)delta);
    }
    public Vector2 GetBirdSize()
    {
        return GetRect().Size * Scale;
    }
    public Rect2 GetTrueRect()
    {
        return new Rect2(Position - GetBirdSize() / 2, GetBirdSize());
    }
    public Vector2 GetWindowScreenSize()
    {
        return GetViewportRect().Size;
    }

    public override void _Input(InputEvent @event)
    {
        if (State == BirdEnumStates.Dead) return;
        if (@event.IsActionPressed("ui_click")) Jump();
    }
}
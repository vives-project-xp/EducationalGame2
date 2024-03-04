using Godot;
partial class Bird : Sprite2D
{
    public float Velocity = 0;
    public float Gravity = 0.5f;
    public float Jump = -8;
    public bool IsDead = false;
    public bool IsJumping = false;
    public override void _Ready()
    {
        Texture = GD.Load<Texture2D>("res://assets/industrial/bomb.png");
        Scale = new Vector2(0.1f, 0.1f);
        Position = new Vector2(100, 300);
    }
    public override void _Process(double delta)
    {
        if (IsDead) return;
        Velocity = Gravity;
        Position += new Vector2(0, Velocity);
        if (Position.Y > 1080)
        {
            IsDead = true;
        }
    }
    public void Jumping()
    {
        if (IsDead) return;
        Velocity = Jump;
    }
    // get click event
    public override void _Input(InputEvent @event)
    {
        if(@event.IsActionPressed("click"))
        {
            Jumping();
        }
    }
    private bool isJumping = false;
    public void Reset()
    {
        Position = new Vector2(100, 300);
        IsDead = false;
    }
    public void Die()
    {
        IsDead = true;
    }
}
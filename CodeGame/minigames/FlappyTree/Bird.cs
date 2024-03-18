using System.Linq;
using Godot;
partial class Bird : Sprite2D
{
    public double prevFlap = 0;
    public double curFlap = 0;

    public double flapTime = 0.2;
    // Called when the node enters the scene tree for the first time.
    // state of the bird (start, falling, jumping, dead) start is the default state
    public BirdEnumStates State = BirdEnumStates.Start;
    public float Gravity = 2.2f;
    public float JumpForce = -250;
    public float Velocity = 0;
    public float speed = 150;
    public int currentRegion = 0;

    public enum BirdEnumStates
    {
        Start,
        Falling,
        Jumping,
        Dead
    }
    public override void _Ready()
    {
        Name = "Bird";
        Texture = GD.Load<Texture2D>("res://assets/Forest/Bird.png");
        // split the texture into 3 frames horizontally
        Scale = new Vector2(0.1f, 0.1f);
        Position = new Vector2(100, 300);
        RegionEnabled = true;
        RegionRect = new Rect2(23, 274, 858, 524);

    }

    public override void _Process(double delta)
    {
        // block movement if the bird is dead
        if (State == BirdEnumStates.Dead || State == BirdEnumStates.Start) return;
        State = BirdEnumStates.Falling;
        curFlap += delta;
        Velocity += Gravity;
        Position += new Vector2(0, Velocity * (float)delta);
        GoRight((float)delta);
        Tilt((float)delta);

        if (curFlap - prevFlap > flapTime)
        {
            Flap();
            prevFlap = curFlap;
        }
        CheckBounds();
        CheckCollisions();

    }


    public void GoRight(float delta)
    {
        // continuous movement to the right if the bird is not in the start state
        Position += new Vector2(speed * delta, 0);
    }

    public void Tilt(float delta)
    {
        // tilt the bird
        RotationDegrees = Mathf.Lerp(RotationDegrees, Mathf.Clamp(Velocity * 3, -45, 70), 2.5f * delta);
    }

    public void CheckBounds()
    {
        // screen bounds
        if (collidesWithWindow()) Die();
    }
    public bool collidesWithWindow() => Position.Y + GetBirdSize().Y / 2 > GetWindowScreenSize().Y || Position.Y - GetBirdSize().Y / 2 < 0;

    // jump
    public void Jump()
    {
        Velocity = JumpForce * Gravity;
        State = BirdEnumStates.Jumping;
    }

    // kill the bird
    public void Die() => State = BirdEnumStates.Dead;

    public void CheckCollisions()
    {
        // check if the bird collides with a tree that is in the group "Tree"
        foreach (Tree tree in GetTree().GetNodesInGroup("Tree").Cast<Tree>()) if (tree.GetTrueRect().Intersects(GetTrueRect())) Die();
    }


    // input of the user
    public override void _Input(InputEvent @event)
    {
        // block input if the bird is dead
        if (State == BirdEnumStates.Dead) return;
        // jump on click
        if (@event.IsActionPressed("ui_click")) Jump();
    }

    public void Flap()
    {
        // change the frame of the bird by using region rect
        switch (currentRegion)
        {
            case 0:
                RegionRect = new Rect2(23, 274, 858, 524);
                break;
            case 1:
                RegionRect = new Rect2(915.8f, 280.3f, 789.8f, 254.1f);
                break;
            case 2:
                RegionRect = new Rect2(1737.27f, 4.1f, 789.56f, 563.56f);
                break;
        }
        currentRegion = (currentRegion + 1) % 3;
    }


    // helper methods
    public Vector2 GetBirdSize() => GetRect().Size * Scale;
    public Rect2 GetTrueRect() => new(Position - GetBirdSize() / 2, GetBirdSize());
    public Vector2 GetWindowScreenSize() => GetViewportRect().Size;
}
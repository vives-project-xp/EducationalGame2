using System.Diagnostics;
using System.Linq;
using Godot;
partial class Bird : Sprite2D
{
    public double prevFlap = 0;
    public double curFlap = 0;

    public double flapTime = 0.2;
    // Called when the node enters the scene tree for the first time.
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
    // gravity
    public float Gravity = 1.5f;
    // force of the jump
    public float JumpForce = -500;

    // velocity of the bird
    public float Velocity = 0;
    // speed of the bird
    public float speed = 200;

    // state of the bird (start, falling, jumping, dead) start is the default state
    public enum BirdEnumStates
    {
        Start,
        Falling,
        Jumping,
        Dead
    }

    public int currentRegion = 0;

    // state of the bird (start, falling, jumping, dead) start is the default state
    public BirdEnumStates State = BirdEnumStates.Start;


    public override void _Process(double delta)
    {
        // block movement if the bird is dead
        if (State == BirdEnumStates.Dead || State == BirdEnumStates.Start) return;
        curFlap += delta;

        // up and down
        if (State == BirdEnumStates.Jumping)
        {
            // add gravity to the bird
            Velocity += Gravity;
            Position += new Vector2(0, Velocity * (float)delta);
            // tilt the bird upwards
            Rotation = Mathf.Lerp(Rotation, -0.75f, (float)delta * 500);
            State = BirdEnumStates.Falling;

        }
        // if the bird is falling
        else
        {
            // add gravity to the bird
            Velocity += Gravity;
            Position += new Vector2(0, Velocity * (float)delta);
            // tilt the bird downwards
            Rotation = Mathf.Lerp(Rotation, 1f, (float)delta);
        }

        // move to the right
        GoRight((float)delta);
        // check the bounds of the bird
        CheckBounds();
        // check the collisions of the bird
        CheckCollisions();
        // change the frame of the bird per half a second
        if (curFlap - prevFlap > flapTime)
        {
            Flap();
            prevFlap = curFlap;
        }
    }


    public void GoRight(float delta)
    {
        // continuous movement to the right if the bird is not in the start state
        if (State != BirdEnumStates.Start) Position += new Vector2(speed * delta, 0);
    }

    public void CheckBounds()
    {
        // screen bounds
        if (Position.Y + GetBirdSize().Y / 2 > GetWindowScreenSize().Y || Position.Y - GetBirdSize().Y / 2 < 0) Die();
    }

    // jump
    public void Jump()
    {
        // add velocity to the bird
        Velocity = JumpForce;

        // change the state of the bird to jumping
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

    // get the size of the bird
    public Vector2 GetBirdSize() => GetRect().Size * Scale;
    // get the true size of the bird
    public Rect2 GetTrueRect() => new(Position - GetBirdSize() / 2, GetBirdSize());

    // get the size of the window
    public Vector2 GetWindowScreenSize() => GetViewportRect().Size;


}
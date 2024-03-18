using Godot;
partial class WaterDrip : Sprite2D
{
    public double currentRotationSec = 0;
    public double rotatingspeed = 1.5;
    public bool hit = false;

    public WaterDrip(float x_pos)
    {
        Position = new Vector2(x_pos, 0);
    }
    public override void _Ready()
    {
        AddToGroup("WaterDrip");
        Texture = GD.Load<Texture2D>("res://assets/Forest/WaterDrip.png");
        Camera2D camera = GetNode<BirdCam>("/root/Flappy/BirdCam");
        Position = new Vector2(Position.X, camera.GetViewportRect().Size.Y / 2);
    }
    public override void _Process(double delta)
    {
        currentRotationSec += delta * rotatingspeed;
        // use scale x to make it look like the water is rotating around its center make it go from -1 to 1 and back
        Scale = new Vector2(Mathf.Sin((float)currentRotationSec), .7f);
        CheckCollisions();
    }
    // check if bird collides with the water
    public void CheckCollisions()
    {
        if (GetNode<Bird>("/root/Flappy/Bird").GetTrueRect().Intersects(GetTrueRect()) && Visible)
        {
            Visible = false;
            hit = true;
            Flappy flappy = GetParent<Flappy>();
            flappy.points++;
        }
    }
    public Rect2 GetTrueRect() => new(Position - GetRect().Size / 2, GetRect().Size);
}
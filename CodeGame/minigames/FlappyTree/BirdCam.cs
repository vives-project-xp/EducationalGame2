using Godot;
partial class BirdCam : Camera2D
{
    public override void _Ready()
    {
        Name = "BirdCam";
        // Set the camera to follow the bird
        AnchorMode = AnchorModeEnum.FixedTopLeft;

    }
    public override void _Process(double delta)
    {
        Bird bird = GetNode<Bird>("/root/Flappy/Bird");
        // follow the bird
        Position = new(bird.Position.X - 200, Position.Y);
    }
}
using Godot;
partial class BirdCam : Camera2D
{
    public bool Current;
    public override void _Ready()
    {
        Current = true;
        // Set the camera to follow the bird
        AnchorMode = AnchorModeEnum.FixedTopLeft;
    
    }
    public override void _Process(double delta)
    {
        if (GetViewport().GetNode<Bird>("/root/Flappy/Bird") is Bird bird)
        {
            Position = new Vector2(bird.Position.X - 200, 0);
        }
    }
}
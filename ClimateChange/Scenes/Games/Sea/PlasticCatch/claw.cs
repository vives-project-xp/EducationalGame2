using Godot;
partial class Claw : Sprite2D
{
    public override void _Ready()
    {
        Name = "Claw";
        Texture = GD.Load<Texture2D>("res://Scenes/Games/Sea/PlasticCatch/Assets/claws.png");
        Hframes = 2;
        RegionEnabled = true;
        RegionRect = new Rect2(103.5f, 353.75f, 2246.879f, 811.4f);
        Frame = 0;
        Scale = new Vector2(0.085f, 0.085f);
    }
    public void nextFrame() => Frame = Frame == 0 ? 1 : 0;
    public override void _PhysicsProcess(double delta) => Position = GetGlobalMousePosition() + new Vector2(0, 30);
}
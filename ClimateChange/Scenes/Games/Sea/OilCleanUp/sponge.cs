using Godot;
public partial class Sponge : Sprite2D
{
    public int Damage { get; set; } = 1;

    public override void _Ready()
    {
        Name = "Sponge";
        // set the texture of the oil
        Texture = GD.Load<Texture2D>("res://Scenes/Games/Sea/OilCleanUp/Assets/sponge.png");
        RegionEnabled = true;
        RegionRect = new Rect2(5f, 5f, 606f, 706f);
        // set size of sponge
        Scale = new Vector2(0.2f, 0.2f);
    }

    //sponge will follow the cursor
    public override void _PhysicsProcess(double delta) => Position = GetGlobalMousePosition() + new Vector2(0, 30);
}
using Godot;
partial class WaterDrip : Sprite2D
{
    public override void _Ready()
    {
        Texture = GD.Load<Texture2D>("res://assets/Forest/WaterDrip.png");
        Position = new Vector2(100, 100);
    }
    public override void _Process(double delta)
    {
        // rotate the water drip over time
    }
}
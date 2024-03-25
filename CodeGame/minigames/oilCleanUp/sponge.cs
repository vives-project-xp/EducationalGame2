using Godot;
using System;

public partial class Sponge : Sprite2D
{
    public int Damage { get; set; } = 1;
    
        public override void _Ready()
    {
        Name = "Sponge";
        Texture = GD.Load<Texture2D>("res://assets/Sea/Sea_sponge.png");
        RegionEnabled = true;
        RegionRect = new Rect2(5f, 5f, 606f, 706f);
        Scale = new Vector2(0.2f, 0.2f);
    }
    //sponge will follow the mouse
    public override void _PhysicsProcess(double delta) => Position = GetGlobalMousePosition() + new Vector2(0, 30);
}
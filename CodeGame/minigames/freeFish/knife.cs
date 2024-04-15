using Godot;
using System;

public partial class Knife : Sprite2D
{
        public override void _Ready()
    {
        Name = "Knife";
        // set the texture of the oil
        Texture = GD.Load<Texture2D>("res://assets/Sea/Scissors.png");
        RegionEnabled = true;
        RegionRect = new Rect2(5f, 5f, 587f, 321f);
        // set size of sponge
        Scale = new Vector2(0.2f, 0.2f);
    }
    
    //sponge will follow the cursor
    public override void _PhysicsProcess(double delta) => Position = GetGlobalMousePosition() + new Vector2(0, 30);
}
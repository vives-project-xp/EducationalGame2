using Godot;
using System;

public partial class Sponge : Sprite2D
{
    private const int damage = 1;
    
        public override void _Ready()
    {
        Name = "Sponge";
        Texture = GD.Load<Texture2D>("res://assets/Sea/Sea_sponge.png");
        RegionEnabled = true;
        RegionRect = new Rect2(5f, 5f, 606f, 706f);
        Scale = new Vector2(0.2f, 0.2f);
    }

    public override void _PhysicsProcess(double delta) => Position = GetGlobalMousePosition() + new Vector2(0, 30);
    
    /*    private void OnBodyShapeEntered(int bodyID, Node body, int bodyShapeIndex, int LocalShapeIndex)
    {
       if (body is Oil part1)
        {
            
            part1.DecreaseHealth(damage);
            if (part1.Health <= 0)
            {
                part1.QueueFree();
            }
        }
    }*/
}
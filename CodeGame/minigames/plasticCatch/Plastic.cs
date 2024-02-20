using Godot;
using System;
using System.Collections.Generic;
partial class Plastic : Sprite2D
{
    public override void _Ready()
    {
        Name = "Plastic";
        AddToGroup("Plastic");
        // set the texture of the plastic			
        Texture = GD.Load<Texture2D>(PlayerHandler.GetRandomElement(new List<String> { "res://assets/Sea/beker_plastic.png", "res://assets/Sea/bottle_plastic.png", "res://assets/Sea/can_plastic.png" }));
        RegionEnabled = true;
        RegionRect = new Rect2(960, 505, 650, 500);
        // set the position of the plastic
        float xSize = GetViewport().GetVisibleRect().Size.X;
        float ySize = GetViewport().GetVisibleRect().Size.Y;
        Position = new Vector2((float)GD.RandRange(xSize * 0.1, xSize * 0.9), (float)GD.RandRange(ySize / 2, ySize * 0.9));
        Scale = new Vector2(0.1f, 0.1f);
    }

}
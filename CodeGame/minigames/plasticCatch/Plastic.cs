using Godot;
using System;
using System.Collections.Generic;
partial class Plastic : Sprite2D
{
    private float randomXRange = (float)GD.RandRange(0.1, 0.9);
    private float randomYRange = (float)GD.RandRange(0.5, 0.9);
    public override void _Ready()
    {
        Name = "Plastic";
        AddToGroup("Plastic");
        // set the texture of the plastic			
        Texture = GD.Load<Texture2D>(PlayerHandler.GetRandomElement(new List<String> { "res://assets/Sea/beker_plastic.png", "res://assets/Sea/bottle_plastic.png", "res://assets/Sea/can_plastic.png" }));
        // set the position of the plastic
        float xSize = GetViewport().GetVisibleRect().Size.X;
        float ySize = GetViewport().GetVisibleRect().Size.Y;
        Position = new Vector2(xSize * randomXRange, ySize * randomYRange);
        Scale = new Vector2(0.1f, 0.1f);
    }
    public override void _Process(double delta)
    {
        // update the position of the plastic on the viewport when the viewport size changes
        float xSize = GetViewport().GetVisibleRect().Size.X;
        float ySize = GetViewport().GetVisibleRect().Size.Y;
        Position = new Vector2(xSize * randomXRange, ySize * randomYRange);
        Scale = new Vector2(200 / xSize, 150 / ySize);

    }
    // update the position of the plastic on the viewport when the viewport size changes


}
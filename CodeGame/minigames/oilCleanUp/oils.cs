using Godot;
using System;
using System.Collections.Generic;

partial class Oil : Sprite2D
{
    private float randomXRange = (float)GD.RandRange(0.1, 0.9);
	private float randomYRange = (float)GD.RandRange(0.5, 0.9);
    public override void _Ready()
	{
		Name = "Oil";
		AddToGroup("Oils");
		// set the texture of the oil
		Texture = GD.Load<Texture2D>(PlayerHandler.GetRandomElement(new List<string> { "res://assets/Sea/Sea_oil1.png", "res://assets/Sea/Sea_oil2.png", "res://assets/Sea/Sea_oil3.png" }));
		// set the position of the oil
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
}
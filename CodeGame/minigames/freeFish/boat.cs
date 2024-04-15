using Godot;
using System;
using System.Collections.Generic;

partial class Boat : Sprite2D
{
    private float randomXRange = (float)GD.RandRange(0.1, 0.8);
	private float randomYRange = (float)GD.RandRange(0.2, 0.8);

    public override void _Ready()
	{
		Name = "Boats";
		AddToGroup("Boats");
		// set the texture of the boat
		Texture = GD.Load<Texture2D>("res://assets/Sea/Sea_fishersboat.png");
		// set the position of the boat
		float xSize = GetViewport().GetVisibleRect().Size.X;
		float ySize = GetViewport().GetVisibleRect().Size.Y;
		Position = new Vector2(xSize * randomXRange, ySize * randomYRange);
		//set the size of the boat
		Scale = new Vector2(0.3f, 0.3f);
	}
    
    public Rect2 GetTrueRect() => new(Position, Texture.GetSize() * Scale);
}
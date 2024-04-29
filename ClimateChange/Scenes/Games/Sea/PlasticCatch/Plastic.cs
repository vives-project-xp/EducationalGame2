using Godot;
using System.Collections.Generic;
partial class Plastic : Sprite2D
{
	private double sec, prevsec;
	private float randomXRange = (float)GD.RandRange(0.1, 0.9);
	private float randomYRange = (float)GD.RandRange(0.5, 0.9);

	
	public override void _Ready()
	{
		Name = "Plastic";
		AddToGroup("Plastic");
		// set the texture of the plastic
		Texture = GD.Load<Texture2D>(PlayerHandler.GetRandomElement(new List<string> { "res://Scenes/Games/Sea/PlasticCatch/Assets/cans.png", "res://Scenes/Games/Sea/PlasticCatch/Assets/bottles.png", "res://Scenes/Games/Sea/PlasticCatch/Assets/cups.png" }));
		// set the position of the plastic
		float xSize = GetViewport().GetVisibleRect().Size.X;
		float ySize = GetViewport().GetVisibleRect().Size.Y;
		Position = new Vector2(xSize * randomXRange, ySize * randomYRange);
		Scale = new Vector2(0.1f, 0.1f);
		// animation of plastic
		Hframes=2;
		Frame = 0;
	}
	public override void _Process(double delta)
	{
		sec += delta;

		// update the position of the plastic on the viewport when the viewport size changes
		float xSize = GetViewport().GetVisibleRect().Size.X;
		float ySize = GetViewport().GetVisibleRect().Size.Y;
		Position = new Vector2(xSize * randomXRange, ySize * randomYRange);
		Scale = new Vector2(200 / xSize, 150 / ySize);
		
		NextFrame();
		
	}
	public Rect2 GetTrueRect() => new(Position, Texture.GetSize() * Scale);
	public void NextFrame()
	{
		if(sec - prevsec > 0.5)
		{
			prevsec = sec;
			Frame = Frame == 0 ? 1 : 0;
		}
	}
}

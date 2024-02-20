using System;
using System.Collections.Generic;
using Godot;
public partial class PlasticCatch : Node2D
{
	private Claw claw { get; set; } = new();
	private ClawForMobile clawForMobile { get; set; } = new();
	private Rope rope { get; set; } = new();
	private double prevsec = 0;
	private double sec = 0;
	public override void _Ready()
	{
		for (int i = 0; i < 50; i++) AddChild(new Plastic());
		switch (OS.GetName())
		{
			case "Android":
				AddChild(clawForMobile);
				break;
			case "iOS":
				AddChild(clawForMobile);
				break;
			default:
				AddChild(claw);
				break;
		}
		AddChild(rope);
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void CheckCollision()
	{
		if (claw != null || clawForMobile != null)
		{
			foreach (Plastic plastic in GetTree().GetNodesInGroup("Plastic"))
			{
				Rect2 clawRect = claw != null ? claw.GetGlobalTransform() * claw.GetRect() : clawForMobile.GetGlobalTransform() * clawForMobile.GetRect();
				Rect2 plasticRect = plastic.GetGlobalTransform() * plastic.GetRect();
				if (clawRect.Intersects(plasticRect)) plastic.QueueFree();
			}
		}
	}
	public void FinishedMinigame()
	{
		if (GetTree().GetNodesInGroup("Plastic").Count == 0)
		{
			if (clawForMobile != null) clawForMobile.QueueFree();
			else claw.QueueFree();
			foreach (Plastic plastic in GetTree().GetNodesInGroup("Plastic")) plastic.QueueFree();
			GetTree().ChangeSceneToFile("res://World/World.tscn");
		}
	}
	public override void _Process(double delta)
	{
		sec += delta;
		if (sec - prevsec > 0.5)
		{
			prevsec = sec;
			if (claw != null) claw.nextFrame();
		}

		float _t = (float)delta * 4f;
		Vector2 mousePos = GetGlobalMousePosition();
		if (claw != null) claw.Position = claw.Position.Lerp(mousePos, _t);
		else clawForMobile.Position = clawForMobile.Position.Lerp(mousePos, _t);
		if (GetTree().GetNodesInGroup("Plastic").Count > 0) CheckCollision();
		else FinishedMinigame();

	}
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
	partial class Claw : Sprite2D
	{
		public override void _Ready()
		{
			Name = "Claw";
			Texture = GD.Load<Texture2D>("res://assets/Sea/claws.png");
			Hframes = 2;
			RegionEnabled = true;
			RegionRect = new Rect2(103.5f, 353.75f, 2246.879f, 811.4f);
			Frame = 0;
			Scale = new Vector2(0.085f, 0.085f);
		}

		public void nextFrame()
		{
			Frame = Frame == 0 ? 1 : 0;
		}
	}

	partial class ClawForMobile : TouchScreenButton
	{
		public override void _Ready()
		{
			Name = "clawForMobile";
			// set the texture of the claw
			TextureNormal = GD.Load<Texture2D>("res://assets/Sea/claws.png");
			// set the position of the claw
			float xSize = GetViewport().GetVisibleRect().Size.X;
			float ySize = GetViewport().GetVisibleRect().Size.Y;
			Position = new Vector2(xSize / 2, ySize / 8);
			// set the scale of the claw
			Scale = new Vector2(0.1f, 0.1f);
		}
		public Rect2 GetRect()
		{
			return new Rect2(Position, TextureNormal.GetSize() * Scale);
		}
	}
	partial class Rope: TextureRect
	{
		public override void _Ready()
		{
			Texture = GD.Load<Texture2D>("res://assets/Sea/line_plastic.png");
			float xSize = GetViewport().GetVisibleRect().Size.X;
			float ySize = GetViewport().GetVisibleRect().Size.Y;
			Position = new Vector2(xSize / 2, ySize / 8);
		}
	}
}

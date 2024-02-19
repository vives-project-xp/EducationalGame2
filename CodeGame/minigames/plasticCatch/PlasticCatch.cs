using System.Runtime.InteropServices;
using System.Security.Cryptography.X509Certificates;
using System.Text.RegularExpressions;
using Godot;
public partial class PlasticCatch : Node2D
{
	private Claw claw { get; set; }
	private ClawForMobile clawForMobile { get; set; }
	public override void _Ready()
	{
		for (int i = 0; i < 5; i++) AddChild(new Plastic());
		switch (OS.GetName())
		{
			case "Android":
				clawForMobile = new ClawForMobile();
				AddChild(clawForMobile);
				break;
			case "iOS":
				clawForMobile = new ClawForMobile();
				AddChild(clawForMobile);
				break;
			default:
				claw = new Claw();
				AddChild(claw);
				// AddChild(claw);
				break;
		}
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public void CheckCollision()
	{
		if (claw != null)
		{
			foreach (Plastic plastic in GetTree().GetNodesInGroup("Plastic"))
			{
				Rect2 clawRect = claw.GetGlobalTransform() * claw.GetRect();
				Rect2 plasticRect = plastic.GetGlobalTransform() * plastic.GetRect();
				if (clawRect.Intersects(plasticRect)) plastic.QueueFree();
			}
		}
		else
		{
			foreach (Plastic plastic in GetTree().GetNodesInGroup("Plastic"))
			{
				Rect2 clawRect = clawForMobile.GetGlobalTransform() * clawForMobile.GetRect();
				Rect2 plasticRect = plastic.GetGlobalTransform() * plastic.GetRect();
				if (clawRect.Intersects(plasticRect)) plastic.QueueFree();
			}
		}
		// foreach (Plastic plastic in GetTree().GetNodesInGroup("Plastic"))
		// {
		// 	Rect2 clawRect = claw.GetGlobalTransform() * claw.GetRect();
		// 	Rect2 plasticRect = plastic.GetGlobalTransform() * plastic.GetRect();
		// 	if (clawRect.Intersects(plasticRect)) plastic.QueueFree();
		// }
	}
	public void FinishedMinigame()
	{
		if (GetTree().GetNodesInGroup("Plastic").Count == 0)
		{
			claw.QueueFree();
			GetTree().ChangeSceneToFile("res://World/World.tscn");
		}
	}
	public override void _Process(double delta)
	{
		float _t = (float)delta * 4f;
		Vector2 mousePos = GetGlobalMousePosition();
		claw.Position = claw.Position.Lerp(mousePos, _t);
		// check if the claw is touching the plastic
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
			Texture = GD.Load<Texture2D>("res://assets/plastic.png");
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
			// set the texture of the claw
			Texture = GD.Load<Texture2D>("res://assets/claw.png");
			// set the position of the claw
			float xSize = GetViewport().GetVisibleRect().Size.X;
			float ySize = GetViewport().GetVisibleRect().Size.Y;
			Position = new Vector2(xSize / 2, ySize / 8);
			// set the scale of the claw
			Scale = new Vector2(0.1f, 0.1f);

		}
	}

	partial class ClawForMobile : TouchScreenButton
	{
		public override void _Ready()
		{
			Name = "clawForMobile";
			// set the texture of the claw
			TextureNormal = GD.Load<Texture2D>("res://assets/claw.png");
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
}

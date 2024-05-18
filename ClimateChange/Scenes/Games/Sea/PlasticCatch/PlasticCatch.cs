using System.Linq;
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
		// Add your initialization code here
		AddChild(new BGDyn("res://Scenes/Games/Sea/PlasticCatch/Assets/Background-plastic.png"));
		int plasticcount = 30;
		while (plasticcount > 0)
		{
			var p = new Plastic();
			AddChild(p);
			// check if p intersects with already existing plastic if so remove it and go further if not than keep it and decrease the count
			if (GetTree().GetNodesInGroup("Plastic").Cast<Plastic>().Any(plastic => p.GetTrueRect().Intersects(plastic.GetTrueRect()) && p.Position != plastic.Position))
			{ RemoveChild(p); continue;}
			plasticcount--;
		}

		CreateClaw();
		AddChild(rope);
	}

	public void CreateClaw()
	{
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
			destroyClaw();
			destroyPlastic();
			PlayerHandler.ChangeScene(this, "res://Scenes/WorldMap/World.tscn");
			PlayerHandler.levelCompletedCatch = 1;
		}
	}
	public void destroyClaw()
	{
		if (claw != null) { claw.QueueFree(); RemoveChild(claw); }
		else { clawForMobile.QueueFree(); RemoveChild(clawForMobile); }
	}

	public void destroyPlastic() => GetTree().GetNodesInGroup("Plastic").ToList().ForEach(plastic => { plastic.QueueFree(); RemoveChild(plastic); });

	public override void _Process(double delta)
	{
		sec += delta;
		if (sec - prevsec > 0.5)
		{
			prevsec = sec;
			if (claw != null) claw.nextFrame();
		}

		if (GetTree().GetNodesInGroup("Plastic").Count > 0) CheckCollision();
		else FinishedMinigame();

	}
	public override void _ExitTree()
	{
		base._ExitTree();
		foreach (Node child in GetChildren())
		{
			child.QueueFree();
		}
	}
}

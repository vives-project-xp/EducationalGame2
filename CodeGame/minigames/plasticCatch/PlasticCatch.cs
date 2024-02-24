using System;
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
		AddChild(new BGDyn("res://assets/Sea/background_plastic.png"));
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
			destroyClaw();
			destroyPlastic();
			PlayerHandler.ChangeScene(this, "res://World/World.tscn");
		}
	}
    public void destroyClaw()
    {
		if(claw != null){ claw.QueueFree(); RemoveChild(claw); }
		else {clawForMobile.QueueFree(); RemoveChild(clawForMobile);}
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
}
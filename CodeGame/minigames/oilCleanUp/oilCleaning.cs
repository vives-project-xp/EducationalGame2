using Godot;
using System;
using System.Linq;

public partial class oilCleaning : Node2D
{
	private bool toClose= false;
	private Sponge sponge { get; set; } = new();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AddChild(new BGDyn("res://assets/Sea/background_sea.png"));
		for (int i = 0; i < 10; i++)
		{
			Oil oil2 = new();
			AddChild(new Oil());
		}
		AddChild(new Sponge());
		
	}
	
	//check if sponge colides with oil
	public void CheckCollision()
	{
		foreach (Oil oil in GetTree().GetNodesInGroup("Oil"))
		{
			Rect2 spongeRect = sponge.GetGlobalTransform() * sponge.GetRect();
			Rect2 oilRect = oil.GetGlobalTransform() * oil.GetRect();
			if (spongeRect.Intersects(oilRect))oil.QueueFree();
		}
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		CheckCollision();
	}
}

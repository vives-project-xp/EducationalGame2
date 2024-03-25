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
		int plasticcount = 10;
		while (plasticcount > 0)
		{
			var p = new Oil();
			AddChild(p);
			// check if p intersects with already existing oils if so remove it and go further if not than keep it and decrease the count
			if (GetTree().GetNodesInGroup("Oils").Cast<Oil>().Any(oil => p.GetTrueRect().Intersects(oil.GetTrueRect()) && p.Position != oil.Position))
			{ RemoveChild(p); continue;}
			plasticcount--;
		}
		AddChild(sponge);
	}
	
	//check if sponge collides with oil
	public void CheckCollision()
	{
		foreach (Oil oil in GetTree().GetNodesInGroup("Oils"))
		{
			if(sponge!= null)
			{
				Rect2 spongeRect = sponge.GetGlobalTransform() * sponge.GetRect();
				Rect2 oilRect = oil.GetGlobalTransform() * oil.GetRect();
				if (spongeRect.Intersects(oilRect))
				{
					//if heatlh reaches 0 de oil will be deleted
					GD.Print(oil.Health);
					if(oil.Health>0)
					{
						oil.DecreaseHealth(sponge.Damage);
					}
					else oil.QueueFree();
				}
			}
		}
	}
	
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		CheckCollision();
	}
}

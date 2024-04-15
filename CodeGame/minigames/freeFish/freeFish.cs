using Godot;
using System;
using System.Linq;

public partial class freeFish : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AddChild(new BGDyn("res://assets/Sea/background_sea.png"));
		int boatcount = 6;
		while (boatcount > 0)
		{
			var p = new Boat();
			AddChild(p);
			// check if p intersects with already existing oils if so remove it and go further if not than keep it and decrease the count
			if (GetTree().GetNodesInGroup("Boats").Cast<Boat>().Any(boat => p.GetTrueRect().Intersects(boat.GetTrueRect()) && p.Position != boat.Position))
			{ RemoveChild(p); continue;}
			boatcount--;
		} 
	}

	public void CheckCollision()
	{
		foreach (Boat boat in GetTree().GetNodesInGroup("Boats"))
		{
			Rect2 boatRect = boat.GetGlobalTransform() * boat.GetRect();
        }
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

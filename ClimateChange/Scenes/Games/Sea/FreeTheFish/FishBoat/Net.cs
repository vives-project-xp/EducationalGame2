using Godot;
using System;

public partial class Net : CollisionShape2D
{
	PhysicsShapeQueryParameters2D query = new PhysicsShapeQueryParameters2D();

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}
	public Rect2 GetRect()
	{
		return new Rect2(GlobalPosition, new Vector2(100, 100));
	}
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		PhysicsPointQueryParameters2D query = new PhysicsPointQueryParameters2D()
		{
			CollideWithAreas = true,
			CollideWithBodies = true,
			Position = GetGlobalMousePosition(),
		};
		var result = GetWorld2D().DirectSpaceState.IntersectPoint(query);
		GD.Print(result);
	}
}

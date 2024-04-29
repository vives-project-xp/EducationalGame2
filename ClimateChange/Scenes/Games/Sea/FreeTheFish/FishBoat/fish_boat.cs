using Godot;
using System;

public partial class fish_boat : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	// check if the mouse is pressing on the collision shape
	public override void _InputEvent(Viewport viewport, InputEvent @event, int shapeIdx)
	{
		GD.Print("Mouse event on fish boat");

		if (@event is InputEventMouseButton e)
		{
			if (e.Pressed && e.ButtonIndex == MouseButton.Left)
			{
				GD.Print("Mouse pressed on fish boat");
			}
		}
	}
}

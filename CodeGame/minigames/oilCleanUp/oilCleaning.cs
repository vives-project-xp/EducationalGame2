using Godot;
using System;

public partial class oilCleaning : Node2D
{
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AddChild(new BGDyn("res://assets/Sea/background_sea.png"));
		AddChild(new Sponge());
		
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

}

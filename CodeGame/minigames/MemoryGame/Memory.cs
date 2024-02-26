using System.Drawing;
using Godot;

public partial class Memory : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()	
	{
		AddChild(new Card("res://assets/Industrial/bomb.png", size : GetViewportRect().Size));
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	
}

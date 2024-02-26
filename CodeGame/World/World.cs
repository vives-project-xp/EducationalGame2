using Godot;

public partial class World : Node2D
{
	/// <summary>
	/// Called when the node enters the scene tree for the first time.
	/// </summary>
	public override void _Ready()
	{
		AddChild(new BGDyn("res://assets/World/Sea.png"));
		AddChild(new BGDyn("res://assets/World/Landen.png"));
	}
}




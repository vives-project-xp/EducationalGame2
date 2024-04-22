using Godot;

public partial class World : Node2D
{
	// scaling value for the background
	private Vector2 SCALE;
	/// <summary>
	/// Called when the node enters the scene tree for the first time.
	/// </summary>
	public override void _Ready()
	{
		HUD._Visible = true;
		// get the scaling value between the window size and the default preset size 1920x1080
		SCALE = new Vector2(GetViewportRect().Size.X / 1920, GetViewportRect().Size.Y / 1080);
		AddChild(new BGDyn("res://assets/World/Sea.png"));
		AddChild(new BGDyn("res://assets/World/Landen.png"));
	}
}




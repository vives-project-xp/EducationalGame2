using Godot;
public partial class WorldWater : TextureRect
{
	public override void _Ready()
	{
		Size = GetViewportRect().Size;
	}
}

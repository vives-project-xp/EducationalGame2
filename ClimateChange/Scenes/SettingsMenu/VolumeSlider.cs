using Godot;
public partial class VolumeSlider : VSlider
{
	public override void _Ready()
	{
		MaxValue = 100;
		MinValue = 0;
		Value = 100;
		Step = 1;
		Size = new Vector2(10, 300);
		Position = GetViewportRect().Size - new Vector2(200, GetViewportRect().Size.Y / 2 + Size.Y / 2);
	}
    // on slider value changed set the volume
    public override void _Input(InputEvent @event)
    {
		if(@event is InputEventMouseButton)
		{
			PlayerHandler.SetVolume((int)Value);
		}
    }
}

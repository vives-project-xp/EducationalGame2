using Godot;
public partial class VolumeSlider : VSlider
{
	public override void _Process(double delta)
	{
		PlayerHandler.SetVolume((int)Value);
	}
}

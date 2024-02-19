using Godot;
public partial class PlayButton : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(PlayerHandler.CurrentLanguage == "English")
		{
			Text = "Play";
		}
		else if(PlayerHandler.CurrentLanguage == "Nederlands")
		{
			Text = "Spelen";
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

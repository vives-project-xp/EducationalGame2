using Godot;
public partial class PlayButton : Button
{
	public override void _Ready()
	{
		if(PlayerHandler.CurrentLanguage == "English") Text = "Play";
		else if(PlayerHandler.CurrentLanguage == "Nederlands") Text = "Spelen";
	}
	public override void _Pressed() => GetTree().ChangeSceneToFile("res://World/World.tscn");
}

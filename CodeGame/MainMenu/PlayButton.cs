using Godot;
public partial class PlayButton : Button
{
	public override void _Ready()
	{
		Theme = (Theme)ResourceLoader.Load("res://button_theme.tres");
		CustomMinimumSize = GetViewportRect().Size / 8;
		if(PlayerHandler.CurrentLanguage == "English") Text = "Play";
		else if(PlayerHandler.CurrentLanguage == "Nederlands") Text = "Spelen";
	}
	public override void _Pressed() => GetTree().ChangeSceneToFile("res://World/World.tscn");
	public override void _Process(double delta)
	{
		CustomMinimumSize = new Vector2(GetViewportRect().Size.X / 4, GetViewportRect().Size.Y / 8);
	}
}

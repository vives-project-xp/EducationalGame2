using Godot;
public partial class mainMenuButton : Button
{
	public override void _Process(double delta)
	{
		if(PlayerHandler.CurrentLanguage == "English") Text = "Main Menu";
		else if(PlayerHandler.CurrentLanguage == "Nederlands") Text = "Hoofdmenu";
		// misshien nog meer talen later toe te voegen
	}
	public override void _Pressed() => GetTree().ChangeSceneToFile("res://MainMenu/Main.tscn");
}

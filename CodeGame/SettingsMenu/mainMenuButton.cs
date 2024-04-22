using Godot;
public partial class mainMenuButton : Button
{
	public override void _Ready()
	{
		Theme = GD.Load<Theme>("res://Textures/button_theme.tres");
		CustomMinimumSize = new Vector2(GetViewportRect().Size.X / 4, GetViewportRect().Size.Y / 8);
	}
	public override void _Process(double delta)
	{

		if(PlayerHandler.CurrentLanguage == "English") Text = "Main Menu";
		else if(PlayerHandler.CurrentLanguage == "Nederlands") Text = "Hoofdmenu";
	}
	public override void _Pressed() => GetTree().ChangeSceneToFile("res://MainMenu/Main.tscn");
}

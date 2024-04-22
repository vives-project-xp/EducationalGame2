using Godot;
public partial class SettingsButton : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Theme = (Theme)ResourceLoader.Load("res://Textures/button_theme.tres");
		if (PlayerHandler.CurrentLanguage == "English") Text = "Settings";
		else if (PlayerHandler.CurrentLanguage == "Nederlands") Text = "Instellingen";
		CustomMinimumSize = new Vector2(GetViewportRect().Size.X / 4, GetViewportRect().Size.Y / 8);
	}
	public override void _Pressed()
	{
		PlayerHandler.ChangeScene(this, "res://SettingsMenu/Settings.tscn");
	}
}

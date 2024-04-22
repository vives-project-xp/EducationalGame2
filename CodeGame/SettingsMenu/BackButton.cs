using System;
using Godot;
public partial class SettingsBackButton : Button
{
	public override void _Ready()
	{
		base._Ready();
		Position = new Vector2(100, 100);
		Theme = GD.Load<Theme>("res://Textures/button_theme.tres");
		CustomMinimumSize = new Vector2(GetViewportRect().Size.X / 4, GetViewportRect().Size.Y / 8);

	}
	public override void _Process(double delta)
	{
		if (PlayerHandler.CurrentLanguage == "English") Text = "Back";
		else if (PlayerHandler.CurrentLanguage == "Nederlands") Text = "Terug";
	}
	public override void _Pressed() => PlayerHandler.ChangeScene(this, PlayerHandler.LastScene);
}

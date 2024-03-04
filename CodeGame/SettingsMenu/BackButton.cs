using System;
using Godot;
public partial class BackButton : Button
{
	
	public override void _Process(double delta)
	{
		Theme = GD.Load<Theme>("res://button_theme.tres");
		Position = new Vector2(100, 100);
		CustomMinimumSize = new Vector2(GetViewportRect().Size.X / 4, GetViewportRect().Size.Y / 8);
		if(PlayerHandler.CurrentLanguage == "English") Text = "Back";
		else if(PlayerHandler.CurrentLanguage == "Nederlands") Text = "Terug";

	}
    public override void _Pressed() => GetTree().ChangeSceneToFile(PlayerHandler.LastScene);
}

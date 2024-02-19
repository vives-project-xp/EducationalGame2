using System;
using Godot;
public partial class BackButton : Button
{
	
	public override void _Process(double delta)
	{
		if(PlayerHandler.CurrentLanguage == "English") Text = "Back";
		else if(PlayerHandler.CurrentLanguage == "Nederlands") Text = "Terug";

	}
    public override void _Pressed() => GetTree().ChangeSceneToFile(PlayerHandler.LastScene);
}

using Godot;
using System;

public partial class SettingsButton : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		if(PlayerHandler.CurrentLanguage == "English")
		{
			Text = "Settings";
		}
		else if(PlayerHandler.CurrentLanguage == "Nederlands")
		{
			Text = "Instellingen";
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

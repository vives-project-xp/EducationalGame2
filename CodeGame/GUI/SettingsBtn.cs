using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class SettingsBtn : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Pressed()
	{
		// change the scene to the settings scene
		PlayerHandler.ChangeScene(this, "res://SettingsMenu/Settings.tscn");
	}
}

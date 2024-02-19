using Godot;
using System;

public partial class Agriculture : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _on_burger_button_pressed() 
	{
		PlayerHandler.LastScene = "res://Agriculture/Agriculture.tscn";
		GetTree().ChangeSceneToFile("res://SettingsMenu/Settings.tscn");
	}
	public void _on_back_pressed() => GetTree().ChangeSceneToFile("res://World/World.tscn");

}

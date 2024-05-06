using Godot;
using System;

public partial class memoryBtnMoreGames : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	public override void _Pressed() => GetTree().ChangeSceneToFile("res://Scenes/Games/Extra/Memory/Memory.tscn");
}

using Godot;
using System;

public partial class moreGamesLabel : RichTextLabel
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(GetTree().CurrentScene.SceneFilePath != "res://Scenes/WorldMap/World.tscn")
		{
			Visible = false;	
		}else
		{
			Visible = true;
		}

	}
}

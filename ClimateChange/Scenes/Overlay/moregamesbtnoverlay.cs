using Godot;
using System;

public partial class moregamesbtnoverlay : Button
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNodeOrNull<RichTextLabel>("../moreGamesLabel").Visible = false;
	}
	public override void _Process(double delta)
	{
		if(GetTree().CurrentScene.SceneFilePath == "res://Scenes/WorldMap/World.tscn")
		{
			Visible = true;
		}
		else
		{
			Visible = false;
		}
	}

	public override void _Pressed()
	{
        var moreGamesLabel = GetNodeOrNull<RichTextLabel>("../moreGamesLabel");
        moreGamesLabel.Visible = !moreGamesLabel.Visible;
	}


}

using Godot;
using System;

public partial class moregamesbtnoverlay : Button
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNodeOrNull<RichTextLabel>("../moreGamesLabel").Visible = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(GetTree().CurrentScene.SceneFilePath == "res://Scenes/WorldMap/World.tscn")
		{
			GetNodeOrNull<RichTextLabel>("../moreGamesLabel").Visible = true;	
		}else
		{
			GetNodeOrNull<RichTextLabel>("../moreGamesLabel").Visible = false;
		}
	}

	public override void _Pressed()
	{
<<<<<<< HEAD
		var moreGamesLabel = GetNodeOrNull<RichTextLabel>("../moreGamesLabel");
		moreGamesLabel.Visible = !moreGamesLabel.Visible;
=======
        var moreGamesLabel = GetNodeOrNull<RichTextLabel>("../moreGamesLabel");
        moreGamesLabel.Visible = !moreGamesLabel.Visible;
>>>>>>> 1c5fb2f5c81aff3aaf5b21e41344a37646a64364
	}


}

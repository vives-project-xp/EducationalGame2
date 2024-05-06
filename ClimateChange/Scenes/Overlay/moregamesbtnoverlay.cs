using Godot;
using System;

public partial class moregamesbtnoverlay : Button
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
<<<<<<< HEAD
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
=======
		GetNode<RichTextLabel>("../moreGamesLabel").Visible = false;
>>>>>>> eb19a4e294b2b0903d143b5c602f23e1d169918d
	}

	public override void _Pressed()
	{
<<<<<<< HEAD
        var moreGamesLabel = GetNodeOrNull<RichTextLabel>("../moreGamesLabel");
        moreGamesLabel.Visible = !moreGamesLabel.Visible;
=======
		var moreGamesLabel = GetNode<RichTextLabel>("../moreGamesLabel");
		moreGamesLabel.Visible = !moreGamesLabel.Visible;
>>>>>>> eb19a4e294b2b0903d143b5c602f23e1d169918d
	}


}

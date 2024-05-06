using Godot;
using System;

public partial class moregamesbtnoverlay : Button
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<RichTextLabel>("../moreGamesLabel").Visible = false;
	}

	public override void _Pressed()
	{
<<<<<<< HEAD
        var moreGamesLabel = GetNodeOrNull<RichTextLabel>("../moreGamesLabel");
        moreGamesLabel.Visible = !moreGamesLabel.Visible;
=======
		var moreGamesLabel = GetNode<RichTextLabel>("../moreGamesLabel");
		moreGamesLabel.Visible = !moreGamesLabel.Visible;
>>>>>>> 3020f58a5807e6d72dc67e66e51ce641db8ecea3
	}


}

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
>>>>>>> 279143842232781b0a985a89838f2f3b5e34a244
	}


}

using Godot;
using System;

public partial class moregamesbtnoverlay : Button
{

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<RichTextLabel>("/root/World/Hud/moreGamesLabel").Visible = false;
	}

	public override void _Pressed() 
	{
        var moreGamesLabel = GetNode<RichTextLabel>("/root/World/Hud/moreGamesLabel");
        moreGamesLabel.Visible = !moreGamesLabel.Visible;
	}

	
}

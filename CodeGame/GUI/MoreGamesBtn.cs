using Godot;
using System;

public partial class MoreGamesBtn : Button
{
	public static bool _Visible = true;

	public override void _Process(double delta)
	{
		Visible = _Visible;
	}
}

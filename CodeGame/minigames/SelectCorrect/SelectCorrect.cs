using Godot;
using System;

	/// <summary>
	/// test idea for a minigame not sure if we will use it
	/// </summary>
public partial class SelectCorrect : Node2D
{
	public override void _Ready()
	{
		MoreGamesBtn._Visible = false;
	}

	/// <summary>
	/// is to handle the unhandled inputs in the game.
	/// </summary>
	/// <param name="event"></param>
	public override void _UnhandledInput(InputEvent @event)
	{
		if (@event.IsActionPressed("ui_click"))
		{
			// get the mouse position
			if(GetGlobalMousePosition().X < GetViewportRect().Size.X / 2)
			{
				Left();
			}
			else
			{
				right();
			}
		}
	}


	public void Left()
	{
		// do something when the left side is clicked
	}

	public void right()
	{
		// do something when the right side is clicked
	}

}

using Godot;
using System;

public partial class gameoverscreen : CanvasLayer
{
	public PlayerHandler.StackingDificulty Level;
	public void _on_restart_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://minigames/Stacking/start_screen.tscn");
	}
	public void _on_quit_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://World/World.tscn");
	}

	public override void _Ready()
	{
		Level = PlayerHandler.stackingSetDificulty;
		if (Level == PlayerHandler.StackingDificulty.easy)
		{
			PlayerHandler.levelCompleted = 1;
			GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "U FAILED EAZY LEVEL";
		}
		else if (Level == PlayerHandler.StackingDificulty.medium)
		{
			PlayerHandler.levelCompleted = 2;
			GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "U FAILED MEDUIM LEVEL";
		}
		else if (Level == PlayerHandler.StackingDificulty.hard)
		{
			PlayerHandler.levelCompleted = 3;
			GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "U FAILED HARD LEVEL";
		}
		else
		{
			PlayerHandler.levelCompleted = 0;
		}
	}
}

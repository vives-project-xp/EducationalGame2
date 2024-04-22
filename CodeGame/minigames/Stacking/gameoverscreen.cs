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
			GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "YOU FAILED EASY LEVEL";
		}
		else if (Level == PlayerHandler.StackingDificulty.medium)
		{
			GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "YOU FAILED MEDUIM LEVEL";
		}
		else if (Level == PlayerHandler.StackingDificulty.hard)
		{
			GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "YOU FAILED HARD LEVEL";
		}
		else
		{
			PlayerHandler.levelCompleted = 0;
		}
	}
}

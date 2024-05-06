using Godot;
using System;

public partial class gameoverscreen : CanvasLayer
{
	public PlayerHandler.StackingDificulty Level;
	public void _on_restart_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/Games/Industrial/Stacking/start_screen.tscn");
	}
	public void _on_quit_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/WorldMap/World.tscn");
	}

	public override void _Ready()
	{
		Level = PlayerHandler.stackingSetDificulty;
		if (PlayerHandler.CurrentLanguage == "English")
		{
			GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/RestartButton").Text = "  Restart  ";
			GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/QuitButton").Text = "Quit";

			if (Level == PlayerHandler.StackingDificulty.easy)
			{
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "U FAILED EASY LEVEL";
			}
			else if (Level == PlayerHandler.StackingDificulty.medium)
			{
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "U FAILED MEDUIM LEVEL";
			}
			else if (Level == PlayerHandler.StackingDificulty.hard)
			{
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "U FAILED HARD LEVEL";
			}
			else if (Level == PlayerHandler.StackingDificulty.impossible)
			{
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "U FAILED IMPOSSIBLE LEVEL";
			}

		}

		if (PlayerHandler.CurrentLanguage == "Nederlands")
		{
			GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/RestartButton").Text = " Opnieuw Proberen ";
			GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/QuitButton").Text = "stoppen";

			if (Level == PlayerHandler.StackingDificulty.easy)
			{
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "Je hebt het makkelijke niveau niet gehaald";
			}
			else if (Level == PlayerHandler.StackingDificulty.medium)
			{
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "Je hebt het normaale niveau niet gehaald";
			}
			else if (Level == PlayerHandler.StackingDificulty.hard)
			{
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "Je hebt het moeilijke niveau niet gehaald";
			}
			else if (Level == PlayerHandler.StackingDificulty.impossible)
			{
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "Je hebt het onmogelijke niveau niet gehaald";
			}
		}
	}
}

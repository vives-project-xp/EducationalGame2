using Godot;
using System;

public partial class completedscreen : CanvasLayer
{
	public PlayerHandler.StackingDificulty Level;
	public void _on_quit_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/WorldMap/World.tscn");
	}
	public void _on_next_level_button_pressed()
	{
		switch (PlayerHandler.levelCompleted)
		{
			case 3:
				PlayerHandler.stackingSetDificulty = PlayerHandler.StackingDificulty.impossible;
				break;
			case 2:
				PlayerHandler.stackingSetDificulty = PlayerHandler.StackingDificulty.hard;
				break;
			case 1:
				PlayerHandler.stackingSetDificulty = PlayerHandler.StackingDificulty.medium;
				break;
			default:
				break;
		}
		GetTree().ChangeSceneToFile("res://Scenes/Games/Industrial/Stacking/StackingGame.tscn");
	}

	public void _on_endless_mode_button_pressed()
	{
		PlayerHandler.stackingSetDificulty = PlayerHandler.StackingDificulty.Endless;
		PlayerHandler.prevStackingPoint = 0;
		GetTree().ChangeSceneToFile("res://Scenes/Games/Industrial/Stacking/StackingGame.tscn");
	}

	public override void _Ready()
	{
		Level = PlayerHandler.stackingSetDificulty;


		if (PlayerHandler.levelCompleted == 3)
		{
			GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/NextLevelButton").Visible = false;
		}

		if (PlayerHandler.levelCompleted >= 1)
		{
			GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/EndlessModeButton").Visible = true;
		}

		if (PlayerHandler.CurrentLanguage == "English")
		{
			GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/NextLevelButton").Text = "  NEXT LEVEL  ";
			GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/QuitButton").Text = "QUIT";
						GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/EndlessModeButton").Text ="ENDLESS MODE";

			if (Level == PlayerHandler.StackingDificulty.easy)
			{
				if (PlayerHandler.levelCompleted < 1) PlayerHandler.levelCompleted = 1;
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "U COMPLETED EASY LEVEL!";
			}
			else if (Level == PlayerHandler.StackingDificulty.medium)
			{
				if (PlayerHandler.levelCompleted < 2) PlayerHandler.levelCompleted = 2;
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "U COMPLETED MEDUIM LEVEL!!";
			}
			else if (Level == PlayerHandler.StackingDificulty.hard)
			{
				if (PlayerHandler.levelCompleted < 3) PlayerHandler.levelCompleted = 3;
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "U COMPLETED HARD LEVEL!!!";
			}
			else if (Level == PlayerHandler.StackingDificulty.impossible)
			{
				if (PlayerHandler.levelCompleted < 4) PlayerHandler.levelCompleted = 4;
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "U COMPLETED IMPOSSIBLE LEVEL!!!!";
			}
		}

		if (PlayerHandler.CurrentLanguage == "Nederlands")
		{
			GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/NextLevelButton").Text = "  VOLGENDE NIVEAU  ";
			GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/QuitButton").Text = "STOPPEN";
						GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/EndlessModeButton").Text = " ONEINDIGE MODUS ";


			if (Level == PlayerHandler.StackingDificulty.easy)
			{
				if (PlayerHandler.levelCompleted < 1) PlayerHandler.levelCompleted = 1;
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "JE HEBT HET GEMAKELIJK NIVEAU GEHAALD!";
			}
			else if (Level == PlayerHandler.StackingDificulty.medium)
			{
				if (PlayerHandler.levelCompleted < 2) PlayerHandler.levelCompleted = 2;
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "JE HEBT HET NORMAAL NIVEAU GEHAALD!!";
			}
			else if (Level == PlayerHandler.StackingDificulty.hard)
			{
				if (PlayerHandler.levelCompleted < 3) PlayerHandler.levelCompleted = 3;
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "JE HEBT HET MOEILIJK NIVEAU GEHAALD!!!";
			}
			else if (Level == PlayerHandler.StackingDificulty.impossible)
			{
				if (PlayerHandler.levelCompleted < 4) PlayerHandler.levelCompleted = 4;
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "JE HEBT HET ONMOGELIJKE NIVEAU GEHAALD!!!!";
			}
		}
	}
}
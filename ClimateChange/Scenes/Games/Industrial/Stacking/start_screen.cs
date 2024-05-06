using Godot;

public partial class start_screen : CanvasLayer
{
	public delegate void MyCustomSignal();
	public void _on_easy_mode_pressed()
	{
		PlayerHandler.stackingSetDificulty = PlayerHandler.StackingDificulty.easy;
		GetTree().ChangeSceneToFile("res://Scenes/Games/Industrial/Stacking/StackingGame.tscn");
	}

	public void _on_medium_mode_pressed()
	{
		PlayerHandler.stackingSetDificulty = PlayerHandler.StackingDificulty.medium;
		GetTree().ChangeSceneToFile("res://Scenes/Games/Industrial/Stacking/StackingGame.tscn");
	}
	public void _on_hard_mode_pressed()
	{
		PlayerHandler.stackingSetDificulty = PlayerHandler.StackingDificulty.hard;
		GetTree().ChangeSceneToFile("res://Scenes/Games/Industrial/Stacking/StackingGame.tscn");
	}

	public void _on_not_possible_mode_pressed()
	{
		PlayerHandler.stackingSetDificulty = PlayerHandler.StackingDificulty.impossible;
		GetTree().ChangeSceneToFile("res://Scenes/Games/Industrial/Stacking/StackingGame.tscn");
	}

	public void _on_back_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/WorldMap/World.tscn");
	}

	public void _on_endless_mode_button_pressed()
	{
		PlayerHandler.stackingSetDificulty = PlayerHandler.StackingDificulty.Endless;
		PlayerHandler.prevStackingPoint = 0;
		GetTree().ChangeSceneToFile("res://Scenes/Games/Industrial/Stacking/StackingGame.tscn");
	}

	public override void _Ready()
	{
		switch (PlayerHandler.levelCompleted)
		{
			case 4 :
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/NotPossibleMode").Disabled = false;
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/HardMode").Disabled = false;
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/MediumMode").Disabled = false;
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/EndlessMode_button").Disabled = false;
				break;
			case 3 :
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/NotPossibleMode").Disabled = false;
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/HardMode").Disabled = false;
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/MediumMode").Disabled = false;
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/EndlessMode_button").Disabled = false;
				break;
			case 2:
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/HardMode").Disabled = false;
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/MediumMode").Disabled = false;
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/EndlessMode_button").Disabled = false;
				break;
			case 1:
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/MediumMode").Disabled = false;
				break;
			default:
				break;
		}
		if (PlayerHandler.CurrentLanguage == "English")
		{
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "WELCOME, BUILDER";
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/NotPossibleMode").Text = "  IMPOSSIBLE  ";
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/HardMode").Text = "HARD";
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/MediumMode").Text = "MEDUIM";
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/EndlessMode_button").Text = "ENDLESS";
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/EasyMode").Text = "EASY";
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/BackButton").Text = "WORLD MAP";
		}
		if (PlayerHandler.CurrentLanguage == "Nederlands")
		{
				GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "WELKOM, BOUWER";
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/NotPossibleMode").Text = "ONMOGELIJK";
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/HardMode").Text = "MOEILIJK";
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/MediumMode").Text = "NORMAAL";
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/EndlessMode_button").Text = "ONEINDIG";
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/EasyMode").Text = "   GEMAKELIJK   ";
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/BackButton").Text = "WERELD MAP";
		}
	}
}

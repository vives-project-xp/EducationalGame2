using Godot;

public partial class start_screen : CanvasLayer
{
	public delegate void MyCustomSignal();
	public void _on_easy_mode_pressed()
	{
		PlayerHandler.stackingSetDificulty = PlayerHandler.StackingDificulty.easy;
		GetTree().ChangeSceneToFile("res://minigames/Stacking/StackingGame.tscn");
	}

	public void _on_medium_mode_pressed()
	{
		PlayerHandler.stackingSetDificulty = PlayerHandler.StackingDificulty.medium;
		GetTree().ChangeSceneToFile("res://minigames/Stacking/StackingGame.tscn");
	}
	public void _on_hard_mode_pressed()
	{
		PlayerHandler.stackingSetDificulty = PlayerHandler.StackingDificulty.hard;
		GetTree().ChangeSceneToFile("res://minigames/Stacking/StackingGame.tscn");
	}

	public void _on_not_possible_mode_pressed()
	{
		PlayerHandler.stackingSetDificulty = PlayerHandler.StackingDificulty.impossible;
		GetTree().ChangeSceneToFile("res://minigames/Stacking/StackingGame.tscn");
	}

	public void _on_back_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://World/World.tscn");
	}

public override void _Ready()
{
    switch (PlayerHandler.levelCompleted)
    {
        case 4:
            GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/NotPossibleMode").Disabled = true;
            goto case 3;
        case 3:
            GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/HardMode").Disabled = true;
            goto case 2;
        case 2:
            GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/MediumMode").Disabled = true;
            goto case 1;
        case 1:
            GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/EasyMode").Disabled = true;
            break;
        default:
            break;
    }
}
}

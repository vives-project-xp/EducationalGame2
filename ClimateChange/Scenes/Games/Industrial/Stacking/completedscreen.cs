using Godot;
using System;

public partial class completedscreen : CanvasLayer
{
	public PlayerHandler.StackingDificulty Level;
	public void _on_quit_button_pressed()
	{
        GetTree().ChangeSceneToFile("res://Scenes/WorldMap/World.tscn");
	}
	public void _on_redo_button_pressed()
	{
		    switch (PlayerHandler.levelCompleted)
    {
        case 3:
            		PlayerHandler.stackingSetDificulty=PlayerHandler.StackingDificulty.impossible;
            break;
        case 2:
            		PlayerHandler.stackingSetDificulty=PlayerHandler.StackingDificulty.hard;
            break;
        case 1:
            		PlayerHandler.stackingSetDificulty=PlayerHandler.StackingDificulty.medium;
            break;
        default:
            break;
    }
		GetTree().ChangeSceneToFile("res://Scenes/Games/Industrial/Stacking/StackingGame.tscn");
    }

	public void _on_endless_mode_button_pressed(){
		PlayerHandler.stackingSetDificulty=PlayerHandler.StackingDificulty.Endless;
		PlayerHandler.prevStackingPoint = 0;
        GetTree().ChangeSceneToFile("res://Scenes/Games/Industrial/Stacking/StackingGame.tscn");
	}
	
    public override void _Ready(){
		Level = PlayerHandler.stackingSetDificulty;
		if(Level == PlayerHandler.StackingDificulty.easy){
			PlayerHandler.levelCompleted = 1;
			GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "U COMPLETED EAZY LEVEL";
		}
		else if (Level == PlayerHandler.StackingDificulty.medium){
			PlayerHandler.levelCompleted = 2;
			GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "U COMPLETED MEDUIM LEVEL";
		}
		else if (Level == PlayerHandler.StackingDificulty.hard){
			PlayerHandler.levelCompleted = 3;
			GetNode<Label>("PanelContainer/MarginContainer/Rows/Titel").Text = "U COMPLETED HARD LEVEL";
		}
		else {
			PlayerHandler.levelCompleted = 0;
		}
	}
}
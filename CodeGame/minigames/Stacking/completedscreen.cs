using Godot;
using System;

public partial class completedscreen : CanvasLayer
{
	public void _on_quit_button_pressed()
	{
		GetTree().Quit();
	}
	public void _on_redo_button_pressed()
	{
        GetTree().ChangeSceneToFile("res://minigames/Stacking/start_screen.tscn");
    }

	public void _on_endless_mode_button_pressed(){
		PlayerHandler.stackingSetDificulty=PlayerHandler.StackingDificulty.Endless;
		PlayerHandler.prevStackingPoint = 0;
        GetTree().ChangeSceneToFile("res://minigames/Stacking/StackingGame.tscn");
	}

}
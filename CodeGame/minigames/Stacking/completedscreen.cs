using Godot;
using System;

public partial class completedscreen : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
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
        GetTree().ChangeSceneToFile("res://minigames/Stacking/StackingGame.tscn");
	}

}
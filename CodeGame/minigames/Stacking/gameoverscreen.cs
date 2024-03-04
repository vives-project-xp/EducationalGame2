using Godot;
using System;

public partial class gameoverscreen : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _on_restart_button_pressed(){
		GetTree().ChangeSceneToFile("res://minigames/Stacking/StackingGame.tscn");
    }
	public void _on_quit_button_pressed(){
		GetTree().Quit();
	}

	public void set_titel(){
		
	} 
}

using Godot;
using System;

public partial class gameoverscreen : CanvasLayer
{
	public void _on_restart_button_pressed(){
		GetTree().ChangeSceneToFile("res://minigames/Stacking/start_screen.tscn");
    }
	public void _on_quit_button_pressed(){
		GetTree().Quit();
	}
}

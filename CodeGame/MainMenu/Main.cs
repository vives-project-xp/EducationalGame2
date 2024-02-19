using Godot;
public partial class Main : Node2D
{	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{	
	}

	public void _on_play_pressed(){
		GetTree().ChangeSceneToFile("res://World/World.tscn");
	}
	
	public void _on_settings_pressed()
	{
		PlayerHandler.LastScene = "res://MainMenu/Main.tscn";
		GetTree().ChangeSceneToFile("res://SettingsMenu/Settings.tscn");
	}
	public void _on_burger_button_pressed() 
	{
		PlayerHandler.LastScene = "res://World/World.tscn";
		GetTree().ChangeSceneToFile("res://SettingsMenu/Settings.tscn");
	}
}



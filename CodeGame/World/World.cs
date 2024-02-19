using Godot;

public partial class World : Node2D
{
	// Called when the node enters the scene tree for the first time.
	
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

	public void _on_burger_button_pressed() 
	{
		PlayerHandler.LastScene = "res://World/World.tscn";
		GetTree().ChangeSceneToFile("res://SettingsMenu/Settings.tscn");
	}
	public void seaPressed() 
	{ 
		PlayerHandler.LastScene = "res://World/World.tscn" ; 
		GetTree().ChangeSceneToFile("res://Sea/Sea.tscn");
	}

	public void forestPressed() 
	{ 
		PlayerHandler.LastScene = "res://World/World.tscn" ;
		GetTree().ChangeSceneToFile("res://Forest/Forest.tscn");
	}

	public void agriculturePressed() 
	{ 
		PlayerHandler.LastScene = "res://World/World.tscn" ;
		GetTree().ChangeSceneToFile("res://Agriculture/Agriculture.tscn");
	}

	public void industrialPressed() 
	{ 
		PlayerHandler.LastScene = "res://World/World.tscn" ;
		GetTree().ChangeSceneToFile("res://Industrial/Industrial.tscn");
	}
}




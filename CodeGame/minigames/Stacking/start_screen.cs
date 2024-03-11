using Godot;

public partial class start_screen : CanvasLayer
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public delegate void MyCustomSignal();
	public void _on_easy_mode_pressed(){
		PlayerHandler.stackingSetDificulty=PlayerHandler.StackingDificulty.easy;
        GetTree().ChangeSceneToFile("res://minigames/Stacking/StackingGame.tscn");
	}
	
	public void _on_medium_mode_pressed(){
		PlayerHandler.stackingSetDificulty=PlayerHandler.StackingDificulty.medium;
        GetTree().ChangeSceneToFile("res://minigames/Stacking/StackingGame.tscn");
	}
	public void _on_hard_mode_pressed(){
		PlayerHandler.stackingSetDificulty=PlayerHandler.StackingDificulty.hard;
        GetTree().ChangeSceneToFile("res://minigames/Stacking/StackingGame.tscn");
	}

	public void _on_not_possible_mode_pressed(){
		PlayerHandler.stackingSetDificulty=PlayerHandler.StackingDificulty.impossible;
        GetTree().ChangeSceneToFile("res://minigames/Stacking/StackingGame.tscn");
	}

}

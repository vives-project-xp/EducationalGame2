using Godot;

public partial class RestoreFarmland : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}


public partial class Tiles : TileMap
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// cell size is 32x32
		TileSet = ResourceLoader.Load("res://minigames/RestoreFarmland/TileSet.tres") as TileSet;
	}
}

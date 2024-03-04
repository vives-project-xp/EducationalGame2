using Godot;
using System;
using System.Collections.Generic;

public partial class Flappy : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private List<Tree[]> Trees = new List<Tree[]>();
	public override void _Ready()
	{
		AddChild(new Bird());
		AddChild(new BirdCam());
		for (int i = 0; i < 10; i++)
		{
			for(int j = 0; j < 2; j++)
			{
				AddChild(new Tree(new Vector2(1000 + i * 500, j * 1000)));
			}
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

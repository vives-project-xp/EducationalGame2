using Godot;
using System;
using System.Collections.Generic;

public partial class Flappy : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private List<Tree[]> Trees = new List<Tree[]>();
	private int TreeCount;
	public override void _Ready()
	{
		AddChild(new Bird());
		AddChild(new BirdCam());
		for (int i = 0; i < 6; i++)
		{
			List<Tree> coupleTree = new List<Tree>();
			for(int j = 0; j < 2; j++)
			{
                Tree tree = new()
                {
					
					Position = new Vector2(i * 500 + 500 , 0),
                    Top = j == 0
                };
                AddChild(tree);
				coupleTree.Add(tree);
			}
			Trees.Add(coupleTree.ToArray());
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// check if the trees are out of the screen and move them to the right
		foreach(var tree in GetTree().GetNodesInGroup("Tree"))
		{
			if (tree is Tree t)
			{
				Camera2D camera = GetNode<BirdCam>("BirdCam");
				if (t.Position.X < camera.Position.X - 500)
				{
					t.Position = new Vector2(t.Position.X + 3000, t.Position.Y);
				}
			}
		}
	}
}

using System;
using System.Collections.Generic;
using System.Drawing;
using Godot;
public partial class Flappy : Node2D
{
	public override void _Ready()
	{
		MoreGamesBtn._Visible = false;
		base._Ready();
		var windowSize = GetViewportRect().Size;
		var trees = new Trees(windowSize);
		trees.Duo.ForEach(tree => AddChild(tree));
	}

	public override void _Process(double delta)
	{
		base._Process(delta);
		//check if the trees are to the left of the screen 
		// if so, reset their position to the right of the screen
		foreach (var tree in GetChildren())
		{
			if (tree is Tree treeInstance)
			{
				if (treeInstance.Position.X < -treeInstance.GetRect().Size.X / 2)
				{
					treeInstance.Position = new Vector2(GetViewportRect().Size.X + (treeInstance.GetRect().Size.X / 2), treeInstance.Position.Y);
				}
				// check for collision with the bird
				if(treeInstance.GetRect().Intersects(GetNode<Bird>("Bird").GetRect()))
				{
					GetNode<Bird>("Bird").isAlive = false;
					GD.Print("Game Over");
				}
			}

		}
	}
}

public partial class Trees
{
	public List<Tree> Duo { get; set; }
	public Vector2 WindowSize { get; set; }

	public Trees(Vector2 windowSize)
	{
		WindowSize = windowSize;
		SetTree();
	}
	public void SetTree()
	{
		Duo = new List<Tree>(){
			new(){
				WindowSize = WindowSize
			} ,
			new(){
				WindowSize = WindowSize
			}
		};
		// to put them out of the screen
		Duo[0].ResetTopTree();
		Duo[1].ResetBottomTree();
	}
}
public partial class Tree : Sprite2D
{

	public Vector2 WindowSize { get; set; }
	public Tree()
	{
		AddToGroup("tree");
		
		Texture = GD.Load<Texture2D>("res://assets/Forest/FireTree.png");
	}

	public override void _PhysicsProcess(double delta)
	{
		Position += new Vector2(-500 * (float)delta, 0);
	}

	public void ResetTopTree()
	{
		Scale = new Vector2(1, -1);
		//reset position to the most right of the screen
		Position = new Vector2(WindowSize.X + (GetRect().Size.X / 2), 0 + GetRect().Size.Y / 2 - 50);
	}
	public void ResetBottomTree()
	{
		Scale = new Vector2(1, 1);
		//reset position to the most right of the screen
		Position = new Vector2(WindowSize.X + (GetRect().Size.X / 2), WindowSize.Y - GetRect().Size.Y / 2 + 50);
	}
}

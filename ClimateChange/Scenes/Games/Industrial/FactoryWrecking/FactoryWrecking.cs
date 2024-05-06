using Godot;
using System;
public partial class FactoryWrecking : Node2D
{
	bool hasMoved = false;
	bool dragging = false;
	Vector2 drag_start = new Vector2();
	BaseFactoryPart factoryPart;


	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetNode<Container>("CenterContainer").Visible = false;
		foreach (Node child in GetTree().GetNodesInGroup("FactoryPart"))
		{
			if (child is BaseFactoryPart part)
			{
				part.GetNode<Sprite2D>("CanvasGroup/Mask").Visible = false;
				part.GetNode<Sprite2D>("CanvasGroup/Mask2").Visible = false;
			}
		}
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		foreach (Node child in GetTree().GetNodesInGroup("FactoryPart"))
		{
			if (child is BaseFactoryPart part)
			{
				if (part.Health <= 5)
				{
					part.GetNode<Sprite2D>("CanvasGroup/Mask2").Visible = true;
				} else
				if (part.Health <= 10)
				{
					part.GetNode<Sprite2D>("CanvasGroup/Mask").Visible = true;
				} 
			}
		}
		if (GetNode<ProgressBar>("ProgressBar").Value <= 0)
		{
			GetNode<Container>("CenterContainer").Visible = true;
			FactoryWreckingPanel panel = GetNode<FactoryWreckingPanel>("Panel");
			panel.Stop();
			if (!hasMoved)
			{
				panel.Position += new Vector2(971, 526);
				hasMoved = true;
			}

		}

	}

	public void _on_quit_button_pressed()
	{
		PlayerHandler.ChangeScene(this, "res://Scenes/WorldMap/World.tscn");
	}
	public void _on_redo_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://res://Scenes/Games/Industrial/FactoryWrecking/FactoryWrecking.tscn");
	}

}
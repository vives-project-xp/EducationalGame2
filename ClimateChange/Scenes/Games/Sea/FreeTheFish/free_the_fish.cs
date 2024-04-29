using Godot;
using System;
using System.Collections.Generic;
using System.Linq;

public partial class free_the_fish : Node2D
{
	private List<RigidBody2D> Boats = new()
	{
		ResourceLoader.Load<PackedScene>("res://Scenes/Games/Sea/FreeTheFish/FishBoat/fish_boat.tscn").Instantiate<RigidBody2D>(),
		ResourceLoader.Load<PackedScene>("res://Scenes/Games/Sea/FreeTheFish/FishBoat/fish_boat.tscn").Instantiate<RigidBody2D>(),
		ResourceLoader.Load<PackedScene>("res://Scenes/Games/Sea/FreeTheFish/FishBoat/fish_boat.tscn").Instantiate<RigidBody2D>(),
		ResourceLoader.Load<PackedScene>("res://Scenes/Games/Sea/FreeTheFish/FishBoat/fish_boat.tscn").Instantiate<RigidBody2D>(),
		ResourceLoader.Load<PackedScene>("res://Scenes/Games/Sea/FreeTheFish/FishBoat/fish_boat.tscn").Instantiate<RigidBody2D>(),
	};
	private Vector2 BoatSize = new();
	private Random random = new();
	private List<bool> BoatIsLeft = new();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetBoatSize();
		SetBoatsY();
		SetBoatDirections();
		AddBoats();
		SetBoatsOutOfScreen();
		ChangeBoatFrame(0, 0);
	}
	public void SetBoatDirections()
	{
		foreach (var _ in Boats)
		{
			if (random.Next(0, 2) == 0)
			{
				BoatIsLeft.Add(true);
			}
			else
			{
				BoatIsLeft.Add(false);
			}
		}
	}
	public void SetBoatsY()
	{
		foreach (RigidBody2D boat in Boats.Cast<RigidBody2D>())
		{
			boat.Position = new Vector2(boat.Position.X, random.Next(150, 1080));
		}

	}
	public void GetBoatSize()
	{
		BoatSize = Boats[0].GetNode<Sprite2D>("Boat").Texture.GetSize() * Boats[0].GetNode<Sprite2D>("Boat").Scale;
	}

	public void AddBoats()
	{
		foreach (RigidBody2D boat in Boats.Cast<RigidBody2D>()) AddChild(boat);
	}
	public void SetBoatOutOfScreen(int BoatIndex, bool Left)
	{
		if (Left)
		{
			Boats[BoatIndex].Position = new Vector2(-BoatSize.X / 2, Boats[BoatIndex].Position.Y);
		}
		else
		{
			Boats[BoatIndex].Position = new Vector2(1920 + BoatSize.X / 2, Boats[BoatIndex].Position.Y);
		}
	}
	public void SetBoatsOutOfScreen()
	{
		foreach (RigidBody2D boat in Boats.Cast<RigidBody2D>())
		{
			SetBoatOutOfScreen(Boats.IndexOf(boat), BoatIsLeft[Boats.IndexOf(boat)]);
		}
	}

	public void ChangeBoatPosition(int BoatIndex, Vector2 Position)
	{
		Boats[BoatIndex].Position = Position;
	}

	public void MoveBoatLeft(int BoatIndex, float Speed)
	{
		Boats[BoatIndex].Position += new Vector2(-Speed, 0);
	}

	public void MoveBoatRight(int BoatIndex, float Speed)
	{
		Boats[BoatIndex].Position += new Vector2(Speed, 0);
	}

	public void ChangeBoatFrame(int BoatIndex, int Frame)
	{
		Boats[BoatIndex].GetNode<Sprite2D>("Boat").Frame = Frame;
	}
	public void UpdateBoatsPosition(float speed)
	{
		// check all the boats if they move left or right and update their position
		foreach (RigidBody2D boat in Boats.Cast<RigidBody2D>())
		{
			if (!BoatIsLeft[Boats.IndexOf(boat)])
			{
				MoveBoatLeft(Boats.IndexOf(boat), speed);
			}
			else
			{
				MoveBoatRight(Boats.IndexOf(boat), speed);
			}
		}

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		UpdateBoatsPosition((float)delta * 200);
	}
}

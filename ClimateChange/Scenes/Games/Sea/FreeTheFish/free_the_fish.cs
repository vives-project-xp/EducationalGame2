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

	private PhysicsPointQueryParameters2D query = new PhysicsPointQueryParameters2D()
	{
		CollideWithAreas = true,
		CollideWithBodies = true,
	};
	private List<bool> BoatIsLeft = new();
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GetBoatSize();
		SetBoatsY();
		SetBoatDirections();
		AddBoats();
		SetBoatsOutOfScreen();

	}
	public void SetBoatDirections()
	{
		foreach (var _ in Boats) BoatIsLeft.Add(random.Next(0, 2) == 0);
	}
	public void SetBoatsY()
	{
		foreach (RigidBody2D boat in Boats.Cast<RigidBody2D>()) boat.Position = new Vector2(boat.Position.X, random.Next(150, 1080));

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
		if (Left) Boats[BoatIndex].Position = new Vector2(-BoatSize.X / 2, Boats[BoatIndex].Position.Y);
		else Boats[BoatIndex].Position = new Vector2(1920 + BoatSize.X / 2, Boats[BoatIndex].Position.Y);
	}
	public void SetBoatsOutOfScreen()
	{
		foreach (RigidBody2D boat in Boats.Cast<RigidBody2D>()) SetBoatOutOfScreen(Boats.IndexOf(boat), BoatIsLeft[Boats.IndexOf(boat)]);
	}

	public void ChangeBoatPosition(int BoatIndex, Vector2 Position)
	{
		Boats[BoatIndex].Position = Position;
	}

	public void MoveBoat(int BoatIndex, float Speed, bool isRight)
	{
		Boats[BoatIndex].Position += isRight ? new Vector2(Speed, 0) : new Vector2(-Speed, 0);
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
			MoveBoat(Boats.IndexOf(boat), speed, BoatIsLeft[Boats.IndexOf(boat)]);
		}

	}
	public void UpdateQuery()
	{
		query.Position = GetGlobalMousePosition();
	}
	public Godot.Collections.Dictionary UpdateCollisionShapeEntered()
	{
		if (GetWorld2D().DirectSpaceState.IntersectPoint(query).Count != 0)
		{
			return GetWorld2D().DirectSpaceState.IntersectPoint(query)[0];
		}
		return null;
	}


	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		UpdateBoatsPosition((float)delta * 100);
	}

	// input function
	public override void _Input(InputEvent @event)
	{
		if (@event is InputEventMouseButton eventMouseButton)
		{
			if (eventMouseButton.Pressed)
			{
				UpdateQuery();
				var col = UpdateCollisionShapeEntered();
				if (col != null)
				{
					ChangeBoatFrame(Boats.IndexOf((RigidBody2D)col["collider"]), 0);
				}
				GD.Print(col);

			}
		}
	}
}

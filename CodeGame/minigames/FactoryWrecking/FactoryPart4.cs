using Godot;
using System;

public partial class FactoryPart4 : RigidBody2D, IFactoryPart
{
	public int Health  {get; set; } = 15;

		[Export]
    public NodePath HealthBarPath { get; set; }

    private Healthbar HealthBar { get; set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AddToGroup("FactoryPart");
		HealthBar = (Healthbar)GetNode<ProgressBar>(HealthBarPath);
		HealthBar.MaxValue = Health;
		HealthBar.Value = Health;
		GD.Print("Health: " + Health);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

public void DecreaseHealth(int amount)
{
    GD.Print("DecreaseHealth: " + amount);
    Health -= amount;
    HealthBar.Value = Health;
    GD.Print("Health: " + Health);
}
}

using Godot;
using System;

public partial class factoryWrecking : Node2D
{
    bool dragging = false;
    Vector2 drag_start = new Vector2();

    HealthManager healthManager;

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        // Instantiate HealthManager
        Healthbar globalHealthBar = GetNode<Healthbar>("GlobalHealthBarPath"); // Replace with your actual path
        healthManager = new HealthManager(globalHealthBar);

        // Add parts to the HealthManager
        IFactoryPart part1 = new FactoryPart1();
        IFactoryPart part2 = new FactoryPart2();

        healthManager.AddPart(part1);
        healthManager.AddPart(part2);
    }


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
    }

}
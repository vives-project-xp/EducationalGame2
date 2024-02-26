using Godot;
using System;

public partial class wreckingball : RigidBody2D
{
    private bool dragging = false;
    private Vector2 dragStart = new Vector2();
    private const float Gravity = 200.0f;
    private const float DragForce = 1000.0f;

    private const float damage = 1;

    public override void _PhysicsProcess(double delta)
    {
        base._PhysicsProcess(delta);

        if (Input.IsActionPressed("click") && dragging == false)
        {
            dragStart = GetGlobalMousePosition();
            dragging = true;
        } else if (Input.IsActionPressed("click") && dragging == true)
        {
            Vector2 dragEnd = GetGlobalMousePosition();
            Vector2 dragDelta = dragEnd - dragStart;
            dragStart = dragEnd;
            ApplyForce(dragDelta * DragForce, new Vector2());
        } else if (Input.IsActionJustReleased("click"))
        {
            dragging = false;
        }
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }
}
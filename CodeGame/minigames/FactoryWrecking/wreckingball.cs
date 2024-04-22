using Godot;
using System;
using System.Diagnostics;

public partial class wreckingball : RigidBody2D
{
    private bool dragging = false;
    private Vector2 dragStart = new Vector2();
    private const float Gravity = 200.0F;
    private const float DragForce = 800f;

    private const int damage = 1;

    public override void _PhysicsProcess(double delta)
    {
        ProgressBar progressBar = GetNode<ProgressBar>("/root/FactoryWrecking/ProgressBar");

        if (progressBar.Value > 0)
        {
            if (Input.IsActionPressed("ui_click") && dragging == false)
            {
                dragStart = GetGlobalMousePosition();
                dragging = true;
            } 
            else if (Input.IsActionPressed("ui_click") && dragging == true)
            {
                Vector2 dragEnd = GetGlobalMousePosition();
                Vector2 dragDelta = (dragEnd - dragStart).Normalized();
                dragStart = dragEnd;
                ApplyForce(dragDelta * DragForce/(float)delta, new Vector2());
            } 
            else if (Input.IsActionJustReleased("ui_click"))
            {
                dragging = false;
            }
        }
    }

    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
    }

    private void OnBodyShapeEntered(int bodyID, Node body, int bodyShapeIndex, int LocalShapeIndex)
    {
       if (body is BaseFactoryPart part1)
        {
            part1.DecreaseHealth(damage);
            if (part1.Health <= 0)
            {
                part1.QueueFree();
            }
        }
    }
}
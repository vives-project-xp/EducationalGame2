using Godot;
using System;

public partial class wreckingball : RigidBody2D
{
    private bool dragging = false;
    private Vector2 dragStart = new Vector2();
    private const float Gravity = 200.0f;
    private const float DragForce = 5000.0f;

    private const int damage = 1;

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

    private void OnBodyShapeEntered(int bodyId, Node body, int bodyShape, int localShape)
    {
        if (body is FactoryPart1)
        {
            FactoryPart1 part1 = (FactoryPart1)body;
            part1.DecreaseHealth(damage);
            if (part1.Health <= 0)
            {
                part1.QueueFree();
            }
        }
        else if (body is FactoryPart2)
        {
            FactoryPart2 part2 = (FactoryPart2)body;
            part2.DecreaseHealth(damage);
            if (part2.Health <= 0)
            {
                part2.QueueFree();
            }
        }
        else if (body is FactoryPart3)
        {
            FactoryPart3 part3 = (FactoryPart3)body;
            part3.DecreaseHealth(damage);
            if (part3.Health <= 0)
            {
                part3.QueueFree();
            }
        }
        else if (body is FactoryPart4)
        {
            FactoryPart4 part4 = (FactoryPart4)body;
            part4.DecreaseHealth(damage);
            if (part4.Health <= 0)
            {
                part4.QueueFree();
            }
        }
        else if (body is FactoryPart5)
        {
            FactoryPart5 part5 = (FactoryPart5)body;
            part5.DecreaseHealth(damage);
            if (part5.Health <= 0)
            {
                part5.QueueFree();
            }
        }
        else if (body is FactoryPart6)
        {
            FactoryPart6 part6 = (FactoryPart6)body;
            part6.DecreaseHealth(damage);
            if (part6.Health <= 0)
            {
                part6.QueueFree();
            }
        }
        else if (body is FactoryPart7)
        {
            FactoryPart7 part7 = (FactoryPart7)body;
            part7.DecreaseHealth(damage);
            if (part7.Health <= 0)
            {
                part7.QueueFree();
            }
        }
    }
}
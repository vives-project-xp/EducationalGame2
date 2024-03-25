using Godot;
using System;
using System.Runtime.CompilerServices;

public partial class WateringPlants: Node2D
{
    
    private float velocity = 0;
    private float force = 0;
    private float height;
    private float targetHeight;
    

    private void WaterUpdate(float springConstant, float dampening)
    {
        height = Position.Y;
        float x = height - targetHeight;
        float loss = -dampening * velocity;
        force = -springConstant * x + loss;
        velocity += force;

        Position = new Vector2(Position.X, Position.Y + velocity);
    }

    private void Initialize(){
        height = Position.Y;
        targetHeight = Position.Y;
        velocity = 0;
    }

public override void _Ready()
{
    height = Position.Y;
    targetHeight = Position.Y + 80;
    this.SetPhysicsProcess(true); // Enable the PhysicsProcess
}

}
using Godot;
using System;
using System.Collections.Generic;

public partial class Spring : Node
{
    public float Velocity { get; set; } = 0;
    private float Force = 0;
    public float Height { get; private set; }
    private float TargetHeight;

    public void WaterUpdate(float springConstant, float dampening)
    {
        Height = TargetHeight;
        float x = Height - TargetHeight;
        float loss = -dampening * Velocity;
        Force = -springConstant * x + loss;
        Velocity += Force;
    }

    public void Initialize(float initialHeight)
    {
        Height = initialHeight;
        TargetHeight = initialHeight;
    }
}

public partial class water_body : Node2D
{
    [Export] private float k = 0.015f;
    [Export] private float d = 0.03f;
    [Export] private float spread = 0.0002f;

    private List<Spring> springs = new List<Spring>();
    private int passes = 8;

    public override void _Ready()
    {
    foreach (Node i in GetChildren())
    {
        if (i.GetType() == typeof(Spring))
        {
            Spring spring = (Spring)i;
            springs.Add(spring);
            spring.Initialize(spring.Height);
        }
    }

        Splash(2, 5); // Consider moving this outside the loop if it's meant to be called once.
    }

    public override void _PhysicsProcess(double delta)
    {
        foreach (Spring spring in springs)
        {
            spring.WaterUpdate(k, d);
        }

        List<float> leftDeltas = new List<float>(springs.Count);
        List<float> rightDeltas = new List<float>(springs.Count);

        for (int i = 0; i < springs.Count; i++)
        {
            leftDeltas.Add(0);
            rightDeltas.Add(0);
        }

        for (int j = 0; j < passes; j++)
        {
            for (int i = 0; i < springs.Count; i++)
            {
                if (i > 0)
                {
                    leftDeltas[i] = spread * (springs[i].Height - springs[i - 1].Height);
                    springs[i - 1].Velocity += leftDeltas[i];
                }

                if (i < springs.Count - 1)
                {
                    rightDeltas[i] = spread * (springs[i].Height - springs[i + 1].Height);
                    springs[i + 1].Velocity += rightDeltas[i];
                }
            }
        }
    }

    private void Splash(int index, float speed)
    {
        if (index > 0 && index < springs.Count)
        {
            springs[index].Velocity = speed;
        }
    }
}

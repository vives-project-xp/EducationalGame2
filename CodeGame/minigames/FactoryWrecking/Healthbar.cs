using Godot;
using System;
using System.Collections.Generic;

public partial class Healthbar : ProgressBar
{
    private int totalHealth;

    public void UpdateTotalHealth()
    {
        totalHealth = 15;

        // foreach (Node child in GetTree().GetNodesInGroup("FactoryPart"))
        // {
        //     if (child is IFactoryPart part)
        //     {
        //         totalHealth += part.Health;
        //     }
        // }

        this.MaxValue = totalHealth;
        this.Value = totalHealth;
    }

    public void UpdateHealth()
    {
        int currentHealth = 0;

        foreach (Node child in GetTree().GetNodesInGroup("FactoryPart"))
        {
            if (child is IFactoryPart part)
            {
                currentHealth += part.Health;
            }
        }

        this.Value = currentHealth;
    }

    public override void _Ready()
    {
        UpdateTotalHealth();
    }
}
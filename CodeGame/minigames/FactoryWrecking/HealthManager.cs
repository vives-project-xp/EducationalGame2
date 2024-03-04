using Godot;
using System;
using System.Collections.Generic;

public partial class HealthManager : Node
{
    private List<IFactoryPart> parts = new List<IFactoryPart>();
    private int totalHealth;
    private ProgressBar globalHealthBar;

    public HealthManager(ProgressBar globalHealthBar)
    {
        this.globalHealthBar = globalHealthBar;
    }

public void AddPart(IFactoryPart part)
{
    parts.Add(part);
    totalHealth += part.Health;
    UpdateHealth();
}

    public void UpdateHealth()
    {
        int currentHealth = 0;
        foreach (IFactoryPart part in parts)
        {
            currentHealth += part.Health;
        }
        globalHealthBar.Value = (float)currentHealth / 3 * 100;
    }
}
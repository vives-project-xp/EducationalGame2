using Godot;

public partial class Healthbar : ProgressBar
{
    private int totalHealth;

    public void UpdateTotalHealth()
    {
        totalHealth = 0;

        foreach (Node child in GetTree().GetNodesInGroup("FactoryPart"))
        {
            if (child is IFactoryPart part)
            {
                totalHealth += part.MaxHealth;
            }
        }

        MaxValue = totalHealth;
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

       Value = currentHealth;
    }

    public override void _Ready()
    {
        UpdateTotalHealth();
    }
    public override void _Process(double delta)
    {
        UpdateHealth();
    }
}
using Godot;
public partial class BaseFactoryPart : RigidBody2D, IFactoryPart
{
    public int MaxHealth { get; set; } = 1;
    public int Health { get; set; } = 1;


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        AddToGroup("FactoryPart"); 
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public void DecreaseHealth(int amount)
    {
        Health -= amount;

    }
    
}

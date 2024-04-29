using Godot;

public interface IFactoryPart
{
    int Health { get; }
    int MaxHealth { get; }
    void DecreaseHealth(int amount);
}
public interface IFactoryPart
{
    int Health { get; }
    void DecreaseHealth(int amount);
}
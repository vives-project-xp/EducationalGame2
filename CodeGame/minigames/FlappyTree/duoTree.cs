using Godot;
partial class duoTree
{
    // this is a class that will have 2 trees in it and a water drip
    public Tree[] tree = new Tree[2];
    public WaterDrip waterDrip;

    public duoTree(float x_pos)
    {
        tree[0] = new Tree
        {
            Top = true,
            ID = 0,
            Position = new Vector2(x_pos, 0)
        };
        tree[1] = new Tree
        {
            Top = false,
            ID = 0,
            Position = new Vector2(x_pos, 0)
        };
        waterDrip = new WaterDrip(x_pos);
    }


}
using Godot;

partial class Tree : Sprite2D
{
    public bool Top {get; set;}
    public int ID;

    public override void _Ready()
    {
        AddToGroup("Tree");
        Texture = GD.Load<Texture2D>("res://assets/Forest/Tree.png");
        // check if the tree is on top or bottom and position it accordingly +- flip it if its on the top
        if (Top)
        {
            Position = new Vector2(Position.X, GetTreeSize().Y / 2);
            FlipV = true;
        }
        else
        {
            Position = new Vector2(Position.X, GetNode<BirdCam>("/root/Flappy/BirdCam").GetViewportRect().Size.Y - GetTreeSize().Y / 2);
        }
    }
    public Vector2 GetTreeSize() => GetRect().Size * Scale;

    public Rect2 GetTrueRect() => new(Position - GetTreeSize() / 2, GetTreeSize());
}
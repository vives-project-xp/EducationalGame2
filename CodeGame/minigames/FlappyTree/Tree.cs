using System.Text.RegularExpressions;
using Godot;

partial class Tree : Sprite2D
{
    public Tree(Vector2 Position)
    {
        this.Position = Position;
    }
    public override void _Ready()
    {
        AddToGroup("Tree");
        Texture = GD.Load<Texture2D>("res://assets/Sea/LinePlastic.png");
        Scale = new Vector2(0.5f, 0.5f);
    }
}
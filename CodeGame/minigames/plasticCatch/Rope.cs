using System.Dynamic;
using Godot;
partial class Rope : Sprite2D
{
    private float Width { get; set; } = 8.9f;
    private float Height { get; set; } = 1432f;
    private float X { get; set; } = 1237.75f;
    private float Y { get; set; } = 38f;
    public override void _Ready()
    {
        Texture = GD.Load<Texture2D>("res://assets/Sea/LinePlastic.png");
        RegionEnabled = true;
        RegionRect = new Rect2(X, Y, Width, Height);
        // place in the middle of the screen
        float xSize = GetViewport().GetVisibleRect().Size.X;
        float ySize = GetViewport().GetVisibleRect().Size.Y;
        Position = new Vector2(xSize / 2, ySize / 8);
        Scale = new Vector2(0.5f, 0.5f);
    }
    public Vector2 getScaleForRange(){
        return new Vector2(0.5f, 0.5f);
    }
}
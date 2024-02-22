using System.Dynamic;
using Godot;
partial class Rope : Line2D
{
    public float XScale = 1383f / 1920;
    public float YScale = 84f / 1080;
    public override void _Ready()
    {
        DefaultColor = new Color(0.1f, 0.2f, 0.8f, 1f);
    }

    public override void _Process(double delta)
    {
        UpdateRope(GetGlobalMousePosition());
    }

    public void UpdateRope(Vector2 position)
    {
        Points = new Vector2[] { new(GetViewportRect().Size.X * XScale, GetViewportRect().Size.Y * YScale), position };
    }

}
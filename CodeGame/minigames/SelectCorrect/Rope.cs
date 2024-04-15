using System.Collections.Generic;
using Godot;
partial class Rope : Line2D
{
    public Vector2 Scaler = new(1383f / 1920, 84f / 1080);

    public override void _Ready()
    {
        // put color on a brownish tone
        DefaultColor = new Color(0.5f, 0.3f, 0.1f);
    }

    public override void _Process(double delta) => UpdateRope(GetGlobalMousePosition());

    public void UpdateRope(Vector2 mousePosition)
    {
        Vector2 endPoint = GetViewportRect().Size * Scaler;
        Vector2 distance = endPoint - mousePosition;
        // the more dist the more segments;
        float seg = distance.Length() / 10;

        // middle points
        List<Vector2> points = new() { mousePosition};
        for (int i = 0; i < seg; i++)
        {
            float alpha = distance.X/(seg*7);
            Vector2 newPoint = new() { X = mousePosition.X + distance.X * i / seg,  Y = mousePosition.Y - distance.Y * (1 - (float)Mathf.Cosh(alpha * i / seg))};
            points.Add(newPoint);
        }
        points.Add(endPoint);
        Points = points.ToArray();
    }

}
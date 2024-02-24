using System;
using System.Collections.Generic;
using Godot;
partial class Rope : Line2D
{
    public float XScale = 1383f / 1920;
    public float YScale = 84f / 1080;

    public override void _Ready()
    {
        DefaultColor = new Color(0.1f, 0.2f, 0.8f, 1f);
    }

    public override void _Process(double delta) => UpdateRope(GetGlobalMousePosition());
    
    // x of the point will step in the distance between the start and end point divided by the number of segments
    // y of the point will step exponentially from the position to the end point
    // the first point will be the mouse position
    // the middle points will be the middle points
    // the last point will be the end point
    public void UpdateRope(Vector2 mousePosition)
    {


        Vector2 endPoint = GetViewportRect().Size * new Vector2(XScale, YScale);
        Vector2 distance = (endPoint - mousePosition);
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
        
        GD.Print(points.ToArray().Length);

        Points = points.ToArray();
    }

}
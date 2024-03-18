using Godot;
using System;

public partial class FailedScreenEndlessMode : CanvasLayer
{

    public Label PointsLabel;
    public int points = 0;
    public int prevPoints = 0;
    public override void _Ready()
    {
        PointsLabel = new()
        {
            Text = "SCORE: 0",
            Position = new Vector2(830, 100),
            Modulate = new Color(1, 1, 1, 1),
            Visible = true
        };
        PointsLabel.Set("theme_override_font_sizes/font_size", 100);
        PointsLabel.AddToGroup("PointsLabel");
        AddChild(PointsLabel);
    }

    public void updatePoints()
    {
        PointsLabel.Text = "SCORE: " + PlayerHandler.prevStackingPoint.ToString();
        prevPoints = PlayerHandler.prevStackingPoint;
    }


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (PlayerHandler.prevStackingPoint != prevPoints) updatePoints();
    }
    public void _on_restart_button_pressed()
    {   
        PlayerHandler.prevStackingPoint = 0;
        PlayerHandler.stackingSetDificulty = PlayerHandler.StackingDificulty.Endless;
        GetTree().ChangeSceneToFile("res://minigames/Stacking/StackingGame.tscn");
    }
    public void _on_back_button_pressed()
    {
        GetTree().Quit();
    }

}

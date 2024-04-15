using Godot;
using System;

public partial class FailedScreenEndlessMode : CanvasLayer
{
    public Label PointsLabel;
    public Label HighscoreLabel;
    public double counter = 0;
    public override void _Ready()
    {
        PointsLabel = new()
        {
            Text = "SCORE: 0",
            Position = new Vector2(770, 100),
            Modulate = new Color(1, 1, 1, 1),
            Visible = true
        };
        PointsLabel.Set("theme_override_font_sizes/font_size", 100);
        PointsLabel.AddToGroup("PointsLabel");
        AddChild(PointsLabel);

        HighscoreLabel = new()
        {
            Text = "HIGHSCORE: 0",
            Position = new Vector2(800, 200),
            Modulate = new Color(1, 1, 1, 1),
            Visible = true
        };
        HighscoreLabel.Set("theme_override_font_sizes/font_size", 50);
        HighscoreLabel.AddToGroup("HighscoreLabel");
        AddChild(HighscoreLabel);
    }

    public void updatePoints()
    {
        PointsLabel.Text = "SCORE: " + PlayerHandler.prevStackingPoint.ToString();
        if(PlayerHandler.prevStackingPoint > PlayerHandler.stackingHighScore){
            PlayerHandler.stackingHighScore = PlayerHandler.prevStackingPoint;
        } 
        HighscoreLabel.Text = "HIGHSCORE: " + PlayerHandler.stackingHighScore;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    { 
        counter = counter + delta;
        if (counter > 0.1){
            updatePoints();
            counter = 0;
        }
    }
    public void _on_restart_button_pressed()
    {
        PlayerHandler.prevStackingPoint = 0;
        PlayerHandler.stackingSetDificulty = PlayerHandler.StackingDificulty.Endless;
        GetTree().ChangeSceneToFile("res://minigames/Stacking/StackingGame.tscn");
    }
    public void _on_back_button_pressed()
    {
        GetTree().ChangeSceneToFile("res://minigames/Stacking/start_screen.tscn");
    }

    public void _on_worldmap_button_pressed()
    {
        GetTree().ChangeSceneToFile("res://World/World.tscn");
    }
}
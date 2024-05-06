using Godot;
using System;

public partial class FailedScreenEndlessMode : CanvasLayer
{
    public Label PointsLabel;
    public Label HighscoreLabel;
    public double counter = 0;
    public override void _Ready()
    {
        if (PlayerHandler.CurrentLanguage == "English")
        {
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/RestartButton").Text = "RETRY";
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/BackButton").Text = "BACK";
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/WorldmapButton").Text = "WORLD MAP";
        }

        if (PlayerHandler.CurrentLanguage == "Nederlands")
        {
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/RestartButton").Text = "OPNIEUW PROBEREN";
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/BackButton").Text = "TERUG";
				GetNode<Button>("PanelContainer/MarginContainer/Rows/CenterContainer/VBoxContainer/WorldmapButton").Text = "WORLD MAP";
        }
    }

    public void updatePoints()
    {
        if (PlayerHandler.prevStackingPoint > PlayerHandler.stackingHighScore)
        {
            PlayerHandler.stackingHighScore = PlayerHandler.prevStackingPoint;
        }



        if (PlayerHandler.CurrentLanguage == "English")
        {
            GetNode<Label>("PanelContainer/MarginContainer/Rows/Score").Text = "Score :" + PlayerHandler.prevStackingPoint.ToString();
            GetNode<Label>("PanelContainer/MarginContainer/Rows/Highscore").Text = "High Score :" + PlayerHandler.stackingHighScore.ToString();
        }

        if (PlayerHandler.CurrentLanguage == "Nederlands")
        {
            GetNode<Label>("PanelContainer/MarginContainer/Rows/Score").Text = "Score :" + PlayerHandler.prevStackingPoint.ToString();
            GetNode<Label>("PanelContainer/MarginContainer/Rows/Highscore").Text = "Record Score :" + PlayerHandler.stackingHighScore.ToString();
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        counter = counter + delta;
        if (counter > 0.1)
        {
            updatePoints();
            counter = 0;
        }
    }
    public void _on_restart_button_pressed()
    {
        PlayerHandler.prevStackingPoint = 0;
        PlayerHandler.stackingSetDificulty = PlayerHandler.StackingDificulty.Endless;
        GetTree().ChangeSceneToFile("res://Scenes/Games/Industrial/Stacking/StackingGame.tscn");
    }
    public void _on_back_button_pressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/Games/Industrial/Stacking/start_screen.tscn");
    }

    public void _on_worldmap_button_pressed()
    {
        GetTree().ChangeSceneToFile("res://Scenes/WorldMap/World.tscn");
    }
}
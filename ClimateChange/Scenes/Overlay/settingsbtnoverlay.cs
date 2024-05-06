using Godot;
using System;

public partial class settingsbtnoverlay : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
	}

    public override void _Process(double delta)
    {
        if (GetTree().CurrentScene.SceneFilePath == "res://Scenes/MainMenu/main_menu.tscn" | 
		GetTree().CurrentScene.SceneFilePath == "res://Scenes/SettingsMenu/Settings.tscn" | 
		GetTree().CurrentScene.SceneFilePath == "res://Scenes/Games/Industrial/FactoryWrecking/Learning/learning_fabrieken.tscn"|
		GetTree().CurrentScene.SceneFilePath == "res://Scenes/Games/Industrial/Stacking/Learning/learning_windmolens.tscn"|
		GetTree().CurrentScene.SceneFilePath == "res://Scenes/Games/Sea/FreeTheFish/Learning/OverFishingLearning.tscn"|
		GetTree().CurrentScene.SceneFilePath == "res://Scenes/Games/Sea/OilCleanUp/Learning/OilLearning.tscn"|
		GetTree().CurrentScene.SceneFilePath == "res://Scenes/Games/Sea/PlasticCatch/Learning/LearningPlastic.tscn")
		{
			Visible = false;
		}
		else
		{
			Visible = true;
		}
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Pressed() => PlayerHandler.ChangeScene(this, "res://Scenes/SettingsMenu/Settings.tscn");

}

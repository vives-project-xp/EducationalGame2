using Godot;
using System;
using System.Collections.Generic;

partial class Hud : CanvasLayer
{
	public List<String> SettingsSceneList = new List<String> {
		"res://Scenes/WorldMap/World.tscn", "res://Scenes/Games/Industrial/FactoryWrecking/Learning/learning_fabrieken.tscn",
		"res://Scenes/Games/Industrial/Stacking/Learning/learning_windmolens.tscn", "res://Scenes/Games/Sea/FreeTheFish/Learning/OverFishingLearning.tscn",
		"res://Scenes/Games/Sea/OilCleanUp/Learning/OilLearning.tscn", "res://Scenes/Games/Sea/PlasticCatch/Learning/LearningPlastic.tscn",
		"res://Scenes/Games/Industrial/FactoryWrecking/FactoryWrecking.tscn","res://Scenes/Games/Industrial/Stacking/Stacking.tscn",
		"res://Scenes/Games/Sea/FreeTheFish/FreeTheFish.tscn","res://Scenes/Games/Sea/OilCleanUp/OilCleanUp.tscn",
		"res://Scenes/Games/Sea/PlasticCatch/PlasticCatch.tscn"
	};
	public override void _Ready()
	{

		GetNode<RichTextLabel>("moreGamesLabel").Visible = false;
		GetNode<Button>("moregamesbtnoverlay").Pressed += _on_moregamesbtnoverlay_pressed;
		GetNode<Button>("settingsbtnoverlay").Pressed += _on_settingsbtnoverlay_pressed;
		GetNode<Button>("moreGamesLabel/memoryBtnMoreGames").Pressed += _on_memoryBtnMoreGames_pressed;
		GetNode<Button>("moreGamesLabel/flappyTreeBtnMoreGames").Pressed += _on_flappyBtnMoreGames_pressed;
	}
	public void _on_flappyBtnMoreGames_pressed()
	{
		PlayerHandler.ChangeScene(this, "res://Scenes/Games/Forest/FlappyTree/Flappy.tscn");
	}

	public void _on_memoryBtnMoreGames_pressed()
	{
		PlayerHandler.ChangeScene(this, "res://Scenes/Games/Extra/Memory/Memory.tscn");
	}

	public void _on_moregamesbtnoverlay_pressed()
	{
		GetNode<RichTextLabel>("moreGamesLabel").Visible = !GetNode<RichTextLabel>("moreGamesLabel").Visible;
	}

	public void _on_settingsbtnoverlay_pressed()
	{
		PlayerHandler.ChangeScene(this, "res://Scenes/SettingsMenu/Settings.tscn");
	}
	public override void _Process(double delta)
	{
		base._Process(delta);
		switch (PlayerHandler.CurrentLanguage)
		{
			case "Nederlands":
				GetNode<Button>("settingsbtnoverlay").Text = "Instellingen";
				GetNode<Button>("moregamesbtnoverlay").Text = "Meer spellen";
				break;
			case "English":
				GetNode<Button>("settingsbtnoverlay").Text = "Settings";
				GetNode<Button>("moregamesbtnoverlay").Text = "More games";
				break;
		}

		// change visibility of more games button
		if (GetTree().CurrentScene.SceneFilePath == "res://Scenes/WorldMap/World.tscn")
		{
			GetNode<Button>("moregamesbtnoverlay").Visible = true;
		}
		else
		{
			GetNode<Button>("moregamesbtnoverlay").Visible = false;
			GetNode<RichTextLabel>("moreGamesLabel").Visible = false;

		}

		// change visibility of settings button
		if (SettingsSceneList.Contains(GetTree().CurrentScene.SceneFilePath))
		{
			GetNode<Button>("settingsbtnoverlay").Visible = true;
		}
		else
		{
			GetNode<Button>("settingsbtnoverlay").Visible = false;
		}
	}
}

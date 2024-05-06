using Godot;
using System;

partial class Hud : CanvasLayer
{

	public override void _Ready()
	{
		GetNode<RichTextLabel>("moreGamesLabel").Visible = false;
		GetNode<Button>("moregamesbtnoverlay").Pressed += _on_moregamesbtnoverlay_pressed;
		GetNode<Button>("settingsbtnoverlay").Pressed += _on_settingsbtnoverlay_pressed;
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
		if (GetTree().CurrentScene.SceneFilePath == "res://Scenes/WorldMap/World.tscn")
		{
			GetNode<Button>("moregamesbtnoverlay").Visible = true;
		}
		else
		{
			GetNode<Button>("moregamesbtnoverlay").Visible = false;
			GetNode<RichTextLabel>("moreGamesLabel").Visible = false;

		}
	}
}

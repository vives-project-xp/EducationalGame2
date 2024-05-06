using Godot;
using System;

public partial class SettingsMenuscript : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetVolume();
		GetNode<Button>("background/back").Pressed += () => PlayerHandler.ChangeScene(this, PlayerHandler.LastScene);
		GetNode<Button>("background/VBoxContainer/main_menu").Pressed += () => PlayerHandler.ChangeScene(this, "res://Scenes/MainMenu/main_menu.tscn");
		GetNode<Button>("background/VBoxContainer/language").Pressed += ChangeLanguage;
	}

	private void ChangeLanguage()
	{
		PlayerHandler.NextLanguage();
		GetNode<Button>("background/VBoxContainer/language").Text = PlayerHandler.CurrentLanguage;
	}

	private void SetVolume()
	{
		GetNode<Slider>("background/volume_slider").Value = PlayerHandler.GetVolume();
	}

	private int GetVolume()
	{
		return (int)GetNode<Slider>("background/volume_slider").Value;
	}

	private void UpdateVolume()
	{
		PlayerHandler.SetVolume(GetVolume());
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		// put all buttons in the right text
		GetNode<Button>("background/VBoxContainer/language").Text = PlayerHandler.CurrentLanguage;
		switch (PlayerHandler.CurrentLanguage)
		{
			case "English":
				GetNode<Button>("background/back").Text = "Back";
				GetNode<Button>("background/VBoxContainer/main_menu").Text = "Main Menu";
				break;
			case "Nederlands":
				GetNode<Button>("background/back").Text = "Terug";
				GetNode<Button>("background/VBoxContainer/main_menu").Text = "Hoofdmenu";
				break;
			default:
				break;
		}
		UpdateVolume();

	}
}

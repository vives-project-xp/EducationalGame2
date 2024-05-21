using Godot;
using System;
using System.Data.Common;

public partial class learning_windmolens : Node2D
{
	private double timer;
	private int photoNumer = 1;
	private double photoTimer = 0;
	public override void _Ready()
	{
		PlayerHandler.IsLearning = true;
		if (PlayerHandler.CurrentLanguage == "Nederlands")
		{
			AudioStream NL = (AudioStream)GD.Load("res://Scenes/Games/Industrial/Stacking/Learning/Voice/NL/speech.mp3");
			AudioStreamPlayer musicPlayer = new()
			{
				Stream = NL,
				Autoplay = true,
				VolumeDb = 0,
			};
			NL.Set("loop", false);
			AddChild(musicPlayer);
			musicPlayer.Play();
			photoTimer = 8;
		}

		if (PlayerHandler.CurrentLanguage == "English")
		{
			AudioStream ENG = (AudioStream)GD.Load("res://Scenes/Games/Industrial/Stacking/Learning/Voice/ENG/SpeechWindmolenENG.mp3");
			AudioStreamPlayer musicPlayer = new()
			{
				Stream = ENG,
				Autoplay = true,
				VolumeDb = 0,
			};
			ENG.Set("loop", false);
			AddChild(musicPlayer);
			musicPlayer.Play();
			photoTimer = 7.6;
		}
	}
	public override void _Process(double delta)
	{
		timer += delta;
		if (timer >= photoTimer)
		{
			photoNumer++;
			timer = 0;
			//8
			if (photoNumer < 8)
			{
				GetNode<TextureRect>($"{photoNumer - 1}").Visible = false;
				GetNode<TextureRect>($"{photoNumer}").Visible = true;
			}
		}
		if (photoNumer == 8)
		{
			PlayerHandler.StackingLearning = true;
			PlayerHandler.IsLearning = false;
			GetTree().ChangeSceneToFile("res://Scenes/Games/Industrial/Stacking/start_screen.tscn");
		}
	}
	public void _on_skip_button_pressed()
	{
		timer = photoTimer;
	}
}

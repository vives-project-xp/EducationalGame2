using Godot;
using System;

public partial class OilLearning : Node2D
{
	private double timer;
	private int photoNumer = 1;
	private double photoTimer;
	public override void _Ready()
	{
		PlayerHandler.IsLearning = true;
		if (PlayerHandler.CurrentLanguage == "Nederlands")
		{
			AudioStream NL = (AudioStream)GD.Load("res://Scenes/Games/Sea/OilCleanUp/Learning/voice/NL/speech.mp3");
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
			AudioStream ENG = (AudioStream)GD.Load("res://Scenes/Games/Sea/OilCleanUp/Learning/voice/ENG/OilSpeechENG1.mp3");
			AudioStreamPlayer musicPlayer = new()
			{
				Stream = ENG,
				Autoplay = true,
				VolumeDb = 0,
			};
			ENG.Set("loop", false);
			AddChild(musicPlayer);
			musicPlayer.Play();
			photoTimer = 8.1;
		}
	}
	public override void _Process(double delta)
	{
		timer += delta;
		if (timer >= photoTimer){
			photoNumer ++;
			timer = 0;
			if(photoNumer < 9){
				GetNode<TextureRect>($"{photoNumer - 1}").Visible = false;
				GetNode<TextureRect>($"{photoNumer}").Visible = true;
			}
		}
		if(photoNumer == 10){
			PlayerHandler.IsLearning = false;
			PlayerHandler.OilLeaning = true;
			GetTree().ChangeSceneToFile("res://Scenes/Games/Sea/OilCleanUp/oilCleaning.tscn");
		}
	}
}

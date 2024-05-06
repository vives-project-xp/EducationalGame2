using Godot;
using System;

public partial class OverFishingLearning : Node2D
{
	private double timer;
	private int photoNumer = 1;
	private double photoTimer; 
	public override void _Ready()
	{
		if (PlayerHandler.CurrentLanguage == "Nederlands")
		{
			AudioStream NL = (AudioStream)GD.Load("res://Scenes/Games/Sea/FreeTheFish/Learning/voice/NL/speech.mp3");
			AudioStreamPlayer musicPlayer = new()
			{
				Stream = NL,
				Autoplay = true,
				VolumeDb = 0,
			};
			NL.Set("loop", false);
			AddChild(musicPlayer);
			musicPlayer.Play();
			photoTimer = 8.39;
		}

		if (PlayerHandler.CurrentLanguage == "English")
		{
			AudioStream ENG = (AudioStream)GD.Load("res://Scenes/Games/Sea/FreeTheFish/Learning/voice/ENG/speech.mp3");
			AudioStreamPlayer musicPlayer = new()
			{
				Stream = ENG,
				Autoplay = true,
				VolumeDb = 0,
			};
			ENG.Set("loop", false);
			AddChild(musicPlayer);
			musicPlayer.Play();
			photoTimer = 7.8;
		}
	}
	public override void _Process(double delta)
	{
		timer += delta;
		if (timer >= photoTimer){
			photoNumer ++;
			timer = 0;
			if(photoNumer < 11){
				GetNode<TextureRect>($"{photoNumer - 1}").Visible = false;
				GetNode<TextureRect>($"{photoNumer}").Visible = true;
			}
		}
		if(photoNumer == 12){
			PlayerHandler.OverFishingLearning= true;
			GetTree().ChangeSceneToFile("res://Scenes/Games/Sea/FreeTheFish/free_the_fish.tscn");
		}
	}
}

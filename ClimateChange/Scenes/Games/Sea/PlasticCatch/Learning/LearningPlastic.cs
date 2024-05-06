using Godot;
using System;

public partial class LearningPlastic : Node2D
{
	private double timer;
	private int photoNumer = 1;
	private double photoTimer;
	public override void _Ready()
	{
		if (PlayerHandler.CurrentLanguage == "Nederlands")
		{
			AudioStream NL = (AudioStream)GD.Load("res://Scenes/Games/Sea/PlasticCatch/Learning/voice/NL/PlasticSpeechNL.mp3");
			AudioStreamPlayer musicPlayer = new()
			{
				Stream = NL,
				Autoplay = true,
				VolumeDb = 0,
			};
			NL.Set("loop", false);
			AddChild(musicPlayer);
			musicPlayer.Play();
			photoTimer = 7;
		}

		if (PlayerHandler.CurrentLanguage == "English")
		{
			AudioStream ENG = (AudioStream)GD.Load("res://Scenes/Games/Sea/PlasticCatch/Learning/voice/ENG/PlasticSpeechENG.mp3");
			AudioStreamPlayer musicPlayer = new()
			{
				Stream = ENG,
				Autoplay = true,
				VolumeDb = 0,
			};
			ENG.Set("loop", false);
			AddChild(musicPlayer);
			musicPlayer.Play();
			photoTimer = 6.87;
		}
	}
	public override void _Process(double delta)
	{
		timer += delta;
		if (timer >= 0.1){
			photoNumer ++;
			timer = 0;
			if(photoNumer < 9){
				GetNode<TextureRect>($"{photoNumer - 1}").Visible = false;
				GetNode<TextureRect>($"{photoNumer}").Visible = true;
			}
		}
		if(photoNumer == 10){
			PlayerHandler.PlasticLeaning = true;
			GetTree().ChangeSceneToFile("res://Scenes/Games/Sea/PlasticCatch/PlasticCatch.tscn");
		}
	}
}

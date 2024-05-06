using Godot;
using System;

public partial class learning_fabrieken : Node2D
{
	// Called every frame. 'delta' is the elapsed time since the previous frame.

	/*
		0-30sec fabriekuitstoot 4 
		30-50sec water vervuild 3  
		50-1:20sec  bossen kappot 5+1
		1:20 - 1:32 random  2

		15 totaal iedere 6.1sec
	*/

	private double timer;
	private double photoTimer = 0;
	private int photoNumer = 1;
	public override void _Ready()
	{
		if (PlayerHandler.CurrentLanguage == "Nederlands")
		{
			AudioStream NL = (AudioStream)GD.Load("res://Scenes/Games/Industrial/FactoryWrecking/Learning/voice/NL/speech.mp3");
			AudioStreamPlayer musicPlayer = new()
			{
				Stream = NL,
				Autoplay = true,
				VolumeDb = 0,
			};
			NL.Set("loop", false);
			AddChild(musicPlayer);
			musicPlayer.Play();
			photoTimer = 6.2;
		}

		if (PlayerHandler.CurrentLanguage == "English")
		{
			AudioStream ENG = (AudioStream)GD.Load("res://Scenes/Games/Industrial/FactoryWrecking/Learning/voice/ENG/FabriekVoiceENG.mp3");
			AudioStreamPlayer musicPlayer = new()
			{
				Stream = ENG,
				Autoplay = true,
				VolumeDb = 0,
			};
			ENG.Set("loop", false);
			AddChild(musicPlayer);
			musicPlayer.Play();
			photoTimer = 6.5;
		}
	}
	public override void _Process(double delta)
	{
		timer += delta;
		if (timer >= photoTimer){
			photoNumer ++;
			timer = 0;
			if(photoNumer < 16){
				GetNode<TextureRect>($"{photoNumer - 1}").Visible = false;
				GetNode<TextureRect>($"{photoNumer}").Visible = true;
			}
		}
		if(photoNumer == 16){
			PlayerHandler.FactoryLeaning = true;
			GetTree().ChangeSceneToFile("res://Scenes/Games/Industrial/FactoryWrecking/FactoryWrecking.tscn");
		}
	}
}

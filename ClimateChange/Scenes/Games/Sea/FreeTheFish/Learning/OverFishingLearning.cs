using Godot;
using System;

public partial class OverFishingLearning : Node2D
{
	private double timer;
	private int photoNumer = 1;
	public override void _Ready()
	{
		AudioStream musicStream = (AudioStream)GD.Load("res://Scenes/Games/Sea/FreeTheFish/Learning/voice/NL/speech.mp3");

		 AudioStreamPlayer musicPlayer = new()
		 {
		 	Stream = musicStream,
		 	Autoplay = true,
			VolumeDb = 0,
		};
		musicStream.Set("loop", false);
		AddChild(musicPlayer);
		musicPlayer.Play();
	}
	public override void _Process(double delta)
	{
		GD.Print(photoNumer);
		timer += delta;
		if (timer >= 9.05){
			photoNumer ++;
			timer = 0;
			if(photoNumer < 12){
				GetNode<TextureRect>($"{photoNumer - 1}").Visible = false;
				GetNode<TextureRect>($"{photoNumer}").Visible = true;
			}
		}
		if(photoNumer == 11){
			GetTree().ChangeSceneToFile("res://Scenes/Games/Sea/FreeTheFish/free_the_fish.tscn");
		}
	}
}

using Godot;
using System;

public partial class LearningPlastic : Node2D
{
	private double timer;
	private int photoNumer = 1;
	public override void _Ready()
	{
		AudioStream musicStream = (AudioStream)GD.Load("res://Scenes/Games/Sea/PlasticCatch/Learning/voice/NL/PlasticSpeechNL.mp3");

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
		timer += delta;
		if (timer >= 7){
			photoNumer ++;
			timer = 0;
			if(photoNumer < 9){
				GetNode<TextureRect>($"{photoNumer - 1}").Visible = false;
				GetNode<TextureRect>($"{photoNumer}").Visible = true;
			}
		}
		if(photoNumer == 10){
			GetTree().ChangeSceneToFile("res://Scenes/Games/Sea/PlasticCatch/PlasticCatch.tscn");
		}
	}
}

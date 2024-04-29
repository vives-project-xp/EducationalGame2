using Godot;
using System;
using System.Data.Common;

public partial class learning_windmolens : Node2D
{
	private double timer;
	private int photoNumer = 1;
	public override void _Ready()
	{
		AudioStream musicStream = (AudioStream)GD.Load("res://Scenes/Games/Industrial/Stacking/Learning/Voice/NL/speech.mp3");

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
		//8
		if (timer >= 1){
			photoNumer ++;
			timer = 0;
			//8
			if(photoNumer < 8){
				GetNode<TextureRect>($"{photoNumer - 1}").Visible = false;
				GetNode<TextureRect>($"{photoNumer}").Visible = true;
			}
		}
		if(photoNumer == 8){
			GetTree().ChangeSceneToFile("res://Scenes/Games/Industrial/Stacking/start_screen.tscn");
		}
	}
}

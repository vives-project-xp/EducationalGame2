using Godot;
using System;

public partial class stars2D : Godot.Sprite2D
{

	private double sec, prevsec;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Hframes=12;
		Frame = 0;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		sec += delta;
		NextFrame2();
	}

		public void NextFrame2()
	{
		if(sec - prevsec > 0.1)
		{
			prevsec = sec;
        Frame = (Frame + 1) % 12;
		}
	}
}

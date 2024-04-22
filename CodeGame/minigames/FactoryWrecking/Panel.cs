using Godot;
using System;

public partial class Panel : Godot.Panel
{
	// Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        timer_on = true;
        SetProcess(true); // Enable processing
    }

    public double time = 0.0f;
    public int minutes = 0;
    public int seconds = 0;
    public int msec = 0;
	bool timer_on = false;

    public void Stop()
    {
        SetProcess(false);
    }

    public override void _Process(double delta)
    {
        if (!timer_on) return;

        time += delta;
        msec = (int)(time % 1 * 100);
        seconds = (int)(time % 60);
        minutes = (int)(time % 3600 / 60);

         GetNode<Label>("Label").Text = minutes.ToString("00") + ":";
         GetNode<Label>("Label2").Text = seconds.ToString("00") + ".";
         GetNode<Label>("Label3").Text = msec.ToString("000");
    }
}

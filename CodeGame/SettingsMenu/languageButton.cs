using Godot;
using System;

public partial class languageButton : Button
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		Text = PlayerHandler.CurrentLanguage;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}

    public override void _Pressed()
    {
		// change the language button text to the next language in the list
		int index = PlayerHandler.Languages.IndexOf(PlayerHandler.CurrentLanguage);
		index++;
		index %= PlayerHandler.Languages.Count;
		PlayerHandler.CurrentLanguage = PlayerHandler.Languages[index];
		Text = PlayerHandler.CurrentLanguage;
    }
}

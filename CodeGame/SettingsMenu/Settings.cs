using Godot;
using System.Collections.Generic;
public partial class Settings : Node2D
{
	private CenterElements cont;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// add back button to the scene
		AddChild(new BGDyn("res://assets/MainMenu/Untitled.png"));
		AddChild(new BackButton());
		// Create a new GridContainer containing launguageButton and mainMenuButton
		cont = new CenterElements(new VBContainer(new Control[] { new mainMenuButton(), new languageButton() }, 100));
		AddChild(cont);
		AddChild(new VolumeSlider());
	}
}

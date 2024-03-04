using Godot;
using System.Collections.Generic;
public partial class Settings : Node2D
{
	private VBContainer cont;
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		// add back button to the scene
		AddChild(new BackButton());
		// Create a new GridContainer containing launguageButton and mainMenuButton
		cont = new VBContainer(new List<Button> { new mainMenuButton(), new languageButton() });
		AddChild(cont);
		cont.SetPositionCenter();
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

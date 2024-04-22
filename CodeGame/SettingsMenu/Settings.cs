using Godot;
using System.Linq;
public partial class Settings : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		HUD._Visible = false;

		// add back button to the scene
		AddChild(new BGDyn("res://assets/MainMenu/Untitled.png"));
		// Create a new GridContainer containing launguageButton and mainMenuButton
		AddChild(new CenterElements(new VBContainer(new Control[] { new mainMenuButton(), new languageButton() }, 100)));
		AddChild(new SettingsBackButton());
		AddChild(new VolumeSlider());
	}
	public override void _ExitTree()
	{
		base._ExitTree();
		// get all children and remove them
		GetChildren().Cast<Node>().ToList().ForEach(child => { child.QueueFree(); RemoveChild(child); });
	}
}

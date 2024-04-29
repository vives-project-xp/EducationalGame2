using Godot;
using System.Linq;
public partial class main_menu : Node2D
{
	public override void _Ready()
	{
		AddChild(new BGDyn("res://Scenes/MainMenu/Assets/Untitled.png"));
		AddChild(new CenterElements(new VBContainer(new Control[] { new PlayButton(), new SettingsButton() }, 100)));

	}
	public override void _ExitTree()
	{
		base._ExitTree();
		// get all children and remove them
		GetChildren().Cast<Node>().ToList().ForEach(child => { child.QueueFree(); RemoveChild(child); });
	}
}

using System.Linq;
using Godot;
public partial class MainMenu : Node2D
{ 
	public override void _Ready()
	{
		AddChild(new BGDyn("res://assets/MainMenu/Untitled.png"));
		// check if _container is already created
		AddChild(new CenterElements(new VBContainer(new Control[] { new PlayButton(), new SettingsButton() }, 100)));
	}
	public override void _ExitTree()
	{
		base._ExitTree();
		// get all children and remove them
		GetChildren().Cast<Node>().ToList().ForEach(child => { child.QueueFree(); RemoveChild(child); });
	}
}

using Godot;
using System.Linq;
public partial class main_menu : Node2D
{
	public override void _Ready()
	{
		GetNode<Button>("background/CenterContainer/container/play").Pressed += () => PlayerHandler.ChangeScene(this, "res://Scenes/WorldMap/World.tscn"); 
		GetNode<Button>("background/CenterContainer/container/settings").Pressed += () => PlayerHandler.ChangeScene(this, "res://Scenes/SettingsMenu/Settings.tscn");

	}
	public override void _ExitTree()
	{
		base._ExitTree();
		// get all children and remove them
		GetChildren().Cast<Node>().ToList().ForEach(child => { child.QueueFree(); RemoveChild(child); });
	}
}

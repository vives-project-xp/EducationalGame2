using Godot;
public partial class MainMenu : Node2D
{
	private CenterElements _Container;
	public override void _Ready()
	{
		AddChild(new BGDyn("res://assets/MainMenu/Untitled.png"));
		// check if _container is already created
		_Container = new CenterElements(new VBContainer(new Control[] { new PlayButton(), new SettingsButton() }, 100));
        AddChild(_Container);
	}
    public override void _ExitTree()
    {
        base._ExitTree();
		foreach (Node child in GetChildren()){
			child.QueueFree();
		}
    }
}

using Godot;
public partial class EndScreen : CenterContainer
{
	public void _on_quit_button_pressed()
	{
		GetTree().Quit();
	}
	public void _on_redo_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/Games/Industrial/FactoryWrecking/FactoryWrecking.tscn");
	}
}

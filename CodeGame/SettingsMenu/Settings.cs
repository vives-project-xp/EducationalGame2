using Godot;

public partial class Settings : Node2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		setLanguage();
		AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Master"), PlayerHandler.Volume);
		GetNode<Slider>("Background/VolumeSlider").Value = PlayerHandler.Volume;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
	public void _on_back_pressed() => GetTree().ChangeSceneToFile(PlayerHandler.LastScene);

	public void _on_main_menu_pressed() => GetTree().ChangeSceneToFile("res://MainMenu/Main.tscn");

	public void _on_language_pressed() 
	{
		changeLanguage();
	}
	public void _on_h_slider_value_changed(float value) => AudioServer.SetBusVolumeDb(AudioServer.GetBusIndex("Master"), value);

	public void setLanguage() => GetNode("Background/language").Set("text", PlayerHandler.CurrentLanguage);
	public void changeLanguage()
	{
		// change the language button text to the next language in the list
		int index = PlayerHandler.Languages.IndexOf(PlayerHandler.CurrentLanguage);
		index++;
		index %= PlayerHandler.Languages.Count;
		PlayerHandler.CurrentLanguage = PlayerHandler.Languages[index];
		GetNode("Background/language").Set("text", PlayerHandler.CurrentLanguage);
	}
}

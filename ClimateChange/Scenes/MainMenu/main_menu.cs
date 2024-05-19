using Godot;
using System.Linq;
public partial class main_menu : Node2D
{
	public override void _Ready()
	{
		var playBtn = GetNode<Button>("background/CenterContainer/container/play");
		var settingsBtn = GetNode<Button>("background/CenterContainer/container/settings");
		var Title = GetNode<RichTextLabel>("Title");

		playBtn.Pressed += () => PlayerHandler.ChangeScene(this, "res://Scenes/WorldMap/World.tscn");
		settingsBtn.Pressed += () => PlayerHandler.ChangeScene(this, "res://Scenes/SettingsMenu/Settings.tscn");

		switch (PlayerHandler.CurrentLanguage)
		{
			case "Nederlands":
				playBtn.Text = "Spelen";
				settingsBtn.Text = "Instellingen";
				Title.Text = "[rainbow freq=0.15 sat=1 val=1.5]Red het klimaat[/rainbow]";
				break;
			case "English":

				playBtn.Text = "Play";
				settingsBtn.Text = "Settings";
				Title.Text = "[rainbow freq=0.15 sat=1 val=1.5]Save the climate[/rainbow]";
				break;
		}

	}
	public override void _ExitTree()
	{
		base._ExitTree();
		// get all children and remove them
		GetChildren().Cast<Node>().ToList().ForEach(child => { child.QueueFree(); RemoveChild(child); });
	}
}

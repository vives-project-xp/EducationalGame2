using System.Collections.Generic;
using Godot;
public partial class MainMenu : Node2D
{
	private VBContainer cont;
	public override void _Ready()
	{
		AddChild(new BGDyn("res://assets/MainMenu/Untitled.png"));
		cont = new VBContainer(new List<Button> { new PlayButton(), new SettingsButton()});		
		AddChild(cont);
		cont.SetPositionCenter();
	}
}

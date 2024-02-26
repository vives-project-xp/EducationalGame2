using System.Collections.Generic;
using Godot;
public partial class MainMenu : Node2D
{
	public GridContainer _GridContainer;
	public override void _Ready()
	{
		AddChild(new BGDyn("res://assets/MainMenu/Untitled.png"));
		_GridContainer = new _GridContainer(new List<Button>{new PlayButton(), new SettingsButton()}, 1, new Vector2(100 , 0),PlayerHandler.screenPosition.center );
		AddChild(_GridContainer);
	}
}

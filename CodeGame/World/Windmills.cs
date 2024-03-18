using Godot;
using System;

public partial class Windmills : TextureButton
{
    public override void _Pressed() => PlayerHandler.ChangeScene(this, "res://minigames/Stacking/start_screen.tscn");
}

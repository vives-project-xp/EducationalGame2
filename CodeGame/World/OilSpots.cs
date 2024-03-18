using Godot;
using System;

public partial class OilSpots : TextureButton
{
    // Called when the node enters the scene tree for the first time.
    public override void _Pressed()
    {
		PlayerHandler.ChangeScene(this, "res://minigames/MemoryGame/Memory.tscn");
    }
}

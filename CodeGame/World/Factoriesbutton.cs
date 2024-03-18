using Godot;

public partial class Factoriesbutton : TextureButton
{
	public override void _Pressed() => PlayerHandler.ChangeScene(this, "res://minigames/FactoryWrecking/factoryWrecking.tscn");
	
}

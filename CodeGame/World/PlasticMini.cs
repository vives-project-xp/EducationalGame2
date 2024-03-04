using Godot;
public partial class PlasticMini : TextureButton
{
    public override void _Pressed()
    {
		GetTree().ChangeSceneToFile("res://minigames/plasticCatch/PlasticCatch.tscn");
    }
}

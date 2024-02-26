using Godot;
partial class Card : TextureButton
{
    //constructor 
    public Card(string TexturePath, Vector2 size){
        TextureNormal = ResourceLoader.Load<Texture2D>(TexturePath);
        IgnoreTextureSize = true;
        StretchMode = StretchModeEnum.KeepAspectCentered;
        Size = size/8;
    }
    public override void _Ready(){}
}

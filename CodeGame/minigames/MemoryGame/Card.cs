using Godot;
partial class Card : TextureButton
{
    public Texture2D _TextureNormal;
    //constructor 
    public Card(string TexturePath){
    
        _TextureNormal = ResourceLoader.Load<Texture2D>(TexturePath);
        TextureNormal = ResourceLoader.Load<Texture2D>("res://assets/Industrial/blank.png");
    }
}
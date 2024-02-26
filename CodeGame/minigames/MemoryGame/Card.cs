using Godot;
partial class Card : TextureButton
{
    public Texture2D _TextureNormal;
    public bool flipped { get; set;}
    //constructor 
    public Card(string TexturePath){
    
        _TextureNormal = ResourceLoader.Load<Texture2D>(TexturePath);
        TextureNormal = ResourceLoader.Load<Texture2D>("res://assets/Sea/Sea_backcard.png");
    }

    public override void _Pressed(){
        TextureNormal = _TextureNormal;
        flipped = true;
    }
}
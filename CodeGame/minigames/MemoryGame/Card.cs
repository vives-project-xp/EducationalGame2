using System.Diagnostics;
using Godot;
partial class Card : TextureButton
{
    public Texture2D _TextureNormal;
    public bool done { get; set; }
    public bool flipped { get; set;}
    public bool selected { get; set; } = false;
    //constructor 
    public Card(string TexturePath){
    
        _TextureNormal = ResourceLoader.Load<Texture2D>(TexturePath);
        TextureNormal = ResourceLoader.Load<Texture2D>("res://assets/Sea/Sea_backcard.png");
    }

    public override void _Pressed(){
        TextureNormal = _TextureNormal;
        selected = true;
        flipped = true;
    }
    public override void _Process(double delta){
        TextureNormal = flipped ? _TextureNormal : ResourceLoader.Load<Texture2D>("res://assets/Sea/Sea_backcard.png");
    }
}
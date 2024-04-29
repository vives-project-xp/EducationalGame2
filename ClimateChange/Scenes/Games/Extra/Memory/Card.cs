using Godot;
partial class Card : TextureButton
{
    public Texture2D frontcard;
    public Texture2D backcard;
    public bool done { get; set; }
    public bool flipped { get; set;}
    public bool selected { get; set; } = false;
    //constructor 
    public Card(string TexturePath){
    
        frontcard = ResourceLoader.Load<Texture2D>(TexturePath);
        backcard = ResourceLoader.Load<Texture2D>("res://assets/Sea/Sea_backcard.png");
        IgnoreTextureSize = true;
        StretchMode = StretchModeEnum.KeepAspectCentered;
        CustomMinimumSize = new Vector2(250, 250);
        
    }

    public override void _Pressed(){
        TextureNormal = frontcard;
        selected = true;
        flipped = true;
    }
    public override void _Process(double delta){
        TextureNormal = flipped ? frontcard : backcard;
    }
}
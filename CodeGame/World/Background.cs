using Godot;
partial class BGWorld : TextureRect
{
    
    public override void _Ready()
    {
        Texture = GD.Load<Texture2D>("res://Assets/World/Landen.png");
        ExpandMode = ExpandModeEnum.IgnoreSize;
    }
    public override void _Process(double delta)
    {
        Size = GetViewportRect().Size;   
    }
}
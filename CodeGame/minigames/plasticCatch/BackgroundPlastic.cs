using Godot;
partial class BGPlastic : TextureRect
{
    public override void _Ready()
    {
        Texture = GD.Load<Texture2D>("res://assets/Sea/background_plastic.png");
        ExpandMode = TextureRect.ExpandModeEnum.IgnoreSize;
        Size = GetViewport().GetVisibleRect().Size;
    }
    public override void _Process(double delta)
    {
        Size = GetViewport().GetVisibleRect().Size;
    }
}
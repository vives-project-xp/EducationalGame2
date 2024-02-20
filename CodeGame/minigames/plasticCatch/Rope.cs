using Godot;
partial class Rope : TextureRect
{
    public override void _Ready()
    {
        Texture = GD.Load<Texture2D>("res://assets/Sea/LinePlastic.png");
        float xSize = GetViewport().GetVisibleRect().Size.X;
        float ySize = GetViewport().GetVisibleRect().Size.Y;
        Position = new Vector2(xSize / 2, ySize / 8);
    }
}
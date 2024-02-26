using Godot;
partial class ClawForMobile : TouchScreenButton
{
    public override void _Ready()
    {
        Name = "clawForMobile";
        // set the texture of the claw
        TextureNormal = GD.Load<Texture2D>("res://assets/Sea/claws.png");
        // set the position of the claw
        float xSize = GetViewport().GetVisibleRect().Size.X;
        float ySize = GetViewport().GetVisibleRect().Size.Y;
        Position = new Vector2(xSize / 2, ySize / 8);
        // set the scale of the claw
        Scale = new Vector2(0.1f, 0.1f);
    }
    public Rect2 GetRect()
    {
        return new Rect2(Position, TextureNormal.GetSize() * Scale);
    }
}
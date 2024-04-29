using Godot;
partial class HBContainer : HBoxContainer
{
    public void SetPositionCenter()
    {
        Position = GetViewportRect().Size / 2 - new Vector2(Size.X, Size.Y / 2);
    }
}
using Godot;

partial class CenterElements : CenterContainer
{
    public CenterElements(params Control[] elements)
    {
        foreach (Control element in elements)
        {
            AddChild(element);
        }
    }
    public override void _Process(double delta) => Size = GetViewportRect().Size;
}
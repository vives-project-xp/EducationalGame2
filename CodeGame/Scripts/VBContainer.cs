using System.Collections.Generic;
using Godot;
partial class VBContainer : VBoxContainer
{
    public VBContainer(List<Button> buttons) {
        foreach (Button button in buttons) {
            AddChild(button);
        } 
    }
    public void SetPositionCenter()
    {
        Position = GetViewportRect().Size / 2 - new Vector2(Size.X, Size.Y / 2);
    }
}
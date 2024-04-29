using System;
using Godot;
partial class VBContainer : VBoxContainer
{
    public VBContainer(Control[] controls, int Seperation = 0) {
        Set("theme_override_constants/separation", Seperation);
        foreach (Control control in controls) {
            AddChild(control);
        } 
    }

    public static implicit operator VBContainer(CenterElements v)
    {
        throw new NotImplementedException();
    }
}
using Godot;
partial class GRID : GridContainer
{
    public Vector2 _Size;
    public GRID(Control[] controls, int v_separation = 0, int h_separation = 0)
    {
        foreach (var control in controls)
        {
            AddChild(control);
        }
        Columns = 5;
        // put vertical separation between the cards
        Set("theme_override_constants/v_separation", v_separation);
        Set("theme_override_constants/h_separation", h_separation);
    }
}
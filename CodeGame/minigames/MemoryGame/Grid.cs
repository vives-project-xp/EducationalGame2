using Godot;
partial class GRID : GridContainer
{
    public Vector2 _Size;
    public GRID(Control[] controls,Vector2 size, int v_separation = 0, int h_separation = 0)
    {
        foreach (var control in controls)
        {
            AddChild(control);
        }
        _Size = size;
        Columns = 5;
        Scale = new Vector2(500, 300) / _Size;
        // put vertical separation between the cards
        Set("theme_override_constants/v_separation", v_separation);
        Set("theme_override_constants/h_separation", h_separation);
    }
    public override void _Process(double delta)
    {
        Scale = new Vector2(500, 300) / _Size;
    }
}
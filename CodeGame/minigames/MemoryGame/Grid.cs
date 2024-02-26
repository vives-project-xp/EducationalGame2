using Godot;
partial class GRID : GridContainer
{
    public Vector2 _Size;
    public GRID(Vector2 size)
    {
        _Size = size;
        Columns = 5;
        Scale = new Vector2(500, 300) / _Size;
        // put vertical separation between the cards
        Set("theme_override_constants/v_separation", 500);
        Set("theme_override_constants/h_separation", 250);
        Position = _Size * new Vector2(0.18f, 0.18f);
    }
    public override void _Process(double delta)
    {
        Scale = new Vector2(500, 300) / _Size;
    }
}
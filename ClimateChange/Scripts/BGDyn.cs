using Godot;
partial class BGDyn : TextureRect
{
    public PlayerHandler.RectSizes _Size;
    public BGDyn(string Path, PlayerHandler.RectSizes size = PlayerHandler.RectSizes.Fullscreen) 
    { 
        _Size = size;
        PlayerHandler.SetBackground(this, Path); 
    }
    public override void _Process(double delta)
    {
        PlayerHandler.SetBackgroundSize(this, _Size);
    }
}
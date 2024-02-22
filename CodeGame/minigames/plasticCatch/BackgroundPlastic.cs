using Godot;
partial class BGPlastic : TextureRect
{
    public override void _Ready() => PlayerHandler.SetBackground(this, "res://assets/Sea/background_plastic.png");
    public override void _Process(double delta) => PlayerHandler.SetBackgroundSize(this);
}
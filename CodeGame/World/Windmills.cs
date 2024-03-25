using Godot;
using System;

public partial class Windmills : TextureButton
{

    public override void _Ready()
    {
        SetPivotCenter();
    }
    public void SetPivotCenter()
    {
        Vector2 center = new(GetRect().Size.X / 2, GetRect().Size.Y / 2);
        PivotOffset = center;
    }
    public override void _Pressed() => PlayerHandler.ChangeScene(this, "res://minigames/Stacking/start_screen.tscn");
    public override void _Input(InputEvent @event)
    {
        // check if mouse is on this button
        if (@event is InputEventMouseMotion mouseMotion)
        {
            if (GetGlobalRect().HasPoint(mouseMotion.Position))
            {
                Scale = new Vector2(1.4f, 1.4f);
            }
            else
            {
                Scale = new Vector2(1, 1);
            }
        }
    }

}

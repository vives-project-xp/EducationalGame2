using System.Collections.Generic;
using Godot;
partial class _GridContainer : GridContainer
{

    public PlayerHandler.screenPosition position;
    public _GridContainer(List<Button> nodes, int colums, Vector2 V_H_seperator, PlayerHandler.screenPosition position)
    {

        Columns = colums;
        Set("theme_override_constants/v_separation", V_H_seperator.X);
        GD.Print(Get("theme_override_constants/V_separation"));
        Set("theme_override_constants/h_separation", V_H_seperator.Y);
        foreach (Button child in nodes) AddChild(child);
        this.position = position;

    }
    public override void _Ready()
    {
        switch (position)
        {
            case PlayerHandler.screenPosition.start:
                Position = new Vector2();
                break;
            case PlayerHandler.screenPosition.center:
                Position = GetViewportRect().Size /2 - new Vector2(Size.X, Size.Y/2);
                break;
        }
    }
}
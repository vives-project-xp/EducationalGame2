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
  	public override void _Process(double delta)
	{
		// bop efect
		
		if (GetGlobalRect().HasPoint(GetGlobalMousePosition()))
			{
				Scale = new Vector2(1.4f, 1.4f);
            GetNode<RichTextLabel>("RichTextLabel_stacking").Visible = true;
            GetNode<Sprite2D>("Popup_stacking").Visible = true;
			}
			else
			{
				GetNode<RichTextLabel>("RichTextLabel_stacking").Visible = false;
            	GetNode<Sprite2D>("Popup_stacking").Visible = false;
				Bop((float)delta);
			}
	}

  	public bool Enlarge = false;
	public void Bop(float d)
	{

		// bop efect
		if (Enlarge) Scale += new Vector2(d, d) * 0.1f;
		else Scale -= new Vector2(d, d) * 0.1f;

		if (Scale.X > 1.1)
		{
			Scale = new Vector2(1.1f, 1.1f);
			Enlarge = false;
		}
		else if (Scale.X < 1f)
		{
			Scale = new Vector2(1f, 1f);
			Enlarge = true;
		}

	}


}

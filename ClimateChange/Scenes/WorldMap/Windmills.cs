using Godot;
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
	public override void _Pressed()
	{
		if (PlayerHandler.StackingLearning == false)
		{
			PlayerHandler.ChangeScene(this, "res://Scenes/Games/Industrial/Stacking/Learning/learning_windmolens.tscn");
		}
		else
		{
			PlayerHandler.ChangeScene(this, "res://Scenes/Games/Industrial/Stacking/start_screen.tscn");
		}
	}
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


		if (PlayerHandler.levelCompleted == 1)
		{
			TextureNormal = GD.Load<Texture2D>("res://Scenes/WorldMap/Assets/Molen/Bronzewind.png");
		}
		else if (PlayerHandler.levelCompleted == 2)
		{
			TextureNormal = GD.Load<Texture2D>("res://Scenes/WorldMap/Assets/Molen/Silverwind.png");
		}
		else if (PlayerHandler.levelCompleted == 3)
		{
			TextureNormal = GD.Load<Texture2D>("res://Scenes/WorldMap/Assets/Molen/Goldwind.png");
		}
		else if (PlayerHandler.levelCompleted == 4)
		{
			TextureNormal = GD.Load<Texture2D>("res://Scenes/WorldMap/Assets/Molen/Colorwind.png");
		}
	}

	public bool Enlarge = false;
	public void Bop(float d)
	{
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

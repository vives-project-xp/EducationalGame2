using Godot;
public partial class PlasticMini : TextureButton
{
	public override void _Ready()
	{
		SetPivotCenter();
	}
	public void SetPivotCenter()
	{
		Vector2 center = new(GetRect().Size.X / 2, GetRect().Size.Y / 2);
		PivotOffset = center;
		if (PlayerHandler.CurrentLanguage == "Nederlands")
		{
			GetNode<RichTextLabel>("RichTextLabel_plastic").Text = "[center][b]Zee[/b]\nRuim het plastiek op\nMoeilijkheid: gemakkelijk\n[img width=250]res://Scenes/WorldMap/Assets/screenshot_sea.png[/img][/center]";
		}
		else
		{
			GetNode<RichTextLabel>("RichTextLabel_plastic").Text = "[center][b]Sea[/b]\nClean the ocean\nDifficulty: easy\n[img width=250]res://Scenes/WorldMap/Assets/screenshot_sea.png[/img][/center]";
		}
	}
	public override void _Pressed()
	{
		if (PlayerHandler.PlasticLeaning == false)
		{
			PlayerHandler.ChangeScene(this, "res://Scenes/Games/Sea/PlasticCatch/Learning/LearningPlastic.tscn");
		}
		else
		{
			PlayerHandler.ChangeScene(this, "res://Scenes/Games/Sea/PlasticCatch/PlasticCatch.tscn");
		}
	}
	public override void _Process(double delta)
	{
		// bop efect

		if (GetGlobalRect().HasPoint(GetGlobalMousePosition()))
		{
			Scale = new Vector2(1.4f, 1.4f);
			GetNode<RichTextLabel>("RichTextLabel_plastic").Visible = true;
			GetNode<Sprite2D>("Popup_plastic").Visible = true;
		}
		else
		{

			GetNode<RichTextLabel>("RichTextLabel_plastic").Visible = false;
			GetNode<Sprite2D>("Popup_plastic").Visible = false;
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

using Godot;

public partial class Factoriesbutton : TextureButton
{
	public override void _Ready()
	{
		SetPivotCenter();
		if (PlayerHandler.CurrentLanguage == "Nederlands")
		{
			GetNode<RichTextLabel>("RichTextLabel_factory").Text = "[center][b]Industrie[/b]\nSloop de fabriek\nMoeilijkheid: gemiddeld\n[img width=250]res://Scenes/WorldMap/Assets/screenshot_factory.png[/img][/center]";
		}
		else
		{
			GetNode<RichTextLabel>("RichTextLabel_factory").Text = "[center][b]Industrial[/b]\nDestroy the Factory\nDifficulty: medium\n[img width=250]res://Scenes/WorldMap/Assets/screenshot_factory.png[/img][/center]";
		}
	}
	public void SetPivotCenter()
	{
		Vector2 center = new(GetRect().Size.X / 2, GetRect().Size.Y / 2);
		PivotOffset = center;
	}

	public override void _Process(double delta)
	{
		// bop efect

		if (GetGlobalRect().HasPoint(GetGlobalMousePosition()))
		{
			Scale = new Vector2(1.4f, 1.4f);
			GetNode<RichTextLabel>("RichTextLabel_factory").Visible = true;
			GetNode<Sprite2D>("Popup_factory").Visible = true;
		}
		else
		{
			GetNode<RichTextLabel>("RichTextLabel_factory").Visible = false;
			GetNode<Sprite2D>("Popup_factory").Visible = false;
			Bop((float)delta);
		}

		if (PlayerHandler.levelCompletedFactory == 1)
		{
			TextureNormal = GD.Load<Texture2D>("res://Scenes/WorldMap/Assets/ecofactory.png");
		}
	}

	public override void _Pressed()
	{
		if (PlayerHandler.FactoryLeaning == false)
		{
			PlayerHandler.ChangeScene(this, "res://Scenes/Games/Industrial/FactoryWrecking/Learning/learning_fabrieken.tscn");
		}
		else
		{
			PlayerHandler.ChangeScene(this, "res://Scenes/Games/Industrial/FactoryWrecking/FactoryWrecking.tscn");
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

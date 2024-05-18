using Godot;
public partial class Boats : TextureButton
{
	public bool Enlarge = false;
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Ready()
	{
		SetPivotCenter();
		if (PlayerHandler.CurrentLanguage == "Nederlands")
		{
			GetNode<RichTextLabel>("RichTextLabel_fish").Text = "[center][b]Zee[/b]\nHelp de vissen\nMoeilijkheid: gemakkelijk\n[img width=250]res://Scenes/WorldMap/Assets/screenshot_fish.png[/img][/center]";
		}
		else
		{
			GetNode<RichTextLabel>("RichTextLabel_fish").Text = "[center][b]Sea[/b]\nFree the fish\nDifficulty: easy\n[img width=250]res://Scenes/WorldMap/Assets/screenshot_fish.png[/img][/center]";
		}
	}

	public override void _Pressed()
	{
		if (PlayerHandler.OverFishingLearning == false)
		{
			PlayerHandler.ChangeScene(this, "res://Scenes/Games/Sea/FreeTheFish/Learning/OverFishingLearning.tscn");
		}
		else
		{
			PlayerHandler.ChangeScene(this, "res://Scenes/Games/Sea/FreeTheFish/free_the_fish.tscn");
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
			GetNode<RichTextLabel>("RichTextLabel_fish").Visible = true;
			GetNode<Sprite2D>("Popup_fish").Visible = true;
		}
		else
		{
			GetNode<RichTextLabel>("RichTextLabel_fish").Visible = false;
			GetNode<Sprite2D>("Popup_fish").Visible = false;
			Bop((float)delta);
		}

		if (PlayerHandler.levelCompletedFish == 1)
		{
			TextureNormal = GD.Load<Texture2D>("res://Scenes/WorldMap/Assets/boat_colorfish.png");
		}
	}

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

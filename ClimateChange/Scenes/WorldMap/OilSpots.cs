using Godot;
using System;

public partial class OilSpots : TextureButton
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		SetPivotCenter();
		if (PlayerHandler.CurrentLanguage == "Nederlands")
		{
			GetNode<RichTextLabel>("RichTextLabel_oil").Text = "[center][b]Zee[/b]\nRuim de olie op\nMoeilijkheid: gemakkelijk\n[img width=250]res://Scenes/WorldMap/Assets/screenshot_oil.png[/img][/center]";
		}
		else
		{
			GetNode<RichTextLabel>("RichTextLabel_oil").Text = "[center][b]Sea[/b]\nClean the ocean of oil\nDifficulty: easy\n[img width=250]res://Scenes/WorldMap/Assets/screenshot_oil.png[/img][/center]";
		}
		GetNode<Sprite2D>("stars2D").Visible = false;
	}
	public void SetPivotCenter()
	{
		Vector2 center = new(GetRect().Size.X / 2, GetRect().Size.Y / 2);
		PivotOffset = center;
	}
	public override void _Pressed()
	{
		if (PlayerHandler.OilLeaning == false)
		{
			PlayerHandler.ChangeScene(this, "res://Scenes/Games/Sea/OilCleanUp/Learning/OilLearning.tscn");
		}
		else
		{
			PlayerHandler.ChangeScene(this, "res://Scenes/Games/Sea/OilCleanUp/oilCleaning.tscn");
		}
	}

	public override void _Process(double delta)
	{
		// bop efect

		if (GetGlobalRect().HasPoint(GetGlobalMousePosition()))
		{
			Scale = new Vector2(1.4f, 1.4f);
			GetNode<RichTextLabel>("RichTextLabel_oil").Visible = true;
			GetNode<Sprite2D>("Popup_oil").Visible = true;
		}
		else
		{
			GetNode<RichTextLabel>("RichTextLabel_oil").Visible = false;
			GetNode<Sprite2D>("Popup_oil").Visible = false;
			Bop((float)delta);
		}

		if (PlayerHandler.levelCompletedOil == 1)
		{
			GetNode<Sprite2D>("stars2D").Visible = true;
			TextureNormal = null;
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

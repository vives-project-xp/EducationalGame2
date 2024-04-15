using Godot;
public partial class Boats : TextureButton
{
	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Ready()
	{
		SetPivotCenter();
	}
	public void SetPivotCenter()
	{
		Vector2 center = new(GetRect().Size.X / 2, GetRect().Size.Y / 2);
		PivotOffset = center;
	}
	public override void _Process(double delta)
	{
		// bop efect
		Bop((float)delta);
	}
	public bool Enlarge = false;
	public void Bop(float d)
	{

		// bop efect
		if (Enlarge) Scale += new Vector2(d, d);
		else Scale -= new Vector2(d, d);

		if (Scale.X > 1.3f)
		{
			Scale = new Vector2(1.3f, 1.3f);
			Enlarge = false;
		}
		else if (Scale.X < 1f)
		{
			Scale = new Vector2(1f, 1f);
			Enlarge = true;
		}

	}
}

using Godot;
using System.Collections.Generic;

public partial class Flappy : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private List<duoTree> Trees = new();
	private int TreeCount;
	public int points = 0;
	public int prevPoints = 0;
	public bool isBirdDead = false;

	// points label
	public Label PointsLabel;
	public override void _Ready()
	{
		PointsLabel = new()
		{
			Text = "0",
			Position = new Vector2(100, 100),
			Modulate = new Color(1, 1, 1, 1),
			Visible = true
		};
		PointsLabel.AddToGroup("PointsLabel");
		AddChild(new Bird());
		AddChild(new BirdCam());
		GenerateTree();
		AddTree();
		AddChild(PointsLabel);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		ResetPosition();
		UpdateLabelPosition();

		// if points get updated update the label
		if (points != prevPoints) updatePoints();
	}
	public void UpdateLabelPosition()
	{
		PointsLabel.Position = new Vector2(GetNode<BirdCam>("BirdCam").Position.X + 100, 100);
	}
	public void updatePoints()
	{
		PointsLabel.Text = points.ToString();
		prevPoints = points;
	}

	public void ResetPosition()
	{
		TreePosition();
		WaterDripPosition();


	}
	public void TreePosition()
	{
		foreach (var tree in GetTree().GetNodesInGroup("Tree"))
		{
			if (tree is Tree t && t.Position.X < GetNode<BirdCam>("BirdCam").Position.X - 500)
			{ t.Position = new Vector2(t.Position.X + 3000, t.Position.Y); }
		}

	}
	public void WaterDripPosition()
	{
		foreach (var waterDrip in GetTree().GetNodesInGroup("WaterDrip"))
		{
			if (waterDrip is WaterDrip w && w.Position.X < GetNode<BirdCam>("BirdCam").Position.X - 500)
			{
				w.Position = new Vector2(w.Position.X + 3000, w.Position.Y);
				// enable the water drip again
				w.Visible = true;
				w.hit = false;
			}
		}
	}
	public void GenerateTree()
	{
		for (int i = 0; i < 10; i++) Trees.Add(new duoTree(i * 300 + 500));
	}
	public void AddTree()
	{
		foreach (var bundel in Trees)
		{
			AddChild(bundel.tree[0]);
			AddChild(bundel.tree[1]);
			AddChild(bundel.waterDrip);
		}
	}
}

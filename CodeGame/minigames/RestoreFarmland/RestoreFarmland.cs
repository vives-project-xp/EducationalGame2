using Godot;

public partial class RestoreFarmland : Node2D
{
	// Called when the node enters the scene tree for the first time.

	public Tiles tiles = new();
	public override void _Ready()
	{
		tiles.WindowSize = GetViewportRect().Size;
		AddChild(tiles);

	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}


public partial class Tiles : TileMap
{
	// Called when the node enters the scene tree for the first time.
	public Vector2I cellSize;
	public Vector2 WindowSize { get; set; }
	public int rows = 10;
	public int cols = 10;
	public TileSet _TileSet
	{
		get { return TileSet; }
		set { TileSet = value; }
	}
	public override void _Ready()
	{
		_TileSet = GD.Load<TileSet>("res://Textures/Tiles.tres");
		// TileSet.TileSize = new Vector2I((int)WindowSize.X / cols, (int)WindowSize.Y / rows);
		// SetCell(0, new Vector2I(0, 0), 0, new Vector2I(2, 2));
		// SetCell(0, new Vector2I(0, 1), 0, new Vector2I(2, 2));
		// SetCell(0, new Vector2I(1, 0), 0, new Vector2I(2, 2));
		SetCell(0, new Vector2I(1, 1), 0, new Vector2I(2, 2));
		
	}

	public override void _Process(double delta)
	{
	}
	public override void _Input(InputEvent @event)
	{

		if (@event is InputEventMouseButton)
		{
			if (@event.IsActionPressed("ui_click"))
			{
				var mousePos = GetGlobalMousePosition();
				var cellPos = LocalToMap(mousePos);
				// get the cell at the cellPos
				SetCell(0, cellPos, 0, new Vector2I(2, 2));
				GD.Print(cellPos);
			}
		}
	}

	public void AddCell(Vector2I cellPos, int layer = 0)
	{
		SetCell(layer, cellPos, 0, new Vector2I(2, 2));
	}

}
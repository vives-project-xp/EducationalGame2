using Godot;
public partial class Stacking : Node2D
{
	// Called when the node enters the scene tree for the first time.
	private StackingBlock block { get; set; }
	public override void _Ready()
	{
		GD.Print("Hello, World!");
		block = new StackingBlock();
		AddChild(block);
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		
	}

	partial class StackingBlock : Sprite2D
	{
		public int difficulty = 1;
		public override void _Ready()
		{
			Name = "Block";
			Texture = GD.Load<Texture2D>("res://assets/Untitled.png");
			Position = new Vector2(200, 200);
			// Scale = new Vector2(0.5f, 0.5f);
		}
        public override void _Process(double delta)
        {
			if (Position.X > 1800) {
				GoLeft();
			}
			else
			{
                GoRight();
            }

        }
        public override void _Input(InputEvent @event)
        {
			//mousebutton left 
			if (@event is InputEventMouseButton mouseButton)
			{
				QueueFree();
			}
        }
        private void GoRight() => Position += new Vector2(30f / difficulty, 0);
        private void GoLeft() => Position -= new Vector2(30f / difficulty, 0);

    }
}

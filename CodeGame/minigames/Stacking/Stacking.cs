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
        public bool movingRight { get; set; } = true;

		public int difficulty = 1;
        public bool running {get; set;} = true;
        private float stoppos {get; set;} 
		public override void _Ready()
		{
			Name = "Block";
			Texture = GD.Load<Texture2D>("res://assets/Untitled.png");
			Position = new Vector2(200, 200);
			// Scale = new Vector2(0.5f, 0.5f);
		}
        public override void _Process(double delta)
        {

            // Moving the block from left to right
            if (movingRight && running)
            {
                if (Position.X < 1720)
                {
                    GoRight();
                }
                else 
                {
                    movingRight = !movingRight;

                }
            }
            else if (!movingRight && running) 
            {
                if (Position.X >= 200)
                {
                    GoLeft();
                }
                else
                {
                    movingRight = !movingRight;
                }
            }
            else
            {
                Position = Position.Lerp(new Vector2(stoppos, 1080), 0.1f);
            }
        }



        public override void _Input(InputEvent @event)
        {
			//mousebutton left 
			if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
			{
                running = false;
                stoppos = Position.X;
                
			}
        }
        private void GoRight() => Position += new Vector2(10f / difficulty, 0);
        private void GoLeft() => Position -= new Vector2(10f / difficulty, 0);
        private void FallBlock() => Position += new Vector2(0, 100f);

    }
}

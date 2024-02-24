using Godot;
public partial class Stacking : Node2D
{
    // Called when the node enters the scene tree for the first time.
    private StackingBlock block { get; set; }
    private bool running = false;
    private float stoppos;
    private int blockCounter = 1;
    public override void _Ready()
    {
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (running == false)
        {
            block = new StackingBlock(blockCounter);
            AddChild(block);
            running = !running;
        }

    }
    public override void _Input(InputEvent @event)
    {
        //mousebutton left 
        if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
        {
            running = false;
            block.stoppos = block.Position.X;
            block.running = false;
            blockCounter++;
            GD.Print(blockCounter);
        }
    }

    partial class StackingBlock : TextureRect
    {
        public int id { get; set; }
        public StackingBlock(int id)
        {
            this.id = id;
        }
        public bool movingRight { get; set; } = true;

        public int difficulty = 1;
        public bool running = true;
        public float stoppos { get; set; }
        public override void _Ready()
        {
            Name = "Block";
            Texture = GD.Load<Texture2D>("res://assets/Industrial/wind-turbine2.png");
            Position = new Vector2(200, 200);
            Size = new Vector2(200,200);
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
               
                Position = Position.Lerp(new Vector2(stoppos, (890- 200* id)), 0.1f);
            }
        }

        private void GoRight() => Position += new Vector2(30f / difficulty, 0);
        private void GoLeft() => Position -= new Vector2(30f / difficulty, 0);

    }
}

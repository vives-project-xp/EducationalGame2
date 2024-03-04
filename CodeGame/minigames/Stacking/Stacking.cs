using Godot;

public partial class Stacking : Node2D
{
    // Called when the node enters the scene tree for the first time.
    private StackingBlock block { get; set; }
    private bool running = false;
    private float stoppos;
    public int blockCounter = 1;

    private Camera camera = new();
    public int PrecisionDifficulty = 10;       // tussen 0 en 119 0 makelijk 119 moeilijk

    public override void _Ready()
    {
        AddChild(camera);
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (running == false)
        {
            block = new StackingBlock(blockCounter);
            camera.i = blockCounter;
            AddChild(block);
            running = !running;
        }
    }
    public override void _Input(InputEvent @event)
    {

        //mousebutton left 
        if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
        {
            // precision
            running = false;
            if (block.Position.X >= 744 + PrecisionDifficulty && block.Position.X <= 984 - PrecisionDifficulty)
            {
                block.stoppos = 864;
            }
            else
            {
                block.stoppos = block.Position.X;
                block.failed = true;
            }

            block.running = false;
            blockCounter++;
        }
    }


    partial class Camera : Camera2D
    {
        public int i { get; set; } = 0;
        private int cameraYcord = 540;
        public override void _Process(double delta)
        {
            //moves camera
            if (i <= 3)
            {
                Position = new Vector2(960, cameraYcord);
            }
            else
            {
                cameraYcord -= 192;
                Position = Position.Lerp(new Vector2(960, cameraYcord), 0.1f);
                i -= i;
            }
        }
    }

    partial class StackingBlock : TextureRect
    {
        public int id { get; set; }
        public StackingBlock(int id)
        {
            this.id = id;
        }
        public int failedTimer = 0;
        public bool movingRight { get; set; } = true;
        public int speedDifficulty = 20;
        public bool running = true;
        public bool failed ;
        public int yCordinateStartValue = 200;
        public float stoppos { get; set; }
        public override void _Ready()
        {
            Name = "Block";
            //loading difrent textures
                if (id == 1)
                {
                    Texture = GD.Load<Texture2D>("res://assets/Industrial/wind-turbine2.png");
                }
                else if (id == 2)
                {
                    Texture = GD.Load<Texture2D>("res://assets/Industrial/wind-turbine-base3.png");
                }
                else if (id == 3)
                {
                    Texture = GD.Load<Texture2D>("res://assets/Industrial/wind-turbine-base4.png");
                }
                else if (id == 4)
                {
                    Texture = GD.Load<Texture2D>("res://assets/Industrial/wind-turbine-base5.png");
                }
                else if (id == 5)
                {
                    Texture = GD.Load<Texture2D>("res://assets/Industrial/wind-turbine-base6.png");
                }

                // makes the blok move with the camera
                if (id > 3)
                {
                    Position = new Vector2(200, 8 - ((id - 4) * 192));
                }
                else
                {
                    Position = new Vector2(200, yCordinateStartValue);

                }
                Size = new Vector2(192, 192);
        }
        public override void _Process(double delta)
        {
            // Moving the block from left to right
            if (failedTimer == 30)
            {
                GetTree().ChangeSceneToFile("res://minigames/Stacking/gameoverscreen.tscn");
            }
            if (failed)
            {
                failedTimer = failedTimer + 1;
            }

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
                Position = Position.Lerp(new Vector2(stoppos, (889 - 192 * id)), 0.1f);
            }
        }
        private void GoRight() => Position += new Vector2(1f * speedDifficulty, 0);
        private void GoLeft() => Position -= new Vector2(1f * speedDifficulty, 0);
    }
}
using System.Linq.Expressions;
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
        block = new StackingBlock(blockCounter);
        camera.i = blockCounter;
        camera.id = blockCounter;
        AddChild(block);
        running = !running;
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        if (running == false)
        {
            if (block.failed == false)
            {
                block = new StackingBlock(blockCounter);
                camera.i = blockCounter;
                camera.id = blockCounter;
                AddChild(block);
                running = !running;
            }
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
        public int id { get; set; } = 0;
        private int cameraYcord = 540;
        private double ZoomoutTimer = 0;
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
            if (id == 10)
            {
                ZoomoutTimer += delta;
                if (ZoomoutTimer <2){
                    Zoom = Zoom.Lerp(new Vector2(0.17f, 0.17f), (float)delta);
                }

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
        public double failedTimer = 0;
        public double succedTimer = 0;
        public bool movingRight { get; set; } = true;
        public int speedDifficulty = 20;
        public bool running = true;
        public bool failed;
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
            else if (id == 6)
            {
                Texture = GD.Load<Texture2D>("res://assets/Industrial/wind-turbine-base-7.png");
            }
            else if (id == 7)
            {
                Texture = GD.Load<Texture2D>("res://assets/Industrial/wind-turbine-base8.png");
            }
            else if (id == 8)
            {
                Texture = GD.Load<Texture2D>("res://assets/Industrial/wind-turbine-base9.png");
            }
            else if (id == 9)
            {
                Texture = GD.Load<Texture2D>("res://assets/Industrial/wind-turbine-top.png");
            }
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
            if (failedTimer >= 1.2)
            {
                GetTree().ChangeSceneToFile("res://minigames/Stacking/gameoverscreen.tscn");
            }
            if (failed)
            {
                failedTimer += delta;
            }
            if (id == 10 && failed == false)
            {
                succedTimer += delta;
            }
            if(succedTimer > 2){
                GetNode("../FinishWiek").Set("visible", true);
            }
            if (succedTimer >= 4)
            {
                GetTree().ChangeSceneToFile("res://minigames/Stacking/completedscreen.tscn");
            }


            if (movingRight && running)
            {
                if (Position.X < 1720)
                {
                    GoRight((float)delta);
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
                    GoLeft((float)delta);
                }
                else
                {
                    movingRight = !movingRight;
                }
            }
            else
            {
                Position = Position.Lerp(new Vector2(stoppos, (889 - 192 * id)), 2 * (float)delta);
            }
        }
        private void GoRight(float delta) => Position += new Vector2(30 * speedDifficulty * delta, 0);
        private void GoLeft(float delta) => Position -= new Vector2(30 * speedDifficulty * delta, 0);
    }
}
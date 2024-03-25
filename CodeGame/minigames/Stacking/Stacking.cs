using System;
using System.Runtime.CompilerServices;
using Godot;
// i have to get the signal somewhere in here
public partial class Stacking : Node2D
{
    // Called when the node enters the scene tree for the first time.
    public PlayerHandler.StackingDificulty Level;
    private StackingBlock block { get; set; }
    private bool running = false;
    private float stoppos;
    public int blockCounter = 1;
    private Camera camera = new();
    public int PrecisionDifficulty = 10;       // tussen 0 en 119 0 makelijk 119 moeilijk
    public double BlockSpawnTimer = 0;
    // Score 
    public Label PointsLabel;
    public int prevPoints;
    private int yCordsScore = 100;
    public double blockMovement, _blockMovement;

    public override void _Ready()
    {

        Level = PlayerHandler.stackingSetDificulty;
        AddChild(camera);
        block = new StackingBlock(blockCounter);
        camera.i = blockCounter;
        camera.id = blockCounter;
        AddChild(block);
        running = !running;

        // add label for score
        PointsLabel = new()
        {
            Text = "0",
            Position = new Vector2(100, 0),
            Modulate = new Color(1, 1, 1, 1),
            Visible = false
        };
        PointsLabel.Set("theme_override_font_sizes/font_size", 100);
        PointsLabel.AddToGroup("PointsLabel");
        AddChild(PointsLabel);
    }


    public void updatePoints()
    {
        PointsLabel.Text = PlayerHandler.prevStackingPoint.ToString();
        prevPoints = PlayerHandler.prevStackingPoint;
    }


    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        blockMovement += delta;
        // if points get updated update the label
        if (PlayerHandler.prevStackingPoint != prevPoints) updatePoints();
        PointsLabel.Position = new Vector2(100, camera.cameraYcord - 500);

        if (!running && !block.failed)
        {
            BlockSpawnTimer += delta;
            if (BlockSpawnTimer >= 1)
            {
                AntiSpam = false;
                BlockSpawnTimer = 0;
                block = new StackingBlock(blockCounter);
                camera.i = blockCounter;
                camera.id = blockCounter;
                AddChild(block);
                running = !running;
            }
        }
    }
    public bool AntiSpam = false;
    public override void _Input(InputEvent @event)
    {
        //mousebutton left 
        if (@event is InputEventMouseButton mouseButton && mouseButton.Pressed)
        {
            SetPrecisionDifficulty();
            running = false;
            if (block.id <= 9 || Level == PlayerHandler.StackingDificulty.Endless)
            {
                if (AntiSpam == false)
                {
                    if (block.Position.X >= 744 + PrecisionDifficulty && block.Position.X <= 984 - PrecisionDifficulty)
                    {
                        AntiSpam = true;
                        block.stoppos = 864;
                        PlayerHandler.prevStackingPoint++;
                        blockCounter++;
                    }
                    else
                    {
                        block.stoppos = block.Position.X;
                        block.failed = true;
                    }
                }
                block.running = false;
            }
        }
    }
    private void SetPrecisionDifficulty()
    {
        if (Level == PlayerHandler.StackingDificulty.easy)
        {
            PrecisionDifficulty = 10;
            PointsLabel.Visible = false;
        }
        else if (Level == PlayerHandler.StackingDificulty.medium)
        {
            PrecisionDifficulty = 40;
            PointsLabel.Visible = false;
        }
        else if (Level == PlayerHandler.StackingDificulty.hard)
        {
            PrecisionDifficulty = 80;
            PointsLabel.Visible = false;
        }
        else if (Level == PlayerHandler.StackingDificulty.impossible)
        {
            PrecisionDifficulty = 115;
            PointsLabel.Visible = false;
        }
        else if (Level == PlayerHandler.StackingDificulty.Endless)
        {
            PrecisionDifficulty += 4;
            PointsLabel.Visible = true;
        }
    }

    partial class Camera : Camera2D
    {
        public int i { get; set; } = 0;
        public int id { get; set; } = 0;
        public int cameraYcord = 540;
        private double ZoomoutTimer = 0;
        public PlayerHandler.StackingDificulty Level;
        public override void _Process(double delta)
        {
            Level = PlayerHandler.stackingSetDificulty;
            //moves camera
            if (i <= 3)
            {
                Position = new Vector2(960, cameraYcord);
            }
            else if (id <= 9 || Level == PlayerHandler.StackingDificulty.Endless)
            {
                cameraYcord -= 192;
                Position = Position.Lerp(new Vector2(960, cameraYcord), 0.1f);
                i = 0;
            }
            if (id == 10 && Level != PlayerHandler.StackingDificulty.Endless)
            {
                ZoomoutTimer += delta;
                if (ZoomoutTimer < 2)
                {
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

        public PlayerHandler.StackingDificulty Level;
        public override void _Ready()
        {
            Random generator = new Random();
            Level = PlayerHandler.stackingSetDificulty;
            SetSpeedDifficulty();
            SetTexture();
            int StartCordBlockX = generator.Next(0, 1500);
            if (id > 3)
            {
                Position = new Vector2(StartCordBlockX, 8 - ((id - 4) * 192));
            }
            else
            {
                Position = new Vector2(StartCordBlockX, yCordinateStartValue);
            }
            Size = new Vector2(192, 192);
        }
        private void SetSpeedDifficulty()
        {
            Random generator = new Random();
            if (Level == PlayerHandler.StackingDificulty.easy)
            {
                speedDifficulty = generator.Next(10, 21);
            }
            if (Level == PlayerHandler.StackingDificulty.medium)
            {
                speedDifficulty = generator.Next(20, 31);
            }
            if (Level == PlayerHandler.StackingDificulty.hard)
            {
                speedDifficulty = generator.Next(31, 41);
            }
            if (Level == PlayerHandler.StackingDificulty.impossible)
            {
                speedDifficulty = generator.Next(5, 10);
            }
            if (Level == PlayerHandler.StackingDificulty.Endless)
            {
                speedDifficulty += 2;
            }
        }

        private void SetTexture()
        {
            //loading difrent textures
            int number = 0;
            Random generator = new Random();
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
            else if (id == 7 && Level != PlayerHandler.StackingDificulty.Endless)
            {
                Texture = GD.Load<Texture2D>("res://assets/Industrial/wind-turbine-base8.png");
            }
            else if (id == 8 && Level != PlayerHandler.StackingDificulty.Endless)
            {
                Texture = GD.Load<Texture2D>("res://assets/Industrial/wind-turbine-base9.png");
            }
            else if (id == 9 && Level != PlayerHandler.StackingDificulty.Endless)
            {
                Texture = GD.Load<Texture2D>("res://assets/Industrial/wind-turbine-top.png");
            }
            else if (id >= 7 && Level == PlayerHandler.StackingDificulty.Endless)
            {
                number = generator.Next(0, 2);
                if (number == 0)
                {
                    Texture = GD.Load<Texture2D>("res://assets/Industrial/wind-turbine-base8.png");
                }
                else if (number == 1)
                {
                    Texture = GD.Load<Texture2D>("res://assets/Industrial/wind-turbine-base-7.png");
                }
            }

        }
        public override void _Process(double delta)
        {
            if (failedTimer >= 2.5 && Level != PlayerHandler.StackingDificulty.Endless)
            {
                GetTree().ChangeSceneToFile("res://minigames/Stacking/gameoverscreen.tscn");
            }
            else if (failedTimer >= 2.5 && Level == PlayerHandler.StackingDificulty.Endless)
            {
                GetTree().ChangeSceneToFile("res://minigames/Stacking/FailedScreenEndlessMode.tscn");
            }
            if (failed)
            {
                failedTimer += delta;
            }
            if (id == 10 && failed == false && Level != PlayerHandler.StackingDificulty.Endless)
            {
                succedTimer += delta;
            }
            if (succedTimer > 2)
            {
                GetNode("../FinishWiek").Set("visible", true);
            }
            if (succedTimer >= 4)
            {
                GetTree().ChangeSceneToFile("res://minigames/Stacking/completedscreen.tscn");
            }
            MoveBlockLeftRight(delta);
        }
        private void MoveBlockLeftRight(double delta)
        {
            if (movingRight && running)
            {
                if (Position.X < 1520)
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
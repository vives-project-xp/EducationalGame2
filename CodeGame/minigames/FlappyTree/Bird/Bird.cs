using Godot;

public partial class Bird : CharacterBody2D
{
	public const float Speed = 300.0f;
	public const float JumpVelocity = -400.0f;

	public const float maxFallSpeed = 1000.0f;

	// Get the gravity from the project settings to be synced with RigidBody nodes.
	public float gravity = ProjectSettings.GetSetting("physics/2d/default_gravity").AsSingle();

	public bool is_jumping = false;
	public float maxTopTilt = -30.0f;
	public float maxBottomTilt = 30.0f;


	public override void _PhysicsProcess(double delta)
	{
		// let the bird fall on default gravity
		Vector2 _Velocity = Velocity;
		_Velocity.Y += gravity * (float)delta;
		_Velocity.Y = Mathf.Min(_Velocity.Y, maxFallSpeed);
		if (_Velocity.Y > maxFallSpeed) _Velocity.Y = maxFallSpeed;

		if (!is_jumping)
		{
			Rotate(Mathf.DegToRad(1.5f));
			if (Rotation > Mathf.DegToRad(maxBottomTilt)) Rotation = Mathf.DegToRad(maxBottomTilt);
		}
		else
		{
			Rotate(Mathf.DegToRad(-4f));
			if (Rotation < Mathf.DegToRad(maxTopTilt))
			{
				Rotation = Mathf.DegToRad(maxTopTilt);
				is_jumping = false;
			}
		}


		if (Input.IsActionJustPressed("ui_click"))
		{
			_Velocity.Y = JumpVelocity;
			//TODO: make the rotation a smooth transition
			is_jumping = true;
		}

		Velocity = _Velocity;
		MoveAndSlide();
	}
}

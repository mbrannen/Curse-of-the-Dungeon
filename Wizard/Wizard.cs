using Godot;
using System;

public partial class Wizard : CharacterBody2D
{
	[Export] private float Gravity { get; set; }
	[Export] private float Speed { get; set; }
	[Export] private float Acceleration { get; set; }
	[Export] private float Friction { get; set; }
	[Export] private float FallSpeed { get; set; }
	[Export] private float JumpStrength { get; set; }

	[Export] PackedScene Projectile { get; set; }

	Marker2D SpellOrigin;

	public override void _Ready()
	{
		//Assign nodes to variables.
		SpellOrigin = GetNode<Marker2D>("Marker2D");
	}

	//Non-Physics related calls should go here. Called every frame.
	public override void _Process(double delta)
	{
		//Call Animation Handler
		GetNode<Node2D>("Marker2D").Rotation = GetLocalMousePosition().Angle();

		//Call Gravity Handler
		GravityHandler(delta);

		//Call Velocity Handler
		VeloctiyHandler(delta);
		
		//Call Jump Handler
		JumpHandler();

		CameraHandler();

		if (Input.IsActionJustPressed("Cast"))
		{
			CastSpell();
		}

	}

	private void CameraHandler()
	{
		var camera = GetViewport().GetCamera2D();
		camera.Position = new Vector2(Position.X, Position.Y-125);
	}

	//Physics related calls should go here. Called every frame at 60 frames per second.
	public override void _PhysicsProcess(double delta)
	{
		//Call Move and Slide.
		MoveAndSlide();
	}

	//Function to handle gravity and apply downwards force when not on the floor.
	void GravityHandler(double delta)
	{
		//Return out of the function if already on the floor.
		if (IsOnFloor()) return;

		//Set velocity to the current X velocity, and move Y velocity towards fallspeed (terminal velocity)
		Velocity = new Vector2(
			Velocity.X,
			Mathf.MoveToward(Velocity.Y, FallSpeed, Gravity * (float)delta)
		).Floor();
	}

	float InputHandler()
	{
		if ((Input.IsActionPressed("MoveLeft") && Input.IsActionPressed("MoveRight")) || (!Input.IsActionPressed("MoveLeft") && !Input.IsActionPressed("MoveRight")))
		{
			return 0;
		} else if (Input.IsActionPressed("MoveLeft"))
		{
			return -1;
		} else if (Input.IsActionPressed("MoveRight"))
		{
			return 1;
		} else {
			return 0;
		}
		
	}

	void VeloctiyHandler(double delta)
	{
		float inputDirection = InputHandler();

		if (inputDirection != 0)
		{
			Velocity = new Vector2(
				Mathf.MoveToward(Velocity.X, inputDirection * Speed, Acceleration * (float)delta),
				Velocity.Y
			).Floor();
		} else {
			Velocity = new Vector2(
				Mathf.MoveToward(Velocity.X, 0, Friction * (float)delta),
				Velocity.Y
			).Floor();
		}
	}

	void JumpHandler()
	{
		var velocity = Velocity;

		if (Input.IsActionJustPressed("Jump") && IsOnFloor())
		{
			velocity.Y = JumpStrength;
		} else if (Input.IsActionJustReleased("Jump") && Velocity.Y < JumpStrength / 2)
		{
			velocity.Y = JumpStrength / 2;
		}

		Velocity = velocity;
	}

	void CastSpell()
	{
		var Fireball = Projectile.Instantiate() as Node2D;
		Fireball.Rotation = SpellOrigin.Rotation;
		Fireball.GlobalPosition = SpellOrigin.GlobalPosition;
		GetTree().CurrentScene.AddChild(Fireball);
	}

	void AnimationHandler()
	{
		
	}

}

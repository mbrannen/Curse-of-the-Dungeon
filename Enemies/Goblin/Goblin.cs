using GameJam2024.GameManagement;
using Godot;
using System;

public partial class Goblin : CharacterBody2D
{
	[Export] private float Gravity { get; set; }
	[Export] private float Speed { get; set; }
	[Export] private float Acceleration { get; set; }
	[Export] private float Friction { get; set; }
	[Export] private float FallSpeed { get; set; }
	[Export] private float JumpStrength { get; set; }

	[Export] AnimatedSprite2D GhostFormSpriteAnimated;
	[Export] AnimatedSprite2D UndeadFormSpriteAnimated;
	[Export] Area2D GoblinDetectionBox;
	[Export] Area2D GoblinHurtBox;
	[Export] PackedScene Axe;
	[Export] Node2D P1;
	[Export] public Timer ThrowTimer;
	[Export] public float LaunchPower { get; set; } = 30000f;

	private bool IsThrowing;
	private double time = 0;
	private Axe _axe;
	private bool facingRight = true;
	private Vector2 _aimDirection;
	private CharacterBody2D player;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		GhostFormSpriteAnimated.Play();
		UndeadFormSpriteAnimated.AnimationFinished += UndeadFormSpriteAnimatedAnimationFinished;
		IsThrowing = false;
	}

	private void UndeadFormSpriteAnimatedAnimationFinished()
	{
		IsThrowing = false;
        if((GoblinHurtBox as GoblinHurtBox).IsKilled)
        {
            QueueFree();
        }
    }

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		//_aimDirection = GlobalPosition.DirectionTo();
			//(P1.GlobalPosition - GlobalPosition).Angle();

		GravityHandler(delta);
		if ((GoblinDetectionBox as GoblinDetectionBox).DetectedPlayer && UndeadFormSpriteAnimated.Visible)
		{
			CalculateRange();
		}
		if ((GoblinHurtBox as GoblinHurtBox).IsKilled) {
			UndeadFormSpriteAnimated.Play("second_death");
		}
	}

	//Physics related calls should go here. Called every frame at 60 frames per second.
	public override void _PhysicsProcess(double delta)
	{
		//Call Move and Slide.
		MoveAndSlide();
		//var player = GetNode<CharacterBody2D>("../Wizard");
		//_axe.GlobalPosition = BezierCurve((float) time, player as Wizard);
		//time += delta;
		//if(time >= 1)
		//{
		//    time = 0;
		//}
	}

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

	void CalculateRange()
	{
		//GD.Print("Searching");
		var Player = GetNode<CharacterBody2D>("../Wizard");
		//GD.Print(GlobalPosition.DistanceTo((Player as Wizard).GlobalPosition));
		if (GlobalPosition.DistanceTo((Player as Wizard).GlobalPosition) <= 250)
		{
			if (!IsThrowing)
			{
				GD.Print("Throw Axe");
				ThrowAxe((Player as Wizard));
				IsThrowing = true;
			}
		}

		if (GlobalPosition.DistanceTo((Player as Wizard).GlobalPosition) > 250 & GlobalPosition.DistanceTo((Player as Wizard).GlobalPosition) <= 350)
		{

			UndeadFormSpriteAnimated.Play("walk");

			if (GlobalPosition.X > (Player as Wizard).GlobalPosition.X) //Goblin moves left
			{
				//GD.Print("Moving Left");
				UndeadFormSpriteAnimated.FlipH = true;
			}
			else //Goblin moves right
			{
				//GD.Print("Moving right");
				UndeadFormSpriteAnimated.FlipH = false;
			}
			Position += ((Player as Wizard).Position - Position) / Speed;
		}
	}
	void ThrowAxe(Wizard player)
	{
		GD.Print($"Throwing Axe: {ThrowTimer.TimeLeft}");
		_axe = Axe.Instantiate() as Axe;
		//axe.GlobalPosition = BezierCurve((float) time, player);
		_axe.GlobalPosition = new Vector2(GlobalPosition.X, GlobalPosition.Y-50);
		UndeadFormSpriteAnimated.Play("throw");
		_aimDirection = GlobalPosition.DirectionTo(player.GlobalPosition);
		Vector2 launchVector = _aimDirection * LaunchPower;
		_axe.ApplyForce(launchVector);

		GetTree().CurrentScene.AddChild(_axe);
	}

}

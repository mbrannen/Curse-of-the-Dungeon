using Godot;
using System;
using GameJam2024.GameManagement;
using GameJam2024.RuneTree;

public partial class Wizard : CharacterBody2D
{
	[Export] private float Gravity { get; set; }
	[Export] private float Speed { get; set; }
	[Export] private float Acceleration { get; set; }
	[Export] private float Friction { get; set; }
	[Export] private float FallSpeed { get; set; }
	[Export] private float JumpStrength { get; set; }

	[Export] public AnimatedSprite2D Animation;

	[Export] Marker2D SpellOrigin;
	private SpellManager SpellManager;

	public override void _Ready()
	{
		SpellManager = SpellOrigin as SpellManager;
		GameManager.Instance.GameOverNotify += OnGameOverNotify;
	}

	public override void _ExitTree()
	{
		GameManager.Instance.GameOverNotify -= OnGameOverNotify;
	}

	private void OnGameOverNotify()
	{
		Animation.Play("death");
	}

	//Non-Physics related calls should go here. Called every frame.
	public override void _Process(double delta)
	{
		SpellOrigin.Rotation = (GetLocalMousePosition()-SpellOrigin.Position).Angle();
		
		GravityHandler(delta);

		VeloctiyHandler(delta);
		if(!GameManager.Instance.IsInPauseState())
			JumpHandler();
		AnimationHandler();
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
		//ovveride to a 0 x velocity if player died
		if (GameManager.Instance.GetState() == GameState.GameOver)
			Velocity = new Vector2(
				0,
				Velocity.Y
			);
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
		if (!GameManager.Instance.IsTalentsOpen
			&& GameManager.Instance.GetSelectedSpell() is not null
			&& GameManager.Instance.GetSelectedSpell()?.RuneType != Rune.Base
			&& SpellManager.CanCast())
		{
			var mouseCoords = GetGlobalMousePosition();
			var spell = SpellManager.GetSpell().Instantiate() as Spell;
			spell.Rune = GameManager.Instance.GetSelectedSpell();
			if(spell.Rune.MovesWhenCast)
				spell.Rotation = SpellOrigin.Rotation;
			if (spell.Rune.IsPlaceable)
				spell.GlobalPosition = mouseCoords;
			else
				spell.GlobalPosition = SpellOrigin.GlobalPosition;
			
			ChangeSpellAudioState(spell.Rune.RuneType);
			GetTree().CurrentScene.AddChild(spell);
			
			GameManager.Instance.ChangeCorruptionValue(spell.Rune.MagicClass, spell.Rune.CorruptionCost);
		}

	}

	void ChangeSpellAudioState(Rune rune)
	{
		switch(rune) {
				case Rune.Fireball:
				case Rune.Fireblast:
				case Rune.Firewall:
					GetNode("Wwise/FireSpellState").Call("set_state");
					break;
				case Rune.LightningRune:
					GetNode("Wwise/LightningSpellState").Call("set_state");
					break;
				case Rune.IceBlock:
				case Rune.IcePatch:
				case Rune.IceBridge:
				case Rune.IceShard:
				case Rune.IceRune:
					GetNode("Wwise/IceSpellState").Call("set_state");
					break;
			}
	}

	void AnimationHandler()
	{
		if (GameManager.Instance.GetState() != GameState.GameOver)
		{
			if (Velocity.X > 0)
			{
				Animation.FlipH = true;
				Animation.Play("walk");
			}

			if (Velocity.X < 0)
			{
				Animation.FlipH = false;
				Animation.Play("walk");
			}
			if (Velocity.X == 0)
			{
				Animation.Play("idle");
			}
		}

			
	}

}

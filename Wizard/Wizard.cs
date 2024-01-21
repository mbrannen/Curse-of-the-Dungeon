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

    public override void _Ready()
    {
        //Assign nodes to variables.
        base._Ready();
    }

    public override void _Process(double delta)
    {
        //Handle animations

        base._Process(delta);
    }

    public override void _PhysicsProcess(double delta)
    {
        GravityHandler();

        VeloctiyHandler();
        
        JumpHandler();

        MoveAndSlide();

        base._PhysicsProcess(delta);
    }

    void GravityHandler()
    {
        //Return out of the function if already on the floor.
        if (IsOnFloor()) return;

        //Set velocity to the current X velocity, and move Y velocity towards fallspeed
        Velocity = new Vector2(
            Velocity.X,
            Mathf.MoveToward(Velocity.Y, Gravity, FallSpeed)
        ).Floor();
    }

    float InputHandler()
    {
        float playerInput = 0;

        if ((Input.IsActionPressed("MoveLeft") && Input.IsActionPressed("MoveRight")) || (!Input.IsActionPressed("MoveLeft") && !Input.IsActionPressed("MoveRight")))
        {
            playerInput = 0;
        } else if (Input.IsActionPressed("MoveLeft"))
        {
            playerInput = -1;
        } else if (Input.IsActionPressed("MoveRight"))
        {
            playerInput = 1;
        }
        return playerInput;
    }

    void VeloctiyHandler()
    {
        float inputDirection = InputHandler();

        if (inputDirection != 0)
        {
            Velocity = new Vector2(
                Mathf.MoveToward(Velocity.X, inputDirection * Speed, Acceleration),
                Velocity.Y
            );
        } else {
            Velocity = new Vector2(
                Mathf.MoveToward(Velocity.X, 0, Friction),
                Velocity.Y
            );
        }
    }

    void JumpHandler()
    {
        if (Input.IsActionJustPressed("Jump") && IsOnFloor())
        {
            Velocity = new Vector2(
                Velocity.X,
                Velocity.Y + JumpStrength
            );
        }
    }

    void AnimationHandler()
    {
        
    }

}

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


    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
        GravityHandler(delta);
    }

    //Physics related calls should go here. Called every frame at 60 frames per second.
    public override void _PhysicsProcess(double delta)
    {
        //Call Move and Slide.
        MoveAndSlide();
    }

    void GravityHandler(double delta)
    {
        //GD.Print(IsOnFloor());
        //Return out of the function if already on the floor.
        if (IsOnFloor()) return;

        //Set velocity to the current X velocity, and move Y velocity towards fallspeed (terminal velocity)
        Velocity = new Vector2(
            Velocity.X,
            Mathf.MoveToward(Velocity.Y, FallSpeed, Gravity * (float)delta)
        ).Floor();
        //GD.Print(Velocity);
    }
}

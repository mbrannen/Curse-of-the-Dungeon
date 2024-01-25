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
    [Export] PackedScene Axe;




    // Called when the node enters the scene tree for the first time.
    public override void _Ready()
    {
        GhostFormSpriteAnimated.Play();

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        GravityHandler(delta);
        if ((GoblinDetectionBox as GoblinDetectionBox).DetectedPlayer && UndeadFormSpriteAnimated.Visible)
        {
            CalculateRange(delta);
        }
    }

    //Physics related calls should go here. Called every frame at 60 frames per second.
    public override void _PhysicsProcess(double delta)
    {
        //Call Move and Slide.
        MoveAndSlide();
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

    void CalculateRange(double delta) {
        GD.Print("Searching");
        var Player = GetNode<CharacterBody2D>("../Wizard");
        if (GlobalPosition.DistanceTo((Player as Wizard).Position) <= 250){
            GD.Print("Throw Axe");
            var axe = Axe.Instantiate() as Axe;
            axe.GlobalPosition = GlobalPosition;
            GetTree().CurrentScene.AddChild(axe);
        }
        else{
            GD.Print("move closer");
            GD.Print($"Goblin X position: { GlobalPosition.X}");
            if (GlobalPosition.X > (Player as Wizard).Position.X)
            {
                Velocity = new Vector2(Mathf.MoveToward(Velocity.X, -1 * Speed, Acceleration * (float)delta),Velocity.Y).Floor();
            }
            else
            {
                Velocity = new Vector2(Mathf.MoveToward(Velocity.X, 1 * Speed, Acceleration * (float)delta), Velocity.Y).Floor();
            }
        }
    }
}

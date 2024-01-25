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
    [Export] Node2D P1;
    [Export] public Timer ThrowTimer;

    private bool IsThrowing;
    private double time = 0;
    private Axe _axe;
    private bool facingRight = true;
    

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
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
    {
        GravityHandler(delta);
        if ((GoblinDetectionBox as GoblinDetectionBox).DetectedPlayer && UndeadFormSpriteAnimated.Visible)
        {
            CalculateRange();
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
        GD.Print("Searching");
        var Player = GetNode<CharacterBody2D>("../Wizard");
        GD.Print(GlobalPosition.DistanceTo((Player as Wizard).GlobalPosition));
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
            GD.Print("move closer");
            UndeadFormSpriteAnimated.Play("walk");
            ////GD.Print($"Goblin X position: {GlobalPosition.X}");
            //GD.Print($"Player X position: {(Player as Wizard).Position.X}");
            //GD.Print($"GlobalPosition X position: {(Player as Wizard).Position.X}");
            if (GlobalPosition.X > (Player as Wizard).GlobalPosition.X) //Goblin moves left
            {
                GD.Print("Moving Left");
                UndeadFormSpriteAnimated.FlipH = true;
            }
            else //Goblin moves right
            {
                GD.Print("Moving right");
                UndeadFormSpriteAnimated.FlipH = false;
            }
            Position += ((Player as Wizard).Position - Position) / Speed;

            //Velocity = new Vector2(Mathf.MoveToward(Velocity.X, Speed, (float)delta), Velocity.Y).Floor();
        }
    }
    void ThrowAxe(Wizard player)
    {
        GD.Print($"Throwing Axe: {ThrowTimer.TimeLeft}");
        _axe = Axe.Instantiate() as Axe;
        //axe.GlobalPosition = BezierCurve((float) time, player);
        _axe.GlobalPosition = GlobalPosition;
        UndeadFormSpriteAnimated.Play("throw");
        GetTree().CurrentScene.AddChild(_axe);
    }
    //Vector2 BezierCurve(float time, Wizard player)
    //{
    //    GD.Print($"Bezier Curve: {time}");
    //    var q0 = GlobalPosition.Lerp(P1.GlobalPosition,  time);
    //    var q1 = P1.GlobalPosition.Lerp(player.GlobalPosition,  time);
    //    var r = q0.Lerp(q1, time);
    //    return r;
    //}
    //public bool CanThrow()
    //{
    //    GD.Print($"ThrowTimer.TimeLeft: {ThrowTimer.TimeLeft}");
    //    if (ThrowTimer.TimeLeft == 0)
    //    {
    //        ThrowTimer.Start();
    //        return true;
    //    }

    //    return false;
    //}
}
using Godot;
using System;

public partial class GoblinDetectionBox : Area2D
{
    // Called when the node enters the scene tree for the first time.

    [Export] AnimatedSprite2D GhostFormSpriteAnimated;
    [Export] AnimatedSprite2D UndeadFormSpriteAnimated;

    bool IsRessurrected;
    public bool DetectedPlayer { get; set; }

    public override void _Ready()
	{
		AreaEntered += PlayerDetectedOnAreaEntered;
        AreaExited += PlayerDetectedOnAreaExit;
        IsRessurrected = false;
        GhostFormSpriteAnimated.AnimationFinished += GhostFormSpriteAnimatedFinished;
        DetectedPlayer = false;
    }

    private void GhostFormSpriteAnimatedFinished()
    {
        GhostFormSpriteAnimated.Stop();
        GhostFormSpriteAnimated.Visible = false;
        UndeadFormSpriteAnimated.Visible=true;
        UndeadFormSpriteAnimated.Play("idle");
    }

    private void PlayerDetectedOnAreaEntered(Area2D area)
    {
        GD.Print($"Player Detected:{area.Name}");
        if (!IsRessurrected)
        {
            GhostFormSpriteAnimated.Play("possession");
            IsRessurrected = true;
        }
        DetectedPlayer = true;

    }
    private void PlayerDetectedOnAreaExit(Area2D area)
    {
        GD.Print($"Player Exit Detection:{area.Name}");
        if (UndeadFormSpriteAnimated.Visible)
        {
            DetectedPlayer = false;
            UndeadFormSpriteAnimated.Play("idle");

            GD.Print($"Player Detection: {DetectedPlayer}");
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
    }
}

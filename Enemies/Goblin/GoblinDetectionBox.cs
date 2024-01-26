using Godot;
using System;
using GameJam2024.GameManagement;

public partial class GoblinDetectionBox : Area2D
{
	// Called when the node enters the scene tree for the first time.

	[Export] AnimatedSprite2D GhostFormSpriteAnimated;
	[Export] AnimatedSprite2D UndeadFormSpriteAnimated;
	[Export] private Sprite2D FormerBody;

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
			GetNode("../GhostScreamEvent").Call("post_event");
			GetNode("../GhostAmbienceEvent").Call("post_event");
			GhostFormSpriteAnimated.Play("possession");
			IsRessurrected = true;
		}
		DetectedPlayer = true;
		GameManager.Instance.IncreaseGoblinsEngaged();
		if (area.IsInGroup("goblin_wall")) {
			GD.Print($"Detected Wall:{area.Name}");

		}
	}
	private void PlayerDetectedOnAreaExit(Area2D area)
	{
		GD.Print($"Player Exit Detection:{area.Name}");
		if (UndeadFormSpriteAnimated.Visible)
		{ 
			DetectedPlayer = false;
			UndeadFormSpriteAnimated.Play("idle");
			GameManager.Instance.DecreaseGoblinsEngaged();
			GD.Print($"Player Detection: {DetectedPlayer}");
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if(GhostFormSpriteAnimated.Frame == 4)
			FormerBody.Visible = false;
	}
}

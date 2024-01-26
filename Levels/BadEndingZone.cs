using Godot;
using System;
using GameJam2024.GameManagement;
using GameJam2024.RuneTree;

public partial class BadEndingZone : Area2D
{
	private AnimationPlayer Animation;
	public override void _Ready()
	{
		BodyEntered += OnBodyEntered;
		Animation = GetNode<AnimationPlayer>("AnimationPlayer");
		Animation.AnimationFinished += OnAnimationFinished;
	}
	
	private void OnAnimationFinished(StringName animname)
	{
		GameManager.Instance.SetState(GameState.MainMenu);
	}

	private void OnBodyEntered(Node2D body)
	{
		if (body.IsInGroup("player"))
		{
			var iceBridgeCorrupted = TalentManager.Instance.GetSpell(Rune.IceBridge).Corrupted;
			if (iceBridgeCorrupted) {
				GetNode("BadEndingState").Call("set_state");
				GameManager.Instance.SetState(GameState.BadEnding);
			}
		}
		
	}
}

using Godot;
using System;
using GameJam2024.GameManagement;

public partial class BadEndingCutscene : Panel
{
    private AnimationPlayer Animation;
    public override void _Ready()
    {

        Animation = GetNode<AnimationPlayer>("AnimationPlayer");
        Animation.AnimationFinished += OnAnimationFinished;
    }
    private void OnAnimationFinished(StringName animname)
    {
        GameManager.Instance.SetState(GameState.Credits);
    }
}

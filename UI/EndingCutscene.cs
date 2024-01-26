using Godot;
using System;
using GameJam2024.GameManagement;

public partial class EndingCutscene : Panel
{
    [Export] public AnimationPlayer Animation;

    public override void _Ready()
    {
        Animation.AnimationFinished += OnAnimationFinished;
        GetNode("CutsceneScene").Call("post_event");
    }

    private void OnAnimationFinished(StringName animname)
    {
        GameManager.Instance.SetState(GameState.Credits);
    }
}

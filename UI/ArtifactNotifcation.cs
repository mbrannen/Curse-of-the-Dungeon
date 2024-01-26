using Godot;
using System;
using GameJam2024.RuneTree;

public partial class ArtifactNotifcation : Sprite2D
{
    [Export] public AnimationPlayer Animation;
    public override void _ExitTree()
    {
        TalentManager.Instance.NotifyHUDOfCorruption -= OnNotifyHUDOfCorruption;
    }

    public override void _Ready()
    {
        TalentManager.Instance.NotifyHUDOfCorruption += OnNotifyHUDOfCorruption;
        Animation.AnimationFinished += OnAnimationFinished;
    }

    private void OnAnimationFinished(StringName animname)
    {
        if(animname == "CorruptionEvent")
            Animation.Play("idle");
    }

    private void OnNotifyHUDOfCorruption(string name, bool firesound)
    {
        Animation.Play("CorruptionEvent");
    }
}

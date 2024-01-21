using Godot;
using System;
using GameJam2024.GameManagement;

public partial class IntroCutscene : Control
{
    [Export] public AnimationPlayer AnimationPlayer;

    public override void _Ready()
    {
        GameManager.Instance.PlayIntroCutscene += OnPlayIntroCutscene;
    }

    private void OnPlayIntroCutscene()
    {
        AnimationPlayer.Play("Play");
    }
}

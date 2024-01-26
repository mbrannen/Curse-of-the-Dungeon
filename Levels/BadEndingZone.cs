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
    }

    private void OnBodyEntered(Node2D body)
    {
        if (body.IsInGroup("player"))
        {
            var iceBridgeCorrupted = TalentManager.Instance.GetSpell(Rune.IceBridge).Corrupted;
            var iceBlockCorrupted = TalentManager.Instance.GetSpell(Rune.IceBlock).Corrupted;
            if(iceBridgeCorrupted && iceBlockCorrupted)
                GameManager.Instance.SetState(GameState.BadEnding);
        }
        
    }
}

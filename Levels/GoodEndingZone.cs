using Godot;
using System;
using GameJam2024.GameManagement;
using GameJam2024.RuneTree;

public partial class GoodEndingZone : Area2D
{
    
    public override void _Ready()
    {
        BodyEntered += OnBodyEntered;
    }



    private void OnBodyEntered(Node2D body)
    {
        if (body.IsInGroup("player"))
        {
                GameManager.Instance.SetState(GameState.GoodEnding);
        }
        
    }
}

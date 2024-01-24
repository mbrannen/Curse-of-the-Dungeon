using Godot;
using System;
using GameJam2024.GameManagement;

public partial class DeathZone : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        BodyEntered += WaterZoneBodyEntered;
    }
    private void WaterZoneBodyEntered(Node2D body)
    {
        if (body.IsInGroup("player"))
        {
	        //TODO:Maybe some animation or something also?
            GameManager.Instance.SetState(GameState.GameOver);
        };
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}

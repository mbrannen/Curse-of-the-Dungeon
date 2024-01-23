using Godot;
using System;

public partial class DeathZone : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        BodyEntered += WaterZoneBodyEntered;
    }
    private void WaterZoneBodyEntered(Node2D body)
    {
        GD.Print($"something collided:{body.Name}");
        if (body.IsInGroup("player"))
        {
            //todo: send event to game manager that player died
            GD.Print("Player Died");
        };
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}

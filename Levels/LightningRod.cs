using Godot;
using System;

public partial class LightningRod : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        BodyEntered += LightningRodBodyEntered;
	}

    private void LightningRodBodyEntered(Node2D body)
    {
        GD.Print($"Spell collided:{body.Name}");
        if (body.IsInGroup("lightning")){
            GD.Print("Lightning");
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}

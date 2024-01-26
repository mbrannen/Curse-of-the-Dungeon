using Godot;
using System;

public partial class AxeArea2D : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
        AreaEntered += AxeAreaEntered;
	}

    private void AxeAreaEntered(Area2D area)
    {
        GD.Print($"Axe Colliding: {area.Name}");
        if (area.IsInGroup("player"))
        {
            GD.Print("Axe Hit Player!");
        }
    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}

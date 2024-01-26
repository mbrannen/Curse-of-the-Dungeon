using Godot;
using System;

public partial class Axe : RigidBody2D
{
	// Called when the node enters the scene tree for the first time.
	[Export] Timer Timer;
	public override void _Ready()
	{
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		clearAxe();
	}
	private void clearAxe()
	{
		if (Timer.TimeLeft == 0)
		{
			GD.Print("Delete Axe");
			QueueFree();
		}
	}
}

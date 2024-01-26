using Godot;
using System;

public partial class LightningRod : Area2D
{
	[Export] public Node2D EnergizedParticles;
	// Called when the node enters the scene tree for the first time.
	public bool IsTriggered { get; set; }

	public override void _Ready()
	{
		AreaEntered += LightningRodAreaEntered;
		IsTriggered = false;

	}

	private void LightningRodAreaEntered(Area2D area)
	{
		GD.Print($"Spell collided:{area.Name}");
		if (area.IsInGroup("lightning") && !IsTriggered)
		{
			EnergizedParticles.Visible = true;
			IsTriggered = true;
			GD.Print("Lightning Rod activated");
			GetNode("RodChargeEvent").Call("post_event");
		}
	}
}

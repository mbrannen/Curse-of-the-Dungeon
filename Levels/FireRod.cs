using Godot;
using System;
using System.Xml.Linq;

public partial class FireRod : Area2D
{
	public bool IsTriggered { get; set; }

	[Export]
	public Node2D EnergizedParticles;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AreaEntered += FireRodAreaEntered;
		IsTriggered = false;
	}

	private void FireRodAreaEntered(Area2D area)
	{
		GD.Print($"Spell collided:{area.Name}");
		if (area.IsInGroup("fire") && !IsTriggered)
		{
			GD.Print("Fire Rod activated");
			EnergizedParticles.Visible = true;
			IsTriggered = true;
			GetNode("RodChargeEvent").Call("post_event");
		}
	}
}

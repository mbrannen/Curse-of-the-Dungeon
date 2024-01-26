using Godot;
using System;
using System.Xml.Linq;

public partial class IceRod : Area2D
{
	[Export] public Node2D EnergizedParticles;
	public bool IsTriggered { get; set; }
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AreaEntered += IceRodAreaEntered;
		IsTriggered = false;
	}

	private void IceRodAreaEntered(Area2D area)
	{
		GD.Print($"Spell collided:{area.Name}");
		if (area.IsInGroup("ice") && !IsTriggered)
		{
			GD.Print("Ice Rod activated");
			IsTriggered = true;
			EnergizedParticles.Visible = true;
			GetNode("IceRod/RodChargeEvent").Call("post_event");
			GetNode("IceRod/FreezeEvent").Call("post_event");
		}
	}
}

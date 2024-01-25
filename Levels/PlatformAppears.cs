using Godot;
using System;

public partial class PlatformAppears : StaticBody2D
{
	[Export] Area2D LightningRod;
	[Export] StaticBody2D TriggerPlatform;
	// Called when the node enters the scene tree for the first time.
	bool HaveTriggered;
	public override void _Ready()
	{
		HaveTriggered = false;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if ((LightningRod as LightningRod).IsTriggered && !HaveTriggered)
		{
			TriggerPlatform.SetCollisionLayerValue(1, true);
			var PlatformNode2D = TriggerPlatform.GetNode("Node2D") as Node2D;
			PlatformNode2D.Visible = true;
			GD.Print("Platform Extended");
			GetNode("PlatformEvent").Call("post_event");
			HaveTriggered = true;
		}
	}
}

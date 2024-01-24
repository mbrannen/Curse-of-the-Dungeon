using Godot;
using System;

public partial class LightningRod : Area2D
{
    // Called when the node enters the scene tree for the first time.
    bool isTriggered;
    [Export] StaticBody2D TriggerPlatform;
	public override void _Ready()
	{
        AreaEntered += LightningRodAreaEntered;
        isTriggered = false;

    }

    private void LightningRodAreaEntered(Area2D area)
    {
        GD.Print($"Spell collided:{area.Name}");
        if (area.IsInGroup("lightning") && !isTriggered)
        {
            TriggerPlatform.SetCollisionLayerValue(1, true);
            var PlatformNode2D = TriggerPlatform.GetNode("Node2D") as Node2D;
            PlatformNode2D.Visible = true;
            isTriggered=true;
        }
    }

    private void LightningRodAreaEntered(Node2D body)
    {

    }

    // Called every frame. 'delta' is the elapsed time since the previous frame.
    public override void _Process(double delta)
	{
	}
}

using Godot;
using System;

public partial class WizardAreaCollision : Area2D
{
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AreaEntered += WizardArea2DBodyEntered;
	}

	private void WizardArea2DBodyEntered(Area2D body)
	{
		GD.Print($"Got hit with: {body.Name}");
		if (body.IsInGroup("axe"))
		{
			GD.Print($"Axe hit");
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

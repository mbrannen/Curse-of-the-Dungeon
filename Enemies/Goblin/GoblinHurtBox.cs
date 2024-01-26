using Godot;
using System;

public partial class GoblinHurtBox : Area2D
{

    [Export] AnimatedSprite2D UndeadFormAnimatedSprite2D;
    // Called when the node enters the scene tree for the first time.

	public bool IsKilled { get; set; }
	public override void _Ready()
	{
		AreaEntered += GoblinHurtBoxAreaEntered;
		IsKilled = false;
	}

private void GoblinHurtBoxAreaEntered(Area2D area)
	{
		GD.Print($"Goblin got hit: {area.Name}");

        if (area.IsInGroup("attack_spell") && UndeadFormAnimatedSprite2D.Visible)

		{

            GD.Print("Got hit by a spell");
            IsKilled = true;

		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
	}
}

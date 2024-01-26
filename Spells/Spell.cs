using Godot;
using System;
using GameJam2024.GameManagement;
using GameJam2024.RuneTree;

public partial class Spell : Node2D
{
	[Export] public float Speed = 500;

	[Export] public Rune RuneType;
	[Export] public Area2D Collider;
	[Export] public AnimationPlayer Animation;

	public IRuneNode Rune;
	public override void _Ready()
	{
		if (Collider is not null)
		{
			Collider.BodyEntered += ColliderOnBodyEntered;
			Collider.AreaEntered += ColliderOnAreaEntered;
		}
		if(Rune.RuneType == GameJam2024.RuneTree.Rune.Fireblast)
			Animation.AnimationFinished += OnAnimationFinished;

	}

	private void OnAnimationFinished(StringName animname)
	{
		QueueFree();
	}

	private void ColliderOnAreaEntered(Area2D area)
	{
		if(!area.IsInGroup("axe") && Rune.RuneType != GameJam2024.RuneTree.Rune.Fireblast )
			QueueFree();
	}
	
	private void ColliderOnBodyEntered(Node2D body)
	{
		if(!body.IsInGroup("axe") && Rune.RuneType != GameJam2024.RuneTree.Rune.Fireblast)
			QueueFree();
	}

	public override void _Process(double delta)
	{
		var direction = new Vector2(1, 0).Rotated(Rotation);
		if (Rune.IsPlaceable)
			Speed = 0;
		GlobalPosition += Speed * direction * (float)delta;
	}
}

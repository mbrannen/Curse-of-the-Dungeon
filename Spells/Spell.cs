using Godot;
using System;
using GameJam2024.GameManagement;
using GameJam2024.RuneTree;

public partial class Spell : Node2D
{
	[Export] public float Speed = 500;

	[Export] public Rune RuneType;
	[Export] public Area2D Collider;

	public IRuneNode Rune;
	public override void _Ready()
	{
		Collider.BodyEntered += ColliderOnBodyEntered;
		Collider.AreaEntered += ColliderOnAreaEntered;
	}

	private void ColliderOnAreaEntered(Area2D area)
	{
		QueueFree();
	}
	
	private void ColliderOnBodyEntered(Node2D body)
	{
		GD.Print("Collided with body!");
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

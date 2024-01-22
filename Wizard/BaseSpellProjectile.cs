using Godot;
using System;

public partial class BaseSpellProjectile : Node2D
{
    [Export] float ProjectileSpeed { get; set; } = 300;

    Vector2 Velocity;

    Vector2 Direction;

    public override void _Ready()
    {
        Direction = new Vector2(1,0).Rotated(Rotation);
    }

    public override void _Process(double delta)
    {
        Velocity = ProjectileSpeed * Direction;
        GlobalPosition += Velocity * (float)delta;
    }
}

using Godot;
using System;
using GameJam2024.GameManagement;
using GameJam2024.RuneTree;

public partial class Spell : Node2D
{
    [Export] public float Speed = 500;

    [Export] public Rune RuneType;

    private IRuneNode Rune;
    public override void _Ready()
    {
        Rune = GameManager.Instance.GetSelectedSpell();
    }

    public override void _Process(double delta)
    {
        GlobalPosition += Speed * new Vector2(1, 0).Rotated(Rotation) * (float)delta;
    }
}

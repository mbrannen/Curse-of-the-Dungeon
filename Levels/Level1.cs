using Godot;
using System;

public partial class Level1 : Node2D
{
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Talents") || Input.IsActionJustReleased("Talents"))
        {
            Visible = !Visible;
        }
    }
}

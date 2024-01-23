using GameJam2024.GameManagement;
using GameJam2024.MainMenu;
using Godot;
using System;

public partial class Level1 : Node2D
{
    [Export] public PackedScene GameOverMenu;
    [Export] public PackedScene PauseMenu;
    public override void _EnterTree()
    {

    }
    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Talents") || Input.IsActionJustReleased("Talents"))
        {
            Visible = !Visible;
        }
    }
}

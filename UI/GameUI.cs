using Godot;
using System;
using GameJam2024.GameManagement;

public partial class GameUI : Control
{
    [Export] public Control RuneTree;
    public override void _Process(double delta)
    {
        if(Input.IsActionJustPressed("Talents") || Input.IsActionJustReleased("Talents"))
        {
        	RuneTree.Visible = !RuneTree.Visible;
        	GameManager.Instance.IsTalentsOpen = !GameManager.Instance.IsTalentsOpen;
        }

        if (GameManager.Instance.IsInPauseState())
            Visible = false;
        else
            Visible = true;
    }
}

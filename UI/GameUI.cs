using Godot;
using System;
using GameJam2024.GameManagement;
using GameJam2024.RuneTree;

public partial class GameUI : Control
{
    [Export] public Control RuneTree;
    [Export] public Timer CorruptionTimer;

    public override void _Ready()
    {
        CorruptionTimer.Timeout += CorruptionTimerOnTimeout;
    }

    private void CorruptionTimerOnTimeout()
    {
        GameManager.Instance.ChangeCorruptionValue(MagicClass.Fire, 1);
        GameManager.Instance.ChangeCorruptionValue(MagicClass.Ice, 1);
        GameManager.Instance.ChangeCorruptionValue(MagicClass.Lightning, 1);
    }

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

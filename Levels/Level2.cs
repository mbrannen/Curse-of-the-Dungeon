using Godot;
using System;

public partial class Level2 : Node2D
{
    public void Destroy()
    {
        //GameManager.Instance.LevelRestart -= OnLevelRestart;
        QueueFree();
    }
}

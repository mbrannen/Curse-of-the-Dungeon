using Godot;
using System;

public partial class Level3 : Node2D
{
    public void Destroy()
    {
        //GameManager.Instance.LevelRestart -= OnLevelRestart;
        QueueFree();
    }
}

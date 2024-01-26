using GameJam2024.GameManagement;
using Godot;

namespace GameJam2024.UI;

public partial class Credits : Control
{

    [Export] public AnimationPlayer Animation;

    public override void _Ready()
    {
        Animation.AnimationFinished += OnAnimationFinished;
    }

    private void OnAnimationFinished(StringName animname)
    {
        GameManager.Instance.SetState(GameState.MainMenu);
    }

    public override void _Process(double delta)
    {



    }
}
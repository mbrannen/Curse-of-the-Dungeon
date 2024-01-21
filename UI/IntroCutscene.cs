using GameJam2024.GameManagement;
using Godot;

namespace GameJam2024.UI;

public partial class IntroCutscene : Control
{
    [Export] public AnimationPlayer AnimationPlayer;
    [Export] public Button SkipButton;

    public override void _Ready()
    {
        GameManager.Instance.PlayIntroCutscene += OnPlayIntroCutscene;
        
        AnimationPlayer.AnimationFinished += OnAnimationFinished;
        SkipButton.Pressed += SkipButtonOnPressed;
    }

    private void SkipButtonOnPressed()
    {
        AnimationPlayer.Seek(58,true);
        SkipButton.Disabled = true;
    }

    private void OnAnimationFinished(StringName animname)
    {
        if (animname == AnimationNames.INTRO_CUTSCENE)
            //load level 1
            return;
    }

    private void OnPlayIntroCutscene()
    {
        AnimationPlayer.Play(AnimationNames.INTRO_CUTSCENE);
    }
}
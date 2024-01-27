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
		GameManager.Instance.MainMenu += OnMainMenu;
		
		AnimationPlayer.AnimationFinished += OnAnimationFinished;
		SkipButton.Pressed += SkipButtonOnPressed;
	}

	private void OnMainMenu()
	{
		SkipButton.Disabled = false;
	}

	private void SkipButtonOnPressed()
	{
		AnimationPlayer.Seek(56,true);
		SkipButton.Disabled = true;
	}

	private void OnAnimationFinished(StringName animname)
	{
		if (animname == AnimationNames.INTRO_CUTSCENE)
		{
			GameManager.Instance.SetState(GameState.Level1);
		}
	}

	private void OnPlayIntroCutscene()
	{
		AnimationPlayer.Play(AnimationNames.INTRO_CUTSCENE);
		GetNode("CutsceneScene").Call("set_state");
	}
}

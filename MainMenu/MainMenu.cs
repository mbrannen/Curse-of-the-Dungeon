using Godot;
using System;
using GameJam2024.GameManagement;
using GameJam2024.MainMenu;

public partial class MainMenu : Control
{
	[Export] public Button StartButton;
	[Export] public Button OptionsButton;
	[Export] public Button CreditsButton;
	[Export] public Panel MainMenuPanel;
	[Export] public Control CreditsScene;
	[Export] public Control OptionsScene;
	[Export] public Theme Theme;
	[Export] public Font DefaultFont;
	[Export] public Font AccessbilityFont;

	[Export] public Control IntroCutscene;
	[Export] public Control GameUI;
	[Export] public Control RuneTree;

  [Export] public PackedScene Level1;

	public override void _EnterTree()
	{
		MainMenuManager.Instance.InitState();
		MainMenuManager.Instance.FontChanged += OnFontChanged;
		MainMenuManager.Instance.CreditsBackButtonPressed += OnCreditsBackButtonPressed;
		MainMenuManager.Instance.OptionsBackButtonPressed += OnOptionsBackButtonPressed;
		
		GameManager.Instance.LevelOneStart += OnLevelOneStart;
		
		StartButton.Pressed += StartButtonOnPressed;
		StartButton.MouseEntered += ButtonOnMouseover;
		OptionsButton.Pressed += OptionsButtonOnPressed;
		OptionsButton.MouseEntered += ButtonOnMouseover;
		CreditsButton.Pressed += CreditsButtonOnPressed;
		CreditsButton.MouseEntered += ButtonOnMouseover;
		
		GetNode("Wwise/SceneMainMenu").Call("set_state");
	}

	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("Talents") || Input.IsActionJustReleased("Talents"))
		{
			RuneTree.Visible = !RuneTree.Visible;
		}
        
        if(Input.IsActionJustPressed("Spell Select Right"))
            GameManager.Instance.IncreaseSpellIndex();
        if(Input.IsActionJustPressed("Spell Select Left"))
            GameManager.Instance.DecreaseSpellIndex();
    }

	private void OnLevelOneStart()
	{
		MainMenuPanel.Visible = false;
		IntroCutscene.Visible = false;
		GameUI.Visible = true;

		var level1 = Level1.Instantiate();
		AddChild(level1);

		GetNode("Wwise/SceneLevelOne").Call("set_state");
		GetNode("Wwise/EventCaveSFX").Call("post_event");
	}

	private void OnFontChanged(long index)
	{
		switch (index)
		{
			case 0:
				Theme.DefaultFont = DefaultFont;
				break;
			case 1:
				Theme.DefaultFont = AccessbilityFont;
				break;
			default:
				Theme.DefaultFont = DefaultFont;
				break;
		}
	}

	private void OnOptionsBackButtonPressed()
	{
		GetNode("Wwise/EventButtonPress").Call("post_event");
		OptionsScene.Visible = false;
		MainMenuPanel.Visible = true;
	}

	private void OnCreditsBackButtonPressed()
	{
		GetNode("Wwise/EventButtonPress").Call("post_event");
		CreditsScene.Visible = false;
		MainMenuPanel.Visible = true;
	}

	private void CreditsButtonOnPressed()
	{
		GetNode("Wwise/EventButtonPress").Call("post_event");
		CreditsScene.Visible = true;
		MainMenuPanel.Visible = false;
	}

	private void OptionsButtonOnPressed()
	{
		GetNode("Wwise/EventButtonPress").Call("post_event");
		OptionsScene.Visible = true;
		MainMenuPanel.Visible = false;
	}

	private void StartButtonOnPressed()
	{
		GetNode("Wwise/EventButtonPress").Call("post_event");
		IntroCutscene.Visible = true;
		MainMenuPanel.Visible = false;
		GameManager.Instance.SetState(GameState.IntroCutscene);
	}

	private void ButtonOnMouseover()
	{
		GetNode("Wwise/EventButtonMouseover").Call("post_event");
	}
}

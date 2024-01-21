using Godot;
using System;
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

	public override void _EnterTree()
	{
		MainMenuManager.Instance.FontChanged += OnFontChanged;
		MainMenuManager.Instance.CreditsBackButtonPressed += OnCreditsBackButtonPressed;
		MainMenuManager.Instance.OptionsBackButtonPressed += OnOptionsBackButtonPressed;
		
		StartButton.Pressed += StartButtonOnPressed;
		OptionsButton.Pressed += OptionsButtonOnPressed;
		CreditsButton.Pressed += CreditsButtonOnPressed;
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
		OptionsScene.Visible = false;
		MainMenuPanel.Visible = true;
	}

	private void OnCreditsBackButtonPressed()
	{
		CreditsScene.Visible = false;
		MainMenuPanel.Visible = true;
	}

	private void CreditsButtonOnPressed()
	{
		CreditsScene.Visible = true;
		MainMenuPanel.Visible = false;
	}

	private void OptionsButtonOnPressed()
	{
		OptionsScene.Visible = true;
		MainMenuPanel.Visible = false;
	}

	private void StartButtonOnPressed()
	{
		//TODO: Create function to start game
		GD.Print("Start button pressed!");
		
		//TODO [SOUND]: Add Wwise button press event
		GetNode("ButtonPressedEvent").Call("post_event");
	}
}

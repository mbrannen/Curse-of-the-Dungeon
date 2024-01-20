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

    public override void _EnterTree()
    {
        MainMenuManager.Instance.CreditsBackButtonPressed += OnCreditsBackButtonPressed;
        StartButton.Pressed += StartButtonOnPressed;
        OptionsButton.Pressed += OptionsButtonOnPressed;
        CreditsButton.Pressed += CreditsButtonOnPressed;
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
        //TODO: Create function load Options scene
        GD.Print("Options button pressed!");
    }

    private void StartButtonOnPressed()
    {
        //TODO: Create function to start game
        GD.Print("Start button pressed!");
    }
}

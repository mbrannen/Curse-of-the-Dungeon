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

    [Export] public Node2D Level1;

    public override void _EnterTree()
    {
        MainMenuManager.Instance.InitState();
        MainMenuManager.Instance.FontChanged += OnFontChanged;
        MainMenuManager.Instance.CreditsBackButtonPressed += OnCreditsBackButtonPressed;
        MainMenuManager.Instance.OptionsBackButtonPressed += OnOptionsBackButtonPressed;
        
        GameManager.Instance.LevelOneStart += OnLevelOneStart;
        
        StartButton.Pressed += StartButtonOnPressed;
        OptionsButton.Pressed += OptionsButtonOnPressed;
        CreditsButton.Pressed += CreditsButtonOnPressed;
    }

    private void OnLevelOneStart()
    {
        MainMenuPanel.Visible = false;
        IntroCutscene.Visible = false;
        Level1.Visible = true;
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
        IntroCutscene.Visible = true;
        MainMenuPanel.Visible = false;
        GameManager.Instance.SetState(GameState.IntroCutscene);
    }
}

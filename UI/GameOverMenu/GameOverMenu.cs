using GameJam2024.GameManagement;
using GameJam2024.MainMenu;
using Godot;
using System;

public partial class GameOverMenu : Control
{
    [Export] public Button RestartButton;
    [Export] public Button OptionsButton;
    [Export] public Button ExitGameButton;
    [Export] public Panel GameOverPanel;
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
        MainMenuManager.Instance.OptionsBackButtonPressed += OnOptionsBackButtonPressed;

        GameManager.Instance.LevelOneStart += OnLevelOneStart;

        RestartButton.Pressed += RestartButtonOnPressed;
        OptionsButton.Pressed += OptionsButtonOnPressed;
        ExitGameButton.Pressed += ExitGameButtonOnPressed;
    }

    public override void _Process(double delta)
    {
        if (Input.IsActionJustPressed("Talents") || Input.IsActionJustReleased("Talents"))
        {
            RuneTree.Visible = !RuneTree.Visible;
        }
    }

    private void OnLevelOneStart()
    {
        GameOverPanel.Visible = false;
        IntroCutscene.Visible = false;
        GameUI.Visible = true;

        var level1 = Level1.Instantiate();
        AddChild(level1);

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
        GameOverPanel.Visible = true;
    }
    private void OptionsButtonOnPressed()
    {
        OptionsScene.Visible = true;
        GameOverPanel.Visible = false;
    }

    private void RestartButtonOnPressed()
    {
        IntroCutscene.Visible = true;
        GameOverPanel.Visible = false;
        GameManager.Instance.SetState(GameState.IntroCutscene);
    }
    private void ExitGameButtonOnPressed()
    {
        GetTree().Quit();
    }
}

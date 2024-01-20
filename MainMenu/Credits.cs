using Godot;
using System;
using GameJam2024.MainMenu;

public partial class Credits : Control
{
    [Export] public Button BackButton;

    public override void _EnterTree()
    {
        BackButton.Pressed += BackButtonOnPressed;
    }

    private void BackButtonOnPressed()
    {
        MainMenuManager.Instance.CreditsBackButtonPress();
    }
}

using Godot;
using System;
using GameJam2024.MainMenu;

public partial class Options : Control
{
    [Export] public Button BackButton;
    [Export] public OptionButton FontDropdown;

    public override void _EnterTree()
    {
        BackButton.Pressed += BackButtonOnPressed;
        FontDropdown.ItemSelected += FontDropdownOnItemSelected;
    }

    private void FontDropdownOnItemSelected(long index)
    {
        MainMenuManager.Instance.FontDropdownItemChanged(index);
    }

    private void BackButtonOnPressed()
    {
        MainMenuManager.Instance.OptionsBackButtonPress();
    }
}

using GameJam2024.GameManagement;

namespace GameJam2024.MainMenu;

public sealed class MainMenuManager
{
    public static MainMenuManager Instance { get; } = new();

    public delegate void CreditsPressedDelegate();
    public event CreditsPressedDelegate CreditsPressed;
    
    public delegate void BackButtonPressedDelegate();
    public event BackButtonPressedDelegate CreditsBackButtonPressed;
    public event BackButtonPressedDelegate OptionsBackButtonPressed;
    
    public delegate void FontChangedDelegate(long index);

    public event FontChangedDelegate FontChanged;
    
    private MainMenuManager(){}

    public void CreditsBackButtonPress()
    {
        CreditsBackButtonPressed?.Invoke();
    }

    public void OptionsBackButtonPress()
    {
        OptionsBackButtonPressed?.Invoke();
    }

    public void FontDropdownItemChanged(long index)
    {
        FontChanged?.Invoke(index);
    }

    public void InitState()
    {
        GameManager.Instance.SetState(GameState.MainMenu);
    }
}
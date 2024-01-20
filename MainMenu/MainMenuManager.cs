namespace GameJam2024.MainMenu;

public sealed class MainMenuManager
{
    public static MainMenuManager Instance { get; } = new();

    public delegate void CreditsPressedDelegate();
    public event CreditsPressedDelegate CreditsPressed;
    
    public delegate void CreditsBackButtonPressedDelegate();
    public event CreditsBackButtonPressedDelegate CreditsBackButtonPressed;
    
    private MainMenuManager(){}

    public void CreditsBackButtonPress()
    {
        CreditsBackButtonPressed?.Invoke();
    }
}


using System;

namespace GameJam2024.GameManagement;

public sealed class GameManager
{
    public static GameManager Instance { get; } = new();
    private GameState State { get; set; }
    
    public delegate void PlayIntroCutsceneDelegate();

    public event PlayIntroCutsceneDelegate PlayIntroCutscene;

    private GameManager()
    {
        
    }

    public void SetState(GameState state)
    {
        State = state;
        switch (state)
        {
            case GameState.MainMenu:
                break;
            case GameState.IntroCutscene:
                PlayIntroCutscene?.Invoke();
                break;
            case GameState.Paused:
                break;
            case GameState.Level1:
                break;
            case GameState.Level2:
                break;
            case GameState.Level3:
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    public GameState GetState()
    {
        return State;
    }
}
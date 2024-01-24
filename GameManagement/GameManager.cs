

using System;
using GameJam2024.RuneTree;
using Godot;

namespace GameJam2024.GameManagement;

public sealed class GameManager
{
    public static GameManager Instance { get; } = new();
    private GameState State { get; set; }
    private GameState LastLevel { get; set; }

    #region STATE MANAGEMENT EVENTS
    public delegate void StateChangedDelegate();
    public event StateChangedDelegate PlayIntroCutscene;
    public event StateChangedDelegate LevelOneStart;
    public event StateChangedDelegate GameOverNotify;
    public event StateChangedDelegate LevelRestart;

    public delegate void CorruptionChangedDelegate(MagicClass magicClass, int value);

    public event CorruptionChangedDelegate CorruptionChanged;

    public delegate void SpellIndexChangedDelegate(int index);

    public event SpellIndexChangedDelegate SpellIndexChanged;
    
    #endregion

    #region VARIABLES

    public int FireCorruption = 78;
    public int IceCorruption = 10;
    public int LightningCorruption = 40;

    public int SelectedSpellIndex = 0;
    public IRuneNode SelectedSpell;

    public bool IsTalentsOpen;

    #endregion
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
                LastLevel = GameState.Level1;
                LevelOneStart?.Invoke();
                break;
            case GameState.Level2:
                break;
            case GameState.Level3:
                break;
            case GameState.GameOver:
                GameOverNotify?.Invoke();
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(state), state, null);
        }
    }

    public GameState GetState()
    {
        return State;
    }

    public GameState GetLastLevel()
    {
        return LastLevel;
    }

    public void RestartLevel()
    {
        LevelRestart?.Invoke();
        switch (LastLevel)
        {
            case GameState.Level1:
                State = GameState.Level1;
                LevelOneStart?.Invoke();
                break;
            case GameState.Level2:
                break;
            case GameState.Level3:
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
    }

    public int GetTreeCorruptionValue(MagicClass magicClass)
    {
        return magicClass switch
        {
            MagicClass.Base => 0,
            MagicClass.Fire => FireCorruption,
            MagicClass.Ice => IceCorruption,
            MagicClass.Lightning => LightningCorruption,
            _ => throw new ArgumentOutOfRangeException(nameof(magicClass), magicClass, null)
        };
    }

    public void ChangeCorruptionValue(MagicClass magicClass, int valueToAdd)
    {
        switch(magicClass)
        {
            case MagicClass.Base:
                break;
            case MagicClass.Fire:
                FireCorruption += valueToAdd;
                CorruptionChanged?.Invoke(MagicClass.Fire, FireCorruption);
                break;
            case MagicClass.Ice:
                IceCorruption += valueToAdd;
                CorruptionChanged?.Invoke(MagicClass.Ice, IceCorruption);
                break;
            case MagicClass.Lightning:
                LightningCorruption += valueToAdd;
                CorruptionChanged?.Invoke(MagicClass.Lightning, LightningCorruption);
                break;
            default:
                throw new ArgumentOutOfRangeException(nameof(magicClass), magicClass, null);
        }
    }

    public void IncreaseSpellIndex()
    {
        SelectedSpellIndex = Mathf.Clamp(SelectedSpellIndex+1, 0, 2);
        SpellIndexChanged?.Invoke(SelectedSpellIndex);
    }

    public void DecreaseSpellIndex()
    {
       SelectedSpellIndex = Mathf.Clamp(SelectedSpellIndex-1, 0,2);
       SpellIndexChanged?.Invoke(SelectedSpellIndex);
    }

    public void SetSelectedSpell(IRuneNode node)
    {
        SelectedSpell = node;
    }

    public IRuneNode GetSelectedSpell()
    {
        return SelectedSpell;
    }

    public bool IsInPauseState()
    {
        return State is GameState.Paused or GameState.GameOver or GameState.IntroCutscene;
    }


}
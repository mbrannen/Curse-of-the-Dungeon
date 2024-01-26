

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

	public event StateChangedDelegate MainMenu;
	public event StateChangedDelegate PlayIntroCutscene;
	public event StateChangedDelegate LevelOneStart;
	public event StateChangedDelegate LevelTwoStart;
	public event StateChangedDelegate LevelThreeStart;
	public event StateChangedDelegate GameOverNotify;
	public event StateChangedDelegate BadEndingStart;
	public event StateChangedDelegate GoodEndingStart;
	public event StateChangedDelegate CreditsStart;
	public event StateChangedDelegate LevelRestart;

	public delegate void CorruptionChangedDelegate(MagicClass magicClass, int value);
	public event CorruptionChangedDelegate CorruptionChanged;
	public delegate void CorruptionMaxedDelegate(MagicClass magicClass);
	public event CorruptionMaxedDelegate CorruptionMaxed;

	public delegate void SpellIndexChangedDelegate(int index);

	public event SpellIndexChangedDelegate SpellIndexChanged;

	public delegate void NotifySpellCorruptedDelegate(string name);

	public event NotifySpellCorruptedDelegate NotifySpellCorrupted;
	
	public delegate void GoblinsEngagedChangedDelegate(int value);

	public event GoblinsEngagedChangedDelegate GoblinsEngagedChanged;
	
	
	
	#endregion

	#region VARIABLES

	public int FireCorruption = 0;
	public int IceCorruption = 0;
	public int LightningCorruption = 0;

	public int SelectedSpellIndex = 0;
	public IRuneNode SelectedSpell;
	
	public int GoblinsEngaged = 0;

	public bool IsTalentsOpen;

	#endregion
	private GameManager()
	{
		
	}

	private void OnNotifyHUDOfCorruption(string name)
	{
		
	}

	public void SetState(GameState state)
	{
		State = state;
		switch (state)
		{
			case GameState.MainMenu:
				MainMenu?.Invoke();
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
				LevelTwoStart?.Invoke();
				break;
			case GameState.Level3:
				LevelThreeStart?.Invoke();
				break;
			case GameState.GameOver:
				GameOverNotify?.Invoke();
				break;
			case GameState.BadEnding:
				BadEndingStart?.Invoke();
				break;
			case GameState.GoodEnding:
				GoodEndingStart?.Invoke();
				break;
			case GameState.Credits:
				CreditsStart?.Invoke();
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
		ResetValues();
		LevelRestart?.Invoke();
		switch (LastLevel)
		{
			case GameState.Level1:
				State = GameState.Level1;
				LevelOneStart?.Invoke();
				break;
			case GameState.Level2:
				State = GameState.Level2;
				LevelTwoStart?.Invoke();
				break;
			case GameState.Level3:
				State = GameState.Level3;
				LevelThreeStart?.Invoke();
				break;
			default:
				throw new ArgumentOutOfRangeException();
		}
	}

	private void ResetValues()
	{
		FireCorruption = 0;
		CorruptionChanged?.Invoke(MagicClass.Fire, FireCorruption);
		
		LightningCorruption = 0;
		CorruptionChanged?.Invoke(MagicClass.Lightning, LightningCorruption);
		
		IceCorruption = 0;
		CorruptionChanged?.Invoke(MagicClass.Ice, IceCorruption);

		SelectedSpellIndex = 0;
		SelectedSpell = null;
		
		SpellIndexChanged?.Invoke(SelectedSpellIndex);
		GoblinsEngagedChanged?.Invoke(GoblinsEngaged);
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
				if (IsFullCorruption(MagicClass.Fire))
				{
					CorruptionMaxed?.Invoke(MagicClass.Fire);
					FireCorruption -= 100;
					CorruptionChanged?.Invoke(MagicClass.Fire, FireCorruption);
				}
				else
					CorruptionChanged?.Invoke(MagicClass.Fire, FireCorruption);
				break;
			case MagicClass.Ice:
				IceCorruption += valueToAdd;
				if (IsFullCorruption(MagicClass.Ice))
				{
					CorruptionMaxed?.Invoke(MagicClass.Ice);
					IceCorruption -= 100;
					CorruptionChanged?.Invoke(MagicClass.Ice, IceCorruption);
				}
				else
					CorruptionChanged?.Invoke(MagicClass.Ice, IceCorruption);
				break;
			case MagicClass.Lightning:
				LightningCorruption += valueToAdd;
				if (IsFullCorruption(MagicClass.Lightning))
				{
					CorruptionMaxed?.Invoke(MagicClass.Lightning);
					LightningCorruption -= 100;
					CorruptionChanged?.Invoke(MagicClass.Lightning, LightningCorruption);
				}
				else
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
		return State is GameState.Paused or GameState.GameOver or GameState.IntroCutscene or GameState.CorruptTalent;
	}

	public bool IsFullCorruption(MagicClass magicClass)
	{
		return magicClass switch
		{
			MagicClass.Base => false,
			MagicClass.Fire => FireCorruption >= 100,
			MagicClass.Ice => IceCorruption >= 100,
			MagicClass.Lightning => LightningCorruption >= 100,
			_ => throw new ArgumentOutOfRangeException(nameof(magicClass), magicClass, null)
		};
	}
	
	public void IncreaseGoblinsEngaged()
	{
		GoblinsEngaged++;
		GoblinsEngagedChanged?.Invoke(GoblinsEngaged);
	}

	public void DecreaseGoblinsEngaged()
	{
		GoblinsEngaged--;
		GoblinsEngagedChanged?.Invoke(GoblinsEngaged);
	}

	public void SetGoblinsEngaged(int value)
	{
		GoblinsEngaged = value;
		GoblinsEngagedChanged?.Invoke(GoblinsEngaged);
	}

}

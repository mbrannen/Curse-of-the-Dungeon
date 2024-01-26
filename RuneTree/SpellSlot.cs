using Godot;
using System;
using System.Collections.Generic;
using GameJam2024.GameManagement;
using GameJam2024.RuneTree;

public partial class SpellSlot : PanelContainer
{
	[Export] public TextureRect IconRect;
	[Export] public Texture2D Icon;
	[Export] public Rune SpellName;
	[Export] public TextureProgressBar Corruption;
	[Export] public int SpellIndex = 0;
	[Export] public TextureRect Outline;

	public IRuneNode Rune;

	public override void _EnterTree()
	{
		
	}

	public override void _ExitTree()
	{
		GameManager.Instance.CorruptionChanged -= OnCorruptionChanged;
		GameManager.Instance.SpellIndexChanged -= OnSpellIndexChanged;
	}

	public override void _Ready()
	{
		Rune = TalentManager.Instance.GetSpell(SpellName);
		GameManager.Instance.CorruptionChanged += OnCorruptionChanged;
		GameManager.Instance.SpellIndexChanged += OnSpellIndexChanged;
		OnSpellIndexChanged(0);
		
	}

	private void OnSpellIndexChanged(int index)
	{
		if (index == SpellIndex)
		{
			Outline.Modulate = new Color(1, 1, 1, 1);
			GameManager.Instance.SetSelectedSpell(Rune);
		}
		else
		{
			Outline.Modulate = new Color(1, 1, 1, 0.5f);
		}
	}

	private void OnCorruptionChanged(MagicClass magicclass, int value)
	{
		if (Rune is not null && magicclass == Rune.MagicClass)
		{
			Corruption.Value = value;
		}
	}

	public override void _Process(double delta)
	{
		if (Rune is { Corrupted: true })
			ClearSpellSlot();
	}

	private void ClearSpellSlot()
	{
		Rune = null;
		Corruption.Value = 0;
		IconRect.Texture = null;
		GameManager.Instance.SetSelectedSpell(null);
	}

	public override bool _CanDropData(Vector2 atPosition, Variant data)
	{
		try
		{
			var test = data.Obj as Texture2D;
			return test is not null;
		}
		catch
		{
			return false;
		}
	}

	public override void _DropData(Vector2 atPosition, Variant data)
	{
		Rune = TalentManager.Instance.GetSpellDragged();
		if(GameManager.Instance.SelectedSpellIndex == SpellIndex)
			GameManager.Instance.SetSelectedSpell(Rune);
			
		Corruption.Value = GameManager.Instance.GetTreeCorruptionValue(Rune.MagicClass);
		IconRect.Texture = data.Obj as Texture2D;
		
		GetNode("../Wwise/EventRuneDrop").Call("post_event");
		UpdateTooltip();
	}

	private void UpdateTooltip()
	{
		TooltipText =  $"{Rune.Name.ToUpper()}\n" +
					   $"Corruption Cost: {Rune.CorruptionCost}\n" +
					   $"'{Rune.Description}'";
	}
	
}

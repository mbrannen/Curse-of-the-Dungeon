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
    
    public override void _Ready()
    {
        Rune = TalentManager.Instance.GetSpell(SpellName);
        GameManager.Instance.CorruptionChanged += OnCorruptionChanged;
        GameManager.Instance.SpellIndexChanged += OnSpellIndexChanged;
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
        if (magicclass == Rune.MagicClass)
        {
            Corruption.Value = value;
        }
    }

    public override void _Process(double delta)
    {

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
        Corruption.Value = GameManager.Instance.GetTreeCorruptionValue(Rune.MagicClass);
        IconRect.Texture = data.Obj as Texture2D;
        UpdateTooltip();
    }

    private void UpdateTooltip()
    {
        TooltipText =  $"{Rune.Name.ToUpper()}\n" +
                       $"'{Rune.Description}'";
    }
    
}

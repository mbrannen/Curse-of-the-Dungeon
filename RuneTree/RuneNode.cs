using Godot;
using System;
using System.Collections.Generic;
using GameJam2024.RuneTree;

public partial class RuneNode : PanelContainer
{
    [Export] public TextureRect IconRect;
    [Export] public Texture2D Icon;
    [Export] public Rune SpellName;

    public IRuneNode Rune;

    public override void _EnterTree()
    {
        
    }

    public override void _Ready()
    {
        Rune = TalentManager.Instance.GetSpell(SpellName);
        IconRect.Texture = Icon;
        
        TooltipText =  $"{Rune.Name.ToUpper()}\n" +
                      $"'{Rune.Description}'";
    }
}

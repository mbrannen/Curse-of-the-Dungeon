using Godot;
using System;
using System.Collections.Generic;
using GameJam2024.RuneTree;

public partial class SpellSlot : PanelContainer
{
    [Export] public TextureRect IconRect;
    [Export] public Texture2D Icon;
    [Export] public Rune SpellName;
    [Export] public TextureRect Corruption;

    public IRuneNode Rune;

    public override void _EnterTree()
    {
        
    }
    
    public override void _Ready()
    {
        Rune = TalentManager.Instance.GetSpell(SpellName);
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
        IconRect.Texture = data.Obj as Texture2D;
        UpdateTooltip();
    }

    private void UpdateTooltip()
    {
        TooltipText =  $"{Rune.Name.ToUpper()}\n" +
                       $"'{Rune.Description}'";
    }

    public override Variant _GetDragData(Vector2 atPosition)
    {
        return base._GetDragData(atPosition);
    }
}

using Godot;
using System;
using System.Collections.Generic;
using GameJam2024.RuneTree;

public partial class RuneNode : PanelContainer
{
    [Export] public TextureRect IconRect;
    [Export] public Texture2D Icon;
    [Export] public Rune SpellName;
    [Export] public TextureRect Corruption;

    private bool _coruptionAnimationFinished;
    private float _corruptionShaderOpacity = 0f;

    public IRuneNode Rune;

    public override void _EnterTree()
    {
        
    }
    
    public override void _Ready()
    {
        Rune = TalentManager.Instance.GetSpell(SpellName);
        Corruption.Visible = false;
        IconRect.Texture = Icon;
        
        TooltipText =  $"{Rune.Name.ToUpper()}\n" +
                       $"'{Rune.Description}'";
    }

    public override void _Process(double delta)
    {
        if (Rune.Corrupted && !_coruptionAnimationFinished)
            PlayCorruptionAnimation(delta);
    }

    private void PlayCorruptionAnimation(double delta)
    {
        //THIS ONLY WORKS ONCE~ish
        Corruption.Visible = true;
        _corruptionShaderOpacity += Mathf.Clamp((float)delta * 0.3f, 0,1) ;
        (Corruption.Material as ShaderMaterial).SetShaderParameter("total_opacity",_corruptionShaderOpacity);
        if (_corruptionShaderOpacity >= 1)
            _coruptionAnimationFinished = true;
    }
    
}

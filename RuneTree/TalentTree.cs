namespace GameJam2024.RuneTree;

public class TalentTree : SpellModifierRuneBase
{
    public override MagicClass MagicClass => MagicClass.Base;
    public override Rune RuneType { get; } = Rune.Base;
    public override string Name => "BASETREE";
    public override string Description => "DO NOT ACTUALLY USE ME FOR ANY SPELL FUNCTIONALITY AT THE MOMENT";
}
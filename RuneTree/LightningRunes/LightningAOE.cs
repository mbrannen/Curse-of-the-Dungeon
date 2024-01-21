namespace GameJam2024.RuneTree.LightningRunes;

public class LightningAOE : SpellModifierRuneBase
{
    public override MagicClass MagicClass => MagicClass.Lightning;
    public override Rune RuneType { get; } = Rune.LightningAOE;
    public override string Name => SpellNames.LIGHTNING_AOE;
    public override string Description => "Some flavor text.";
}
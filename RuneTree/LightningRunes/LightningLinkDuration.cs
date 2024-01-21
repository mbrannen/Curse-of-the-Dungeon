namespace GameJam2024.RuneTree.LightningRunes;

public class LightningLinkDuration : SpellModifierRuneBase
{
    public override MagicClass MagicClass => MagicClass.Lightning;
    public override Rune RuneType { get; } = Rune.LightningLinkDuration;
    public override string Name => SpellNames.LIGHTNING_LINK_DURATION;
    public override string Description => "Some flavor text.";
}
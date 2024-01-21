namespace GameJam2024.RuneTree.LightningRunes;

public class LightningLinkCount : SpellModifierRuneBase
{
    public override MagicClass MagicClass => MagicClass.Lightning;
    public override Rune RuneType { get; } = Rune.LightningLinkCount;
    public override string Name => SpellNames.LIGHTNING_LINK_COUNT;
    public override string Description => "Some flavor text.";
}
namespace GameJam2024.RuneTree.IceRunes;

public class IceBlockDuration : SpellModifierRuneBase
{
    public override MagicClass MagicClass => MagicClass.Ice;
    public override Rune RuneType { get; } = Rune.IceBlockDuration;
    public override string Name => SpellNames.ICE_BLOCK_DURATION;
    public override string Description => "Some flavor text.";
}
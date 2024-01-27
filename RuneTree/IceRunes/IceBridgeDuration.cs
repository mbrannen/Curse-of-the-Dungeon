namespace GameJam2024.RuneTree.IceRunes;

public class IceBridgeDuration : SpellModifierRuneBase
{
    public override MagicClass MagicClass => MagicClass.Ice;
    public override Rune RuneType { get; } = Rune.IceBridgeDuration;
    public override string Name => SpellNames.ICE_BRIDGE_DURATION;
    public override string Description => "Good things should always last longer.";
}
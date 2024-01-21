namespace GameJam2024.RuneTree.IceRunes;

public class IceBridge : SpellRuneBase
{
    public override MagicClass MagicClass => MagicClass.Ice;
    public override Rune RuneType { get; } = Rune.IceBridge;
    public override string Name => SpellNames.ICE_BRIDGE;
    public override string Description => "Some flavor text.";
}
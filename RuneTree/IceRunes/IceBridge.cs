namespace GameJam2024.RuneTree.IceRunes;

public class IceBridge : SpellRuneBase
{
    public override MagicClass MagicClass => MagicClass.Ice;
    public override Rune RuneType { get; } = Rune.IceBridge;
    public override int CorruptionCost { get; } = 50;
    public override string Name => SpellNames.ICE_BRIDGE;
    public override string Description => "Create icy terrain at will to\ncross impassable chasms.";

    public override bool MovesWhenCast => false;
    public override bool IsPlaceable => true;
}
namespace GameJam2024.RuneTree.IceRunes;

public class IceBlock : SpellRuneBase
{
    public override MagicClass MagicClass => MagicClass.Ice;
    public override Rune RuneType => Rune.IceBlock;
    public override int CorruptionCost { get; } = 100;
    public override string Name => SpellNames.ICE_BLOCK;
    public override string Description => "Guard against threats by imprisoning them\n within an impenetrable frozen block.";
    public override bool MovesWhenCast { get; } = false;
    public override bool IsPlaceable { get; } = true;
}
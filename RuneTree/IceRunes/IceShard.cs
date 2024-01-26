namespace GameJam2024.RuneTree.IceRunes;

public class IceShard : SpellRuneBase
{
    public override MagicClass MagicClass => MagicClass.Ice;
    public override Rune RuneType { get; } = Rune.IceShard;
    public override int CorruptionCost { get; } = 50;
    public override string Name => SpellNames.ICE_SHARD;
    public override string Description => "Launch a glacial missile to neutralize\neven the most fiery spirits.";
    public override bool MovesWhenCast { get; } = true;
    public override bool IsPlaceable { get; } = false;
}
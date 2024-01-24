namespace GameJam2024.RuneTree.IceRunes;

public class IcePatch : SpellRuneBase
{
    public override MagicClass MagicClass => MagicClass.Ice;
    public override Rune RuneType { get; } = Rune.IcePatch;
    public override int CorruptionCost { get; } = 100;
    public override string Name => SpellNames.ICE_PATCH;
    public override string Description => "Some flavor text.";
    public override bool MovesWhenCast { get; } = false;
    public override bool IsPlaceable { get; } = true;
}
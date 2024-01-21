namespace GameJam2024.RuneTree.IceRunes;

public class IcePatch : SpellRuneBase
{
    public override MagicClass MagicClass => MagicClass.Ice;
    public override Rune RuneType { get; } = Rune.IcePatch;
    public override string Name => SpellNames.ICE_PATCH;
    public override string Description => "Some flavor text.";
}
namespace GameJam2024.RuneTree.IceRunes;

public class IcePatchSize : SpellModifierRuneBase
{
    public override MagicClass MagicClass => MagicClass.Ice;
    public override Rune RuneType { get; } = Rune.IcePatchSize;
    public override string Name => SpellNames.ICE_PATCH_SIZE;
    public override string Description => "Some flavor text.";
}
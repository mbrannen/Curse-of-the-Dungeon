namespace GameJam2024.RuneTree.IceRunes;

public class IceBlock : SpellRuneBase
{
    public override MagicClass MagicClass => MagicClass.Ice;
    public override Rune RuneType => Rune.IceBlock;
    public override string Name => SpellNames.ICE_BLOCK;
    public override string Description => "Some flavor text";
}
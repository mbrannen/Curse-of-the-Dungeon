namespace GameJam2024.RuneTree.IceRunes;

public class IceBlock : SpellRuneBase
{
    public override MagicClass MagicClass { get; } = MagicClass.Ice;
    public override string Name { get; } = "Ice Block";
    public override string Description { get; } = "Some flavor text";
}
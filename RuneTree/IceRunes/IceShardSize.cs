namespace GameJam2024.RuneTree.IceRunes;

public class IceShardSize : SpellModifierRuneBase
{
    public override MagicClass MagicClass => MagicClass.Ice;
    public override Rune RuneType { get; } = Rune.IceShardSize;
    public override string Name => SpellNames.ICE_SHARD_SIZE;
    public override string Description => "Hubarus's frost grows greater with\ncold, calculated ambition.";
}
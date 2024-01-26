namespace GameJam2024.RuneTree.FireRunes;

public class FireBallSize : SpellModifierRuneBase
{
    public override MagicClass MagicClass => MagicClass.Fire;
    public override Rune RuneType { get; } = Rune.FireballSize;
    public override string Name => SpellNames.FIREBALL_SIZE; //subject to change
    public override string Description => "The power of Hubarus's obsessions kindles his fireballs into larger and more powerful casts."; //subject to change
}
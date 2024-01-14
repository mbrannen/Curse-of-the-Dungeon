namespace GameJam2024.RuneTree.FireRunes;

public class FireBallSize : SpellModifierRuneBase
{
    public override MagicClass MagicClass { get; } = MagicClass.Fire;
    public override string Name { get; } = "Kindling"; //subject to change
    public override string Description { get; } = "The power of {NAME}'s obsessions kindles his fireballs into larger and more powerful casts."; //subject to change
}
namespace GameJam2024.RuneTree.FireRunes;

public class FireballCount : SpellModifierRuneBase
{
    public override MagicClass MagicClass => MagicClass.Fire;
    public override Rune RuneType { get; } = Rune.FireballCount;
    public override string Name => SpellNames.FIREBALL_COUNT; //subject to change
    public override string Description => "{NAME}'s love of fire grew to casting multiple fireballs."; //subject to change
}
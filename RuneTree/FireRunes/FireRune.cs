namespace GameJam2024.RuneTree.FireRunes;

public class FireRune : SpellRuneBase
{
    public override MagicClass MagicClass => MagicClass.Fire;
    public override Rune RuneType => Rune.FireRune;
    public override string Name => SpellNames.FIRE_RUNE;
    public override string Description => "The rune from which {NAME} draws essence for all of his Fire abilities.  " +
                                          "Offers but a small flame.";
}
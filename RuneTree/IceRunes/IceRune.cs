namespace GameJam2024.RuneTree.IceRunes;

public class IceRune : SpellRuneBase
{
    public override MagicClass MagicClass => MagicClass.Ice;
    public override string Name => SpellNames.ICE_RUNE;
    public override string Description => "The rune from which {NAME} draws essence for all of his Ice abilities.  " +
                                          "It's cool to the touch.";
}
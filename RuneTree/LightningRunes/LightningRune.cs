namespace GameJam2024.RuneTree.LightningRunes;

public class LightningRune : SpellRuneBase
{
    public override MagicClass MagicClass => MagicClass.Lightning;
    public override string Name => SpellNames.LIGHTNING_RUNE;
    public override string Description => "The rune from which {NAME} draws essence for all of his Lightning abilities.  " +
                                          "Produces merely a spark.";
}
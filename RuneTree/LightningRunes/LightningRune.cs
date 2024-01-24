namespace GameJam2024.RuneTree.LightningRunes;

public class LightningRune : SpellRuneBase
{
    public override MagicClass MagicClass => MagicClass.Lightning;
    public override Rune RuneType { get; } = Rune.LightningRune;
    public override int CorruptionCost { get; } = 100;
    public override string Name => SpellNames.LIGHTNING_RUNE;
    public override string Description => "The rune from which {NAME} draws essence for \n all of his Lightning abilities.  " +
                                          "Produces merely a spark.";

    public override bool MovesWhenCast { get; } = true;
    public override bool IsPlaceable { get; } = false;
}
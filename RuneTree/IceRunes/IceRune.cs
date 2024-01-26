namespace GameJam2024.RuneTree.IceRunes;

public class IceRune : SpellRuneBase
{
    public override MagicClass MagicClass => MagicClass.Ice;
    public override Rune RuneType { get; } = Rune.IceRune;
    public override int CorruptionCost { get; } = 50;
    public override string Name => SpellNames.ICE_RUNE;
    public override string Description => "The rune from which Hubarus draws essence \n for all of his Ice abilities.  " +
                                          "It's cool to the touch.";

    public override bool MovesWhenCast { get; } = true;
    public override bool IsPlaceable { get; } = false;
}
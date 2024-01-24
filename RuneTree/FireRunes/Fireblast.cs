namespace GameJam2024.RuneTree.FireRunes;

public class Fireblast : SpellRuneBase
{
    public override MagicClass MagicClass => MagicClass.Fire;
    public override Rune RuneType => Rune.Fireblast;
    public override int CorruptionCost { get; } = 50;
    public override string Name => SpellNames.FIREBLAST;
    public override string Description => "A concentrated jet of flames emits forward in a straight line.";
    public override bool MovesWhenCast { get; } = true;
    public override bool IsPlaceable { get; } = false;
}
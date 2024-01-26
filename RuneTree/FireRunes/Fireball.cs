namespace GameJam2024.RuneTree.FireRunes;

public class Fireball : SpellRuneBase
{
    public override MagicClass MagicClass => MagicClass.Fire;
    public override Rune RuneType => Rune.Fireball;
    public override int CorruptionCost { get; } = 40;
    public override string Name => SpellNames.FIREBALL;
    public override string Description => "A controlled ball of flame that emits forward from {NAME}'s hands.";
    public override bool MovesWhenCast { get; } = true;
    public override bool IsPlaceable { get; } = false;
}
namespace GameJam2024.RuneTree.FireRunes;

public class Firewall : SpellRuneBase
{
    public override MagicClass MagicClass => MagicClass.Fire;
    public override Rune RuneType => Rune.Firewall;
    public override int CorruptionCost { get; } = 50;
    public override string Name => SpellNames.FIREWALL;
    public override string Description => "A wall of flames protects you from the foes outside of it.";
    public override bool MovesWhenCast { get; } = false;
    public override bool IsPlaceable { get; } = true;
}
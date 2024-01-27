namespace GameJam2024.RuneTree.FireRunes;

public class FirewallLength : SpellModifierRuneBase
{
    public override MagicClass MagicClass => MagicClass.Fire;
    public override Rune RuneType { get; } = Rune.FirewallLength;
    public override string Name => SpellNames.FIREWALL_LENGTH;
    public override string Description => "Even more protection from your foes.";
}
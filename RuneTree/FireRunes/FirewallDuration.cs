namespace GameJam2024.RuneTree.FireRunes;

public class FirewallDuration : SpellModifierRuneBase
{
    public override MagicClass MagicClass => MagicClass.Fire;
    public override Rune RuneType { get; } = Rune.FirewallDuration;
    public override string Name => SpellNames.FIREWALL_DURATION;
    public override string Description => "Hubarus's passions keep the fires burning"; //please replace this sucks. - matt
}
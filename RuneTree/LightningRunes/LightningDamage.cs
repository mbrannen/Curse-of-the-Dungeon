namespace GameJam2024.RuneTree.LightningRunes;

public class LightningDamage : SpellModifierRuneBase
{
    public override MagicClass MagicClass => MagicClass.Lightning;
    public override Rune RuneType { get; } = Rune.LightningDamage;
    public override string Name => SpellNames.LIGHTNING_DAMAGE;
    
    public override string Description => "Some flavor text";
}
using Godot;

namespace GameJam2024.RuneTree;

public partial class TalentHUDManager : Control
{
	[Export] public Color CorruptionColor;
	//this is maybe the hardcoding way to go about it
	//don't really like how this is handled but gonna do it this way anyway
	[Export] public Control BaseFireRune;
	[Export] public Control BaseIceRune;
	[Export] public Control BaseLightningRune;
	
	[Export] public Control FireballRune;
	[Export] public Control FireballCountRune;
	[Export] public Control FireballSizeRune;
	[Export] public Control FireblastRune;
	[Export] public Control FirewallRune;
	[Export] public Control FirewallDurationRune;
	[Export] public Control FirewallLengthRune;
	
	[Export] public Control IceShardRune;
	[Export] public Control IceShardSizeRune;
	[Export] public Control IceBlockRune;
	[Export] public Control IceBlockDurationRune;
	[Export] public Control IcePatchRune;
	[Export] public Control IcePatchSizeRune;
	[Export] public Control IceBridgeRune;
	[Export] public Control IceBridgeDurationRune;
	
	[Export] public Control LightningDamageRune;
	[Export] public Control LightningAOERune;
	[Export] public Control LightningLinkCountRune;
	[Export] public Control LightningLinkDurationRune;

	public override void _EnterTree()
	{
		TalentManager.Instance.NotifyHUDOfCorruption += OnNotifyHUDOfCorruption;
	}

	public override void _Ready()
	{
		//initial corruption 
		TalentManager.Instance.CorruptSpecificNode(SpellNames.FIREBALL_SIZE);
		TalentManager.Instance.CorruptSpecificNode(SpellNames.FIREWALL_LENGTH);
		
		TalentManager.Instance.CorruptSpecificNode(SpellNames.ICE_SHARD_SIZE);
		TalentManager.Instance.CorruptSpecificNode(SpellNames.ICE_PATCH_SIZE);
		TalentManager.Instance.CorruptSpecificNode(SpellNames.ICE_BLOCK_DURATION);
		TalentManager.Instance.CorruptSpecificNode(SpellNames.ICE_BRIDGE_DURATION);
		
		TalentManager.Instance.CorruptSpecificNode(SpellNames.LIGHTNING_AOE);
		
	}

	private void OnNotifyHUDOfCorruption(string name)
	{
		//honestly i hate this.  plz help.
		//maybe nodes need to be there own scenes and we can dynamically instance them and find them by name?
		switch (name)
		{
			case SpellNames.FIRE_RUNE:
				ModulateColorForCorruption(BaseFireRune);
				break;
			case SpellNames.ICE_RUNE:
				ModulateColorForCorruption(BaseIceRune);
				break;
			case SpellNames.LIGHTNING_RUNE:
				ModulateColorForCorruption(BaseLightningRune);
				break;
			case SpellNames.FIREBALL:
				ModulateColorForCorruption(FireballRune);
				break;
			case SpellNames.FIREBALL_COUNT:
				ModulateColorForCorruption(FireballCountRune);
				break;
			case SpellNames.FIREBALL_SIZE:
				ModulateColorForCorruption(FireballSizeRune);
				break;
			case SpellNames.FIREWALL:
				ModulateColorForCorruption(FirewallRune);
				break;
			case SpellNames.FIREWALL_LENGTH:
				ModulateColorForCorruption(FirewallLengthRune);
				break;
			case SpellNames.FIREWALL_DURATION:
				ModulateColorForCorruption(FirewallDurationRune);
				break;
			case SpellNames.FIREBLAST:
				ModulateColorForCorruption(FireblastRune);
				break;
			case SpellNames.ICE_SHARD:
				break;
			case SpellNames.ICE_SHARD_SIZE:
				ModulateColorForCorruption(IceShardSizeRune);
				break;
			case SpellNames.ICE_PATCH:
				break;
			case SpellNames.ICE_PATCH_SIZE:
				ModulateColorForCorruption(IcePatchSizeRune);
				break;
			case SpellNames.ICE_BLOCK:
				break;
			case SpellNames.ICE_BLOCK_DURATION:
				ModulateColorForCorruption(IceBlockDurationRune);
				break;
			case SpellNames.ICE_BRIDGE:
				break;
			case SpellNames.ICE_BRIDGE_DURATION:
				ModulateColorForCorruption(IceBridgeDurationRune);
				break;
			case SpellNames.LIGHTNING_AOE:
				ModulateColorForCorruption(LightningAOERune);
				break;
		}
	}

	private void ModulateColorForCorruption(Control node)
	{
		var nodeAsScript = node as RuneNode;
	}
}

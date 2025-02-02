using System;
using GameJam2024.GameManagement;
using GameJam2024.RuneTree.FireRunes;
using GameJam2024.RuneTree.IceRunes;
using GameJam2024.RuneTree.LightningRunes;
using Godot;

namespace GameJam2024.RuneTree;

public sealed class TalentManager
{
	public static TalentManager Instance { get; } = new();

	public IRuneNode TalentTree;

	public IRuneNode FireTree;

	public IRuneNode IceTree;

	public IRuneNode LightningTree;

	public delegate void NotifyHUDOfCorruptionDelegate(string name);

	public event NotifyHUDOfCorruptionDelegate NotifyHUDOfCorruption;
	
	//ting
	private IRuneNode DraggedSpell;
	
	//private constructor
	private TalentManager()
	{
		//A BASE TREE FOR WHICH TO BRANCH OUT ALL OTHER TREES.  HELPFUL FOR SEARCHING
		TalentTree = new TalentTree();
		
		//instantiate the base runes of each tree
		FireTree = new FireRune();
		IceTree = new IceRune();
		LightningTree = new LightningRune();
		
		//####################################################
		//Build out the fire tree
		//####################################################
		//build out the fireball branch
		var fireball = new Fireball();
		var count = new FireballCount();
		var size = new FireBallSize();
		fireball.ConnectNode(count);
		fireball.ConnectNode(size);
		
		//build out the fireblast branch
		var fireblast = new Fireblast();
		
		//build out the Firewall branch
		var firewall = new Firewall();
		var length = new FirewallLength();
		var duration = new FirewallDuration();
		firewall.ConnectNode(length);
		firewall.ConnectNode(duration);

		//add branches to base node
		FireTree.ConnectNode(fireball);
		FireTree.ConnectNode(fireblast);
		FireTree.ConnectNode(firewall);
		
		//####################################################
		//Build out the Ice Tree
		//####################################################
		//build out Ice Shard branch
		var iceshard = new IceShard();
		var shardSize = new IceShardSize();
		iceshard.ConnectNode(shardSize);
		
		//build out Ice Block branch
		var iceblock = new IceBlock();
		var blockDuration = new IceBlockDuration();
		iceblock.ConnectNode(blockDuration);
		
		//build out Ice Bridge branch
		var icebridge = new IceBridge();
		var bridgeDuration = new IceBridgeDuration();
		icebridge.ConnectNode(bridgeDuration);
		
		//build out Ice Patch branch
		var icepatch = new IcePatch();
		var patchSize = new IcePatchSize();
		icepatch.ConnectNode(patchSize);
		
		//add branches to base node
		IceTree.ConnectNode(iceshard);
		IceTree.ConnectNode(iceblock);
		IceTree.ConnectNode(icebridge);
		IceTree.ConnectNode(icepatch);
		
		//####################################################
		//Build out the Lightning Tree
		//####################################################
		//build out Lightning tree
		var lightningDamage = new LightningDamage();
		var lightningLink = new LightningLinkCount();
		lightningDamage.ConnectNode(lightningLink);
		var lightningDuration = new LightningLinkDuration();
		lightningLink.ConnectNode(lightningDuration);
		var lightningAOE = new LightningAOE();
		lightningDuration.ConnectNode(lightningAOE);
		
		LightningTree.ConnectNode(lightningDamage);
		
		TalentTree.ConnectNode(FireTree);
		TalentTree.ConnectNode(IceTree);
		TalentTree.ConnectNode(LightningTree);
		
		//now that the tree is set up, subscribe to all the various events
		SubscribeToAllTalentTreeEvents(TalentTree);
		GameManager.Instance.CorruptionMaxed += OnCorruptionMaxed;
		
	}

	private void OnCorruptionMaxed(MagicClass magicclass)
	{
		switch (magicclass)
		{
			case MagicClass.Fire:
				FireTree.CorruptNextNode();
				break;
			case MagicClass.Ice:
				IceTree.CorruptNextNode();
				break;
			case MagicClass.Lightning:
				LightningTree.CorruptNextNode();
				break;
			default:
				throw new ArgumentOutOfRangeException(nameof(magicclass), magicclass, null);
		}
	}


	//this function listens to the NodeBecameCorrupted event on nodes
	private void OnNodeBecameCorrupted(IRuneNode node)
	{
		NotifyHUDOfCorruption?.Invoke(node.Name);
	}
	
	//function does as it says, will find a node and corrupt it
	public void CorruptSpecificNode(string name)
	{
		TalentTree.GetSpecificNode(name).CorruptNode();
	}
	
	//This is a recursive function to traverse the entire talent tree and subscribe to the events on each node
	public void SubscribeToAllTalentTreeEvents(IRuneNode nodeTree)
	{
		if (nodeTree.Children.Count != 0)
		{
			foreach (var child in nodeTree.Children)
			{
				//can add all the events you want here
				child.NodeBecameCorrupted += OnNodeBecameCorrupted;
				SubscribeToAllTalentTreeEvents(child);
			}
		}
	}
	/// <summary>
	/// A function for getting the spell information to attach to the RuneNode scene
	/// </summary>
	/// <param name="runeType"></param>
	/// <returns>An IRuneNode class related to the specified enum </returns>
	/// <exception cref="ArgumentOutOfRangeException"></exception>
	public IRuneNode GetSpell(Rune runeType)
	{
		return runeType switch
		{
			Rune.Fireball => TalentTree.GetSpecificNode(Rune.Fireball),
			Rune.FireballCount => TalentTree.GetSpecificNode(Rune.FireballCount),
			Rune.FireballSize => TalentTree.GetSpecificNode(Rune.FireballSize),
			Rune.Fireblast => TalentTree.GetSpecificNode(Rune.Fireblast),
			Rune.FireRune => TalentTree.GetSpecificNode(Rune.FireRune),
			Rune.Firewall => TalentTree.GetSpecificNode(Rune.Firewall),
			Rune.FirewallDuration => TalentTree.GetSpecificNode(Rune.FirewallDuration),
			Rune.FirewallLength => TalentTree.GetSpecificNode(Rune.FirewallLength),
			Rune.IceBlock => TalentTree.GetSpecificNode(Rune.IceBlock),
			Rune.IceBlockDuration => TalentTree.GetSpecificNode(Rune.IceBlockDuration),
			Rune.IceBridge => TalentTree.GetSpecificNode(Rune.IceBridge),
			Rune.IceBridgeDuration => TalentTree.GetSpecificNode(Rune.IceBridgeDuration),
			Rune.IcePatch => TalentTree.GetSpecificNode(Rune.IcePatch),
			Rune.IcePatchSize => TalentTree.GetSpecificNode(Rune.IcePatchSize),
			Rune.IceRune => TalentTree.GetSpecificNode(Rune.IceRune),
			Rune.IceShard => TalentTree.GetSpecificNode(Rune.IceShard),
			Rune.IceShardSize => TalentTree.GetSpecificNode(Rune.IceShardSize),
			Rune.LightningAOE => TalentTree.GetSpecificNode(Rune.LightningAOE),
			Rune.LightningDamage => TalentTree.GetSpecificNode(Rune.LightningDamage),
			Rune.LightningLinkCount => TalentTree.GetSpecificNode(Rune.LightningLinkCount),
			Rune.LightningLinkDuration => TalentTree.GetSpecificNode(Rune.LightningLinkDuration),
			Rune.LightningRune => TalentTree.GetSpecificNode(Rune.LightningRune),
			_ => TalentTree
		};
	}

	//hold the spell that was dragged as a state
	public void SpellDragged(IRuneNode node)
	{
		DraggedSpell = node;
	}

	public IRuneNode GetSpellDragged()
	{
		return DraggedSpell;
	}
}

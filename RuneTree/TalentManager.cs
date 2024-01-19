using GameJam2024.RuneTree.FireRunes;
using GameJam2024.RuneTree.IceRunes;
using GameJam2024.RuneTree.LightningRunes;
using Godot;

namespace GameJam2024.RuneTree;

public partial class TalentManager : Node
{
    public static TalentManager Instance { get; } = new();

    public IRuneNode TalentTree;

    public IRuneNode FireTree;

    public IRuneNode IceTree;

    public IRuneNode LightningTree;
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
        
        var test = TalentTree.GetSpecificNode(SpellNames.ICE_PATCH_SIZE);

    }
    
    //TODO: create a function that will corrupt nodes on a trigger (ie artifact being picked up)
}
using GameJam2024.RuneTree.FireRunes;
using GameJam2024.RuneTree.IceRunes;
using GameJam2024.RuneTree.LightningRunes;

namespace GameJam2024.RuneTree;

public sealed class TalentManager
{
    public static TalentManager Instance { get; } = new();

    public IRuneNode FireTree;

    public IRuneNode IceTree;

    public IRuneNode LightningTree;
    //private constructor
    private TalentManager()
    {
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
        
    }
}
using System.Collections.Generic;
using System.Linq;

namespace GameJam2024.RuneTree;

public abstract class SpellModifierRuneBase : IRuneNode
{
    public abstract MagicClass MagicClass { get; }
    public abstract Rune RuneType { get; }
    public IRuneNode Parent { get; set; }
    public List<IRuneNode> Children { get; set; } = new ();
    
    public bool IsActive { get; set; }
    public bool Corrupted { get; set; }
    public int CorruptionCost { get; }
    public event IRuneNode.NodeBecameCorruptedDelegate NodeBecameCorrupted;
    public void CorruptNode(bool fireSound)
    {
        Corrupted = true;
        NodeBecameCorrupted?.Invoke(this, fireSound);
    }

    public void CorruptNextNode()
    {
        if (Corrupted)
            return;
        //first see if children are corrupted
        var ChildrenCorruptedCount = 0;
        foreach (var child in Children)
        {
            if (child.Corrupted)
            {
                ChildrenCorruptedCount++; //if any are not then this will be false
            }
        }

        if (ChildrenCorruptedCount == Children.Count)
        {
            CorruptNode(true); //corrupt self
            return;
        }
            
        //if no children are corrupted then move further through the tree
        //select a random child and go down that tree
        var random = new Godot.RandomNumberGenerator();
        var childCount = Children.Count;
        if (childCount != 0)
        {
            var filteredChildred = Children.Where(c => !c.Corrupted).ToList(); 
            filteredChildred[random.RandiRange(0,filteredChildred.Count-1)].CorruptNextNode();
        }
    }

    public abstract string Name { get; }
    public abstract string Description { get; }
    public bool IsDraggable { get; } = false;
    public bool MovesWhenCast { get; } = false;
    public bool IsPlaceable { get; } = false;

    public void ConnectNode(IRuneNode child)
    {
        Children.Add(child);
        child.Parent = this;
    }

    public IRuneNode GetSpecificNode(string name)
    {
        if (name == Name)
        {
            return this;
        }

        if (Children.Count != 0)
        {
            foreach (var child in Children)
            {
                var node = child.GetSpecificNode(name);
                if (node is not null)
                    return node;
            }
        }
        return null;
    }
    
    public IRuneNode GetSpecificNode(Rune runeType)
    {
        if (runeType == RuneType)
        {
            return this;
        }

        if (Children.Count != 0)
        {
            foreach (var child in Children)
            {
                var node = child.GetSpecificNode(runeType);
                if (node is not null)
                    return node;
            }
        }
        return null;
    }
}
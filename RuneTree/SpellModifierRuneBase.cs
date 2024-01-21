using System.Collections.Generic;

namespace GameJam2024.RuneTree;

public abstract class SpellModifierRuneBase : IRuneNode
{
    public abstract MagicClass MagicClass { get; }
    public abstract Rune RuneType { get; }
    public IRuneNode Parent { get; set; }
    public List<IRuneNode> Children { get; set; } = new ();
    
    public bool IsActive { get; set; }
    public bool Corrupted { get; set; }
    public event IRuneNode.NodeBecameCorruptedDelegate NodeBecameCorrupted;
    public void CorruptNode()
    {
        Corrupted = true;
        NodeBecameCorrupted?.Invoke(this);
    }

    public abstract string Name { get; }
    public abstract string Description { get; }
    public bool IsDraggable { get; } = false;

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
using System.Collections.Generic;

namespace GameJam2024.RuneTree;

public interface IRuneNode
{
    public MagicClass MagicClass { get; }
    public IRuneNode Parent { get; set; }
    public List<IRuneNode> Children { get; set; }
    
    public bool IsActive { get; set; }
    
    public string Name { get; }
    public string Description { get; }

    public void ConnectNode(IRuneNode child);
    public IRuneNode GetSpecificNode(string name);
    
    public bool Corrupted { get; set; }
    public delegate void NodeBecameCorruptedDelegate(IRuneNode node);
    public event NodeBecameCorruptedDelegate NodeBecameCorrupted;
    public void CorruptNode();
}
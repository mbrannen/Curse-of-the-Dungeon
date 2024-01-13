using System.Collections.Generic;

namespace GameJam2024.RuneTree;

public interface IRuneNode
{
    public MagicClass MagicClass { get; }
    public IRuneNode Parent { get; set; }
    public List<IRuneNode> Children { get; set; }
    
    public bool IsActive { get; set; }
    public bool Corrupted { get; set; }
    
    public string Name { get; }
    public string Description { get; }

    public void ConnectNode(IRuneNode child);
}
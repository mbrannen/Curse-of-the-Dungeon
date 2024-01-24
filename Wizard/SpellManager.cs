using Godot;
using System;
using GameJam2024.GameManagement;
using GameJam2024.RuneTree;

public partial class SpellManager : Marker2D
{
    [Export] public PackedScene Fireball;
    [Export] public PackedScene Fireblast;
    [Export] public PackedScene Firewall;
    [Export] public PackedScene Lightning;
    [Export] public PackedScene IceShard;
    [Export] public PackedScene IceBlock;
    [Export] public PackedScene IcePatch;
    [Export] public PackedScene IceBridge;

    public PackedScene GetSpell()
    {
        var rune = GameManager.Instance.GetSelectedSpell();
        return rune.RuneType switch
        {
            Rune.Fireball => Fireball,
            Rune.Fireblast => Fireblast,
            Rune.FireRune => Fireball,
            Rune.Firewall => Firewall,
            Rune.IceBlock => IceBlock,
            Rune.IceBridge => IceBridge,
            Rune.IcePatch => IcePatch,
            Rune.IceRune => IceShard,
            Rune.IceShard => IceShard,
            Rune.LightningRune => Lightning,
            _ => throw new ArgumentOutOfRangeException()
        };
    }
}

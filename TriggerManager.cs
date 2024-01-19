using GameJam2024.RuneTree;
using GameJam2024.RuneTree.FireRunes;
using GameJam2024.RuneTree.IceRunes;
using GameJam2024.RuneTree.LightningRunes;
using Godot;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GameJam2024;

/// <summary>
/// Class <c>TriggerManager</c> handles all of the events relating to the trigger interactable items and environments.
/// </summary>
public partial class TriggerManager : Node
{
    public static TriggerManager Instance { get; } = new();


    //TODO:  Need to add to the character controller when the wizard cast a spell 
    public delegate void SpellCastingEventHandler(SpellRuneBase spell, IEnvironmentObject target);

    public event SpellCastingEventHandler SpellCastingEvent;

}

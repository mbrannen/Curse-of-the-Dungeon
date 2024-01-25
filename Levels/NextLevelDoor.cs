using GameJam2024.GameManagement;
using Godot;
using System;

public partial class NextLevelDoor : Area2D
{
	[Export] Area2D LightningRod;
	[Export] Area2D IceRod;
	[Export] Area2D FireRod;

	private bool playDoorOpenSFXOnce;
	private bool DoorLocked;

	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		AreaEntered += NextLevelDoorAreaEntered; ;
		playDoorOpenSFXOnce = false;
	}

	private void NextLevelDoorAreaEntered(Area2D area)
	{
		GD.Print($"Door collided:{area.Name}");
		if ((LightningRod as LightningRod).IsTriggered && (FireRod as FireRod).IsTriggered && (IceRod as IceRod).IsTriggered)
		{
			//Goes to the next level
			GD.Print("player goes to next level");
			GameManager.Instance.SetState(GameState.Level2);

		}
		else
		{
			GetNode("DoorLockedEvent").Call("post_event");
		}
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		if ((LightningRod as LightningRod).IsTriggered && (FireRod as FireRod).IsTriggered && (IceRod as IceRod).IsTriggered && !playDoorOpenSFXOnce)
		{
			GetNode("DoorOpenEvent").Call("post_event");
			playDoorOpenSFXOnce = true;
		}
	}
}

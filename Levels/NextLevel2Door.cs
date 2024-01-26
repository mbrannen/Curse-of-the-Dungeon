using GameJam2024.GameManagement;
using Godot;
using System;

public partial class NextLevel2Door : Area2D
{

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
		//Goes to the next level
		GetNode("DoorEnterEvent").Call("post_event");
		GD.Print("player goes to next level");
		GameManager.Instance.SetState(GameState.Level3);
			
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{

	}
}

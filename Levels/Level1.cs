using Godot;
using System;
using GameJam2024.GameManagement;

public partial class Level1 : Node2D
{
	[Export] public TileMap Map;
	[Export] public CharacterBody2D Wizard;

	public override void _Ready()
	{
		GameManager.Instance.LevelRestart += OnLevelRestart;
	}

	private void OnLevelRestart()
	{
		//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		//THIS UNSUBSCRIBE IS SO IMPORTANT I CAN'T EVEN ****BANGS HEAD ON KEYBOARD EVEN MORE THAN I DID FIGURING THIS OUT****
		GameManager.Instance.LevelRestart -= OnLevelRestart;
		GetNode("WaterZone/CollisionShape2D/WaterEvent").Call("stop_event");
		QueueFree();
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("Talents") || Input.IsActionJustReleased("Talents"))
		{
			Map.Visible = !Map.Visible;
			Wizard.Visible = !Wizard.Visible;
		}
	}

	public void Destroy()
	{
		GameManager.Instance.LevelRestart -= OnLevelRestart;
		QueueFree();
	}
}

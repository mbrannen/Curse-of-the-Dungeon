using Godot;
using System;
using GameJam2024.GameManagement;

public partial class Level2 : Node2D
{
	[Export] public TileMap Map;
	[Export] public CharacterBody2D Wizard;
	
	public override void _Ready()
	{
		GameManager.Instance.LevelRestart += OnLevelRestart;
	}

	private void OnLevelRestart()
	{
		GameManager.Instance.LevelRestart -= OnLevelRestart;
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
		//GameManager.Instance.LevelRestart -= OnLevelRestart;
		QueueFree();
	}
}

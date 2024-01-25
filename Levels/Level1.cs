using Godot;
using System;
using GameJam2024.GameManagement;

public partial class Level1 : Node2D
{
	public override void _Ready()
	{
		GameManager.Instance.LevelRestart += OnLevelRestart;
	}

	private void OnLevelRestart()
	{
		//!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!!
		//THIS UNSUBSCRIBE IS SO IMPORTANT I CAN'T EVEN ****BANGS HEAD ON KEYBOARD EVEN MORE THAN I DID FIGURING THIS OUT****
		GameManager.Instance.LevelRestart -= OnLevelRestart;
		QueueFree();
	}

	public override void _Process(double delta)
	{
		if (Input.IsActionJustPressed("Talents") || Input.IsActionJustReleased("Talents"))
		{
			Visible = !Visible;
		}
	}
}

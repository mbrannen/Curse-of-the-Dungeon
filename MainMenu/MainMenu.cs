using Godot;
using System;
using GameJam2024.GameManagement;
using GameJam2024.MainMenu;

public partial class MainMenu : Control
{
	[ExportGroup("MouseIcons")] 
	[Export] private Resource NormalCursor;
	[Export] private Resource Grab;
	[Export] private Resource Error;
	
	[ExportGroup("MainMenu")]
	[Export] public Button StartButton;
	[Export] public Button OptionsButton;
	[Export] public Button CreditsButton;
	[Export] public Button ExitGame;
	[Export] public Panel MainMenuPanel;
	
	[ExportGroup("GameOverMenu")]
	[Export] public Button RestartButton;
	[Export] public Button OptionsButton_GOM;
	[Export] public Button CreditsButton_GOM;
	[Export] public Button MainMenuButton_GOM;
	[Export] public Panel GameOverPanel;
	[Export] public AnimationPlayer GameOverAnimator;
	

	[ExportGroup("MenuScenes")]
	[Export] public Control CreditsScene;
	[Export] public Control OptionsScene;
	
	[ExportGroup("Theme")]
	[Export] public Theme Theme;
	[Export] public Font DefaultFont;
	[Export] public Font AccessbilityFont;
	[Export] public Control IntroCutscene;
	
	[Export] public Control GameUI;
	[Export] public Control RuneTree;
	
	[ExportGroup("Levels")]
	[Export] public PackedScene Level1;
	[Export] public PackedScene Level2;
	[Export] public PackedScene Level3;
	
	private Level1  _level1;
	private Level2 _level2;
	private Level3 _level3;

	private Node _cutscene;
	private Node _credits;

	[ExportGroup("EndingScenes")] 
	[Export] public PackedScene BadEndingScene;
	[Export] public PackedScene GoodEndingScene;
	[Export] public PackedScene Credits;
	

	public override void _EnterTree()
	{
		MainMenuManager.Instance.InitState();
		MainMenuManager.Instance.FontChanged += OnFontChanged;
		MainMenuManager.Instance.CreditsBackButtonPressed += OnCreditsBackButtonPressed;
		MainMenuManager.Instance.OptionsBackButtonPressed += OnOptionsBackButtonPressed;
		
		GameManager.Instance.MainMenu += OnMainMenu;
		GameManager.Instance.LevelOneStart += OnLevelOneStart;
		GameManager.Instance.LevelTwoStart += OnLevelTwoStart;
		GameManager.Instance.LevelThreeStart += OnLevelThreeStart;
		GameManager.Instance.GameOverNotify += OnGameOverNotify;
		GameManager.Instance.BadEndingStart += OnBadEndingStart;
		GameManager.Instance.GoodEndingStart += OnGoodEndingStart;
		GameManager.Instance.CreditsStart += OnCreditsStart;
		GameManager.Instance.GoblinsEngagedChanged += OnGoblinsEngagedChanged;
		
		StartButton.Pressed += StartButtonOnPressed;
		StartButton.MouseEntered += ButtonOnMouseover;
		OptionsButton.Pressed += OptionsButtonOnPressed;
		OptionsButton.MouseEntered += ButtonOnMouseover;
		CreditsButton.Pressed += CreditsButtonOnPressed;
		CreditsButton.MouseEntered += ButtonOnMouseover;
		ExitGame.Pressed += ExitGameOnPressed;
		ExitGame.MouseEntered += ButtonOnMouseover;
		
		RestartButton.Pressed += RestartButtonOnPressed;
		RestartButton.MouseEntered += ButtonOnMouseover;
		OptionsButton_GOM.Pressed += OptionsButton_GOMOnPressed;
		OptionsButton_GOM.MouseEntered += ButtonOnMouseover;
		MainMenuButton_GOM.Pressed += MainMenuButtonGomOnPressed;
		MainMenuButton_GOM.MouseEntered += ButtonOnMouseover;
		
		
		GetNode("Wwise/SceneMainMenu").Call("set_state");
	}

	public override void _Ready()
	{
		Input.SetCustomMouseCursor(NormalCursor, Input.CursorShape.Arrow);
		Input.SetCustomMouseCursor(Grab, Input.CursorShape.Drag);
		Input.SetCustomMouseCursor(Grab, Input.CursorShape.Move);
		Input.SetCustomMouseCursor(Error, Input.CursorShape.Forbidden);
		Input.SetCustomMouseCursor(Grab, Input.CursorShape.CanDrop);
	}

	private void CreditsButton_GOMOnPressed()
	{
		GameOverPanel.Visible = false;
		CreditsScene.Visible = true;
	}

	private void OptionsButton_GOMOnPressed()
	{
		GameOverPanel.Visible = false;
		OptionsScene.Visible = true;
	}

	private void RestartButtonOnPressed()
	{
		GameManager.Instance.RestartLevel();
	}

	private void MainMenuButtonGomOnPressed()
	{
		GameManager.Instance.SetState(GameState.MainMenu);
	}

	public override void _Process(double delta)
	{
		if(Input.IsActionJustPressed("Spell Select Right"))
			GameManager.Instance.IncreaseSpellIndex();
		if(Input.IsActionJustPressed("Spell Select Left"))
			GameManager.Instance.DecreaseSpellIndex();
	}
	
	private void OnMainMenu()
	{
		MainMenuPanel.Visible = true;
		GameOverPanel.Visible = false;
		IntroCutscene.Visible = false;
		try
		{
			_level1?.Destroy();
		}
		catch
		{
			//lol no errors here folks
		}

		try
		{
			_level2?.Destroy();
		}
		catch{}

		try
		{
			_level3?.Destroy();
		}
		catch {}

		try
		{
			_credits.QueueFree();
		}
		catch
		{
			
		}
		
		GetNode("Wwise/SceneMainMenu").Call("set_state");
		GetNode("Wwise/EventCaveSFX").Call("stop_event");
		GetNode("Wwise/EventEnemyPercussionStart").Call("stop_event");
		
	}

	private void OnLevelOneStart()
	{
		MainMenuPanel.Visible = false;
		GameOverPanel.Visible = false;
		IntroCutscene.Visible = false;

		_level1 = Level1.Instantiate() as Level1;
		AddChild(_level1);

		GetNode("Wwise/SceneLevelOne").Call("set_state");
		GetNode("Wwise/EventCaveSFX").Call("post_event");
		GameManager.Instance.SetGoblinsEngaged(0);
	}
	
	private void OnLevelTwoStart()
	{
		MainMenuPanel.Visible = false;
		GameOverPanel.Visible = false;
		IntroCutscene.Visible = false;
		try
		{
			_level1.Destroy();
		}
		catch
		{
			
		}
		_level2 = Level2.Instantiate() as Level2;
		AddChild(_level2);
		GameManager.Instance.SetGoblinsEngaged(0);
	}
	
	private void OnLevelThreeStart()
	{
		MainMenuPanel.Visible = false;
		GameOverPanel.Visible = false;
		IntroCutscene.Visible = false;
		try
		{
			_level2.Destroy();
		}
		catch
		{
			
		}
		
		_level3 = Level3.Instantiate() as Level3;
		AddChild(_level3);
		GameManager.Instance.SetGoblinsEngaged(0);
	}
	
	private void OnBadEndingStart()
	{
		MainMenuPanel.Visible = false;
		GameOverPanel.Visible = false;
		IntroCutscene.Visible = false;
		_level3.Destroy();
		_cutscene = BadEndingScene.Instantiate();
		GetNode<CanvasLayer>("CanvasLayer").AddChild(_cutscene);
	}
	
	private void OnGoodEndingStart()
	{
		MainMenuPanel.Visible = false;
		GameOverPanel.Visible = false;
		IntroCutscene.Visible = false;
		_level3.Destroy();
		_cutscene = GoodEndingScene.Instantiate();
		GetNode<CanvasLayer>("CanvasLayer").AddChild(_cutscene);
	}
	
	private void OnCreditsStart()
	{
		MainMenuPanel.Visible = false;
		GameOverPanel.Visible = false;
		IntroCutscene.Visible = false;
		_cutscene.QueueFree();
		_credits = Credits.Instantiate();
		GetNode<CanvasLayer>("CanvasLayer").AddChild(_credits);
	}
	
	private void OnGameOverNotify()
	{
		GetNode("Wwise/EventGameOver").Call("post_event");
		GameOverAnimator.Play("fadein");
		MainMenuPanel.Visible = false;
		GameOverPanel.Visible = true;
	}

	private void OnFontChanged(long index)
	{
		switch (index)
		{
			case 0:
				Theme.DefaultFont = DefaultFont;
				break;
			case 1:
				Theme.DefaultFont = AccessbilityFont;
				break;
			default:
				Theme.DefaultFont = DefaultFont;
				break;
		}
	}

	private void OnOptionsBackButtonPressed()
	{
		GetNode("Wwise/EventButtonPress").Call("post_event");
		OptionsScene.Visible = false;
		if(GameManager.Instance.GetState() == GameState.MainMenu)
			MainMenuPanel.Visible = true;
		else if (GameManager.Instance.GetState() == GameState.GameOver)
			GameOverPanel.Visible = true;
	}

	private void OnCreditsBackButtonPressed()
	{
		GetNode("Wwise/EventButtonPress").Call("post_event");
		CreditsScene.Visible = false;
		if(GameManager.Instance.GetState() == GameState.MainMenu)
			MainMenuPanel.Visible = true;
		else if (GameManager.Instance.GetState() == GameState.GameOver)
			GameOverPanel.Visible = true;
	}

	private void CreditsButtonOnPressed()
	{
		GetNode("Wwise/EventButtonPress").Call("post_event");
		
		MainMenuPanel.Visible = false;
		GameOverPanel.Visible = false;
		IntroCutscene.Visible = false;
		_credits = Credits.Instantiate();
		GetNode<CanvasLayer>("CanvasLayer").AddChild(_credits);
	}
	
	private void ExitGameOnPressed()
	{
		GetTree().Quit();
	}

	private void OptionsButtonOnPressed()
	{
		GetNode("Wwise/EventButtonPress").Call("post_event");
		OptionsScene.Visible = true;
		MainMenuPanel.Visible = false;
	}

	private void StartButtonOnPressed()
	{
		GetNode("Wwise/EventButtonPress").Call("post_event");
		IntroCutscene.Visible = true;
		MainMenuPanel.Visible = false;
		GameManager.Instance.SetState(GameState.IntroCutscene);
	}

	private void ButtonOnMouseover()
	{
		GetNode("Wwise/EventButtonMouseover").Call("post_event");
	}
	
	private void OnGoblinsEngagedChanged(int value)
	{
		if (value == 1)
			GetNode("Wwise/EventEnemyPercussionStart").Call("post_event");
		else if (value == 0)
			GetNode("Wwise/EventEnemyPercussionStop").Call("post_event");
	}
}

using Godot;
using System;

public partial class MainMenu : Control
{
	private CanvasLayer StoryScene;
	private CanvasLayer LevelLayout;
	private Button Tutorial_Button;
	private Button Story_Button;
	private Button Levels_Button;

public override void _Ready()
	{
		StoryScene = GetNode<CanvasLayer>("CanvasLayerStory");
		StoryScene.Visible = false;
		
		LevelLayout = GetNode<CanvasLayer>("CanvasLayerLevels");
		LevelLayout.Visible = false;
	}

private void _on_tutorial_button_pressed()
	{
		GetTree().ChangeSceneToFile("res://Scenes/Tutorial/Tutorial_Page.tscn");
	}
private void _on_story_open_pressed()
	{
		StoryScene.Visible = true;
	}
private void _on_story_close_pressed()
	{
		StoryScene.Visible = false;
	}
private void _on_levels_button_pressed()
	{
		LevelsButtonClicked();
	}
private void _on_close_2_pressed()
	{
		LevelsButtonClicked();
	}
private void LevelsButtonClicked()
	{
		GD.Print("In levels Button clicked methos; signal working");
		Levels_Button = GetNode<Button>("LevelsButton");
		Tutorial_Button = GetNode<Button>("TutorialButton");
		Story_Button = GetNode<Button>("StoryButton");
		if (Levels_Button.Visible == true)
		{
			Levels_Button.Visible = false;
			Tutorial_Button.Visible = false;
			Story_Button.Visible = false;
			LevelLayout.Visible = true;
		}
		else
		{
			Levels_Button.Visible = true;
			Tutorial_Button.Visible = true;
			Story_Button.Visible = true;
			LevelLayout.Visible = false;
		}
	}
}

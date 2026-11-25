using Godot;
using System;

public partial class TutorialPage : Node2D
{
	private SpaceshipBody _ship;
	public override void _Ready()
	{
		_ship = GetNode<SpaceshipBody>("SpaceShip");
		_ship.BoltCountChanged += OnBoltCountChanged;
	}

	private async void OnBoltCountChanged()
	{
		if (_ship.PickupBoltCount >= 3)
		{
			GD.Print("Good Job!You have collected 3 bolts!");
			await ToSignal(GetTree().CreateTimer(2.0), SceneTreeTimer.SignalName.Timeout);
			GD.Print("Returning to Main Menu...");
			GetTree().ChangeSceneToFile("res://Main_Menu.tscn");
		}
	}
}

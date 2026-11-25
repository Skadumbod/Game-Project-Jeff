using Godot;
using System;

public partial class PickupBolt : Node2D
{
	private Godot.Timer OscillationTimer;
	public float OscillationSpeed = 9.5f;
	public override void _Ready()
	{
		OscillationTimer = GetNode<Godot.Timer>("OscillationTimer");
		OscillationTimer.Timeout += OnOscillationTimerTimeout;
	}

	public override void _Process(double delta)
	{
		Position += new Vector2(0, OscillationSpeed * (float)delta);   // Move the pickup bolt up and down based on the oscillation speed
	}
	public void OnOscillationTimerTimeout()
	{
		OscillationSpeed *= -1.0f;
	}

	public void _on_boltpickup_area_entered(Area2D area)
	{
		if (area.IsInGroup("Spaceship"))
		{
			if (area.GetParent() is SpaceshipBody spaceship)
			{
				spaceship.BoltPickedUp();
			}
			QueueFree();
		}
	}
}

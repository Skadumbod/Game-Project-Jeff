using Godot;
using System;

public partial class SpaceshipBody : CharacterBody2D
{
	private AudioStreamPlayer thrustsound;
	private Sprite2D ThrustImage;
	public float RotationSpeed = 3.5f;
	public float Thrust = 270.0f;
	public float MaxSpeed = 1000.0f;
	public float drag = 25.0f;
	public int PickupBoltCount = 0;

    public override void _Ready()
    {
        ThrustImage = GetNode<Sprite2D>("ThrustImg");
		thrustsound = GetNode<AudioStreamPlayer>("BoostSound");
    }
    public override void _PhysicsProcess(double delta)
    {
       float dt = (float)delta;
	   
	   float turn = Input.GetAxis("ui_left", "ui_right");
	   Rotation += turn * RotationSpeed * dt;
	   
	   if (Input.IsActionPressed("ThrustInput"))
		{
			Vector2 forward = Transform.X;
			Velocity += forward * Thrust * dt;
			Velocity = Velocity.LimitLength(MaxSpeed);
		}

		Velocity = Velocity.MoveToward(Vector2.Zero, drag * dt);
		MoveAndSlide();

		if (Input.IsActionPressed("ThrustInput"))     //Handles boost animations.
		{
			ThrustImage.Visible = true;
		}
		else
		{
			ThrustImage.Visible = false;
		}

		//Audio for boost
		if (Input.IsActionJustPressed("ThrustInput"))
		{thrustsound.Play();}
		if (Input.IsActionJustReleased("ThrustInput"))
		{thrustsound.Stop();}
    }

	[Signal]
	public delegate void BoltCountChangedEventHandler();
	public void BoltPickedUp()
	{
		PickupBoltCount += 1;
		GD.Print("Bolts Picked up:" + PickupBoltCount);
		EmitSignal(SignalName.BoltCountChanged);
	}
}

using Godot;
using System;

public partial class Player : Area2D
{
	[Export]
	public int Speed { get; set; } = 300; //Player movement speed
	public Vector2 ScreenSize;
	
	// Called when the node enters the scene tree for the first time.
	public override void _Ready()
	{
		ScreenSize = GetViewportRect().Size;
	}

	// Called every frame. 'delta' is the elapsed time since the previous frame.
	public override void _Process(double delta)
	{
		var velocity = Vector2.Zero;

		if (Input.IsActionPressed("walk_right"))
		{
			velocity.X += 2;
		}

		if (Input.IsActionPressed("walk_left"))
		{
			velocity.X -= 2;
		}

		if (Input.IsActionPressed("walk_down"))
		{
			velocity.Y += 1;
		}

		if (Input.IsActionPressed("walk_up"))
		{
			velocity.Y -= 1;
		}
		
		var animatedSprite2D = GetNode<AnimatedSprite2D>("AnimatedSprite2D");

		if (velocity.Length() > 0)
		{
			velocity = velocity.Normalized() * Speed;
		}
		//else
		//{
			//animatedSprite2D.Stop();
		//}
		
		Position += velocity * (float)delta;
		Position = new Vector2(
   		x: Mathf.Clamp(Position.X, 0, ScreenSize.X),
		y: Mathf.Clamp(Position.Y, 0, ScreenSize.Y)
		);
		
		
	}
}

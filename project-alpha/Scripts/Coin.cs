using Godot;
using System;

public partial class Coin : Area2D
{
	private void OnBodyEntered(Node2D body)
	{
		GD.Print("+1");
		QueueFree();
	}
}

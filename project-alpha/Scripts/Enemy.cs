using Godot;
using System;

public enum MovementDirection
{
    Left = -1,
    Right = 1
}

public partial class Enemy : Node2D
{
    [Export]
    public float Speed { get; set; } = 60.0f;

    private RayCast2D raycastRight = null;
    private RayCast2D raycastLeft = null;
    private AnimatedSprite2D animatedSprite = null;

    private MovementDirection movementDirection = MovementDirection.Left;

    public override void _Ready()
    {
        raycastRight = GetNode<RayCast2D>("RayCastRight");
        raycastLeft = GetNode<RayCast2D>("RayCastLeft");
        animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite");
    }

    public override void _Process(double delta)
    {
        float dt = (float)delta;
        UpdateDirection();
        UpdatePosition(dt);
        UpdateAnimation();
    }

    private void UpdateAnimation()
    {
        if (movementDirection == MovementDirection.Left)
        {
            animatedSprite.FlipH = true;
            return;
        }

        animatedSprite.FlipH = false;
    }

    private void UpdateDirection()
    {
        if (raycastLeft.IsColliding())
        {
            movementDirection = MovementDirection.Right;
            return;
        }

        if (raycastRight.IsColliding())
        {
            movementDirection = MovementDirection.Left;
            return;
        }
    }

    private void UpdatePosition(float delta)
    {
        Vector2 NewPosition = Position;
        NewPosition.X += (int)movementDirection * Speed * delta;
        Position = NewPosition;
    }
}

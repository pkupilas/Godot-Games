using Godot;

public partial class Player : CharacterBody2D
{
    [Export]
    public float Speed = 130.0f;
    [Export]
    public float JumpVelocity = -300.0f;

    private AnimatedSprite2D animatedSprite = null;

    private string JumpKeyName = "Jump";
    private string MoveLeftKeyName = "MoveLeft";
    private string MoveRightKeyName = "MoveRight";
    private string IdleAnimationName = "Idle";
    private string RunAnimationName = "Run";
    private string JumpAnimationName = "Jump";

    public override void _Ready()
    {
        animatedSprite = GetNode<AnimatedSprite2D>("AnimatedSprite");
    }

    public override void _PhysicsProcess(double delta)
    {
        float moveInput = Input.GetAxis(MoveLeftKeyName, MoveRightKeyName);
        UpdateAnimation(moveInput);
        UpdateMovement(moveInput, delta);
        MoveAndSlide();
    }

    private void UpdateAnimation(float moveInput)
    {
        if (animatedSprite == null)
        {
            return;
        }

        if (moveInput > 0.0f)
        {
            animatedSprite.FlipH = false;
        }

        if (moveInput < 0.0f)
        {
            animatedSprite.FlipH = true;
        }

        if (IsOnFloor())
        {
            GD.Print("IsOnFloor");
            if (Mathf.IsZeroApprox(moveInput))
            {
                animatedSprite.Play(IdleAnimationName);
            }
            else
            {
                animatedSprite.Play(RunAnimationName);
            }
        }
        else
        {
            GD.Print("Is NOT OnFloor");
            animatedSprite.Play(JumpAnimationName);
        }
    }

    private void UpdateMovement(float moveInput, double delta)
    {
        Vector2 velocity = Velocity;

        if (!IsOnFloor())
        {
            velocity += GetGravity() * (float)delta;
        }

        if (Input.IsActionJustPressed(JumpKeyName) && IsOnFloor())
        {
            velocity.Y = JumpVelocity;
        }

        if (Mathf.IsZeroApprox(moveInput))
        {
            velocity.X = Mathf.MoveToward(Velocity.X, 0, Speed);
        }
        else
        {
            velocity.X = moveInput * Speed;
        }

        Velocity = velocity;
    }
}

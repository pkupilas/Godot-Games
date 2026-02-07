using Godot;

public partial class Killzone : Area2D
{
    private Timer timer;

    public override void _Ready()
    {
        timer = GetNode<Timer>("Timer");
        SetUpTimer();
    }

    private void SetUpTimer()
    {
        if (timer == null)
        {
            return;
        }

        timer.Timeout += OnTimerTimeout;
    }

    private void OnTimerTimeout()
    {

        Engine.TimeScale = 1.0f;
        GetTree().ReloadCurrentScene();
    }

    private void OnBodyEntered(Node2D body)
    {
        timer.Start();
        body.GetNode<CollisionShape2D>("CollisionShape2D").QueueFree();
        Engine.TimeScale = 0.5f;
    }
}
